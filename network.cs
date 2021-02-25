#define   _debug_
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using zk;
using System.Windows.Forms;
using System.Timers;
using Newtonsoft.Json;
using DispatchServer;
using System.Threading;

namespace zk
{
    class network
    {
            static private int svr_port = 0;        //服务器端口号
            static private string svr_ip = "";      //服务器ip地址
            static public Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   //tcp连接socket
            static private UTF8Encoding u8 =new UTF8Encoding();
            static private ThreadStart listenOnPortThreadDelegate = new ThreadStart(network.receiveDataProc);   //接收数据函数
            static private Thread receiveDataThread = new Thread(listenOnPortThreadDelegate);                   //接收数据线程
            static private ThreadStart sendDataThreadDelegate = new ThreadStart(network.sendRSDataProc);        //发送数据函数
            static private Thread sendDataThread = new Thread(sendDataThreadDelegate);                          //发送数据线程
            static private Form1 form1tmp=new Form1();
            static private JsonSerializerSettings setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            static public ThreadStart networkErrorHandleThreadDelegate = new ThreadStart(network.networkErrorHandle);       //故障处理函数
            static public Thread netErrorHandleThread = new Thread(networkErrorHandleThreadDelegate);                       //网络故障处理线程

            static public bool networkInitialize()  //初始化网络
            {
                svr_port = GlobalVarForApp.server_port;     //获取配置信息
                svr_ip = GlobalVarForApp.server_ip;
                bool state = true;
                try
                {
                    listenSocket.Connect(new IPEndPoint(IPAddress.Parse(svr_ip), svr_port));  //连接服务器
                }
                catch (Exception e)
                {
                    state = false;
                    appLog.exceptionRecord("网络初始化异常"+e.Message);
                }
                if(state ==true )                         //网络正常，监听线程开启
                {
                    GlobalVarForApp.networkStatusBool = true;
                    receiveDataThread.Start();            //开启接收线程
                    sendDataThread.Start();               //开启发送接收线程
                    netErrorHandleThread.Start();
#if _debug_
                    Console.WriteLine("--------------接收线程开启");
                    Console.WriteLine("--------------发送线程开启");
                    Console.WriteLine("--------------网络故障重连线程开启");
#endif
                }
                return state;
            }

            public static void networkErrorHandle()
            {
                try //第一次启动进入等待，等待网络故障被唤醒
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
                //被唤醒之后
                bool state=GlobalVarForApp.networkStatusBool;
                while (true)
                {
                    if (state == true)//网络恢复后，进入无限等待，等唤醒
                    {
#if _debug_
                        Console.WriteLine("网络恢复");
#endif
                        try
                        {
                            receiveDataThread.Interrupt();      //重连成功，开启接收线程
                            //sendDataThread.Interrupt();
                            GlobalVarForApp.networkStatusBool=state;
                            Thread.Sleep(Timeout.Infinite);
                        }
                        catch (ThreadInterruptedException)
                        {
                            state=false;
                            continue; //网络故障，被唤醒，开始重连
                        }
                    }
                    else    //网络故障，被唤醒，开始重连
                    {
#if _debug_
                            Console.WriteLine("Connect to server");
#endif
                            try{
                              listenSocket.Shutdown(SocketShutdown.Both);
                            }
                            finally{
                              listenSocket.Close();
                            }
                            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            svr_port = GlobalVarForApp.server_port;     //获取配置信息
                            svr_ip = GlobalVarForApp.server_ip;
                            while(state==false)
                            {
                              try{
                                  state=true;
                                  listenSocket.Connect(new IPEndPoint(IPAddress.Parse(svr_ip), svr_port));  //连接服务器
                              }
                              catch (Exception e){
                                  Console.WriteLine(e.Message);
                                  state = false; //appLog.exceptionRecord("网络初始化异常");
                              }
                            }
                        }
                        //Console.WriteLine("唤醒receiveDataThread");
                    }
                }

            //  接收线程
            //在listenSocket 上监听
            public static void receiveDataProc()
            {
                int messageCount=0;
                byte[] messageBuf = new byte[10000];
                string message = "";
                int a = -1;
                while(true)
                {
                  if(GlobalVarForApp.networkStatusBool==false)  //网络故障
                  {
                    try
                    {
                        Thread.Sleep(Timeout.Infinite);         //线程阻塞
                    }
                    catch (ThreadInterruptedException)
                    {
                        message = "";
                    }
                  }
#if _debug_
                  Console.WriteLine("接收线程开启");
#endif
                  messageCount = 0;
                  a = -1;
                  try{
                    messageCount = listenSocket.Receive(messageBuf);        //将接收数据放入缓冲区
                  }
                  catch (SocketException exc)
                  {
                    GlobalVarForApp.networkStatusBool = false;
#if _debug_
                    Console.WriteLine("listenSocket.Receive函数异常,可能是网络中断");
#endif
                    netErrorHandleThread.Interrupt();
                    appLog.exceptionRecord("网络中断" + exc.Message);
                    continue;
                  }
                    message = message.Trim()+u8.GetString(messageBuf,0,messageCount).Trim();
#if _debug_
                    Console.Write(message);
#endif
                    a = message.IndexOf("DataEnd");                                         //数据是否有DataEnd
                    if (a != -1)                       //数据中存在DataEnd
                    {
                        try
                        {
                            GlobalVarForApp.receiveMessageQueue.Enqueue(JsonConvert.DeserializeObject<RSData>(message.Substring(0, a)));       //获取有效数据
                            message = message.Substring(a + 7);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                       GlobalVarForApp.messageHandle_thread.Interrupt();
                    }
                }
            }

            public static void sendData(RSData dataToSend)
            {
                GlobalVarForApp.sendMessageQueue.Enqueue(dataToSend);
                //sendDataThread is running ?
                /*while (sendDataThread.ThreadState == ThreadState.Running)  //is running
                {
                    Thread.Sleep(100);
                    //Console.WriteLine("rotate");
                    //Console.WriteLine(sendDataThread.ThreadState);
                }*/
                if(GlobalVarForApp.networkStatusBool==true)
                  sendDataThread.Interrupt();
            }

            public static void sendRSDataProc()
            {
                string tmp_str = "";
                byte[] send_buf = new byte[10000];
                int sendCount = 0;
                RSData tmp = new RSData();
                while (true)       //
                {
                    while(GlobalVarForApp.sendMessageQueue.Count() != 0)
                    {
                            tmp = GlobalVarForApp.sendMessageQueue.Dequeue();
                            tmp_str = JsonConvert.SerializeObject(tmp, Formatting.Indented, setting)+ "DataEnd" ;
                            send_buf = u8.GetBytes(tmp_str);
                            try
                            {
                                sendCount = listenSocket.Send(send_buf, send_buf.Length, SocketFlags.None);
                            }
                            catch (SocketException e)
                            {
                                MessageBox.Show("网络故障：发送数据失败");
                                appLog.exceptionRecord("发送数据失败" + e.Message);
                                GlobalVarForApp.sendMessageQueue.Enqueue(tmp);
                                break;
                            }
                            send_buf.Initialize();
                    }
                    try
                    {
                        Thread.Sleep(Timeout.Infinite);//发送数据队列为空，线程被阻止
                    }
                    catch (Exception)
                    {

                    }
                }
                //return;
            }
        }
}
