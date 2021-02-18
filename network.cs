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
            static private Thread receiveDataThread = new Thread(listenOnPortThreadDelegate);                             //接收数据线程
            static private ThreadStart sendDataThreadDelegate = new ThreadStart(network.sendRSDataProc);      //发送数据函数
            static private Thread sendDataThread = new Thread(sendDataThreadDelegate);                                       //发送数据线程
            static private Form1 form1tmp=new Form1();
            static private JsonSerializerSettings setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            static public bool networkInitialize(object f)  //初始化网络
            {
                //form1tmp = (Form1)f;
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
                if(state ==true )       //网络正常，监听线程开启
                {
                    receiveDataThread.Start();      //开启接收线程
                    sendDataThread.Start();          //开启发送接收线程
                    Console.WriteLine("没有我吗？？？？");

#if _debug_
                    Console.WriteLine("--------------接收线程开启");
                    Console.WriteLine("--------------发送线程开启");
#endif
                }
                return state;
            }

            private static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                                  e.SignalTime);
            }

            public static void receiveDataProc()            //在listenSocket 上监听
            {
                int messageCount=0;
                byte[] messageBuf = new byte[10000];
                string message = "";
                int a = -1;
                while (GlobalVarForApp.networkStatusBool)
                {
                    messageCount = 0;
                    a = -1;
                    try{
                            messageCount = listenSocket.Receive(messageBuf);        //将接收数据放入缓冲区
                    }
                    catch (Exception exc){
                        GlobalVarForApp.networkStatusBool = false;
#if _debug_
                        Console.WriteLine("listenSocket.Receive函数异常,可能是网络中断");
#endif
                        appLog.exceptionRecord("网络中断" + exc.Message);
                    }
                    message = message.Trim()+u8.GetString(messageBuf,0,messageCount).Trim();
                    a = message.IndexOf("DataEnd");                                         //数据是否有DataEnd
                    if (a != -1)                       //数据中存在DataEnd
                    {
                        try
                        {
                            GlobalVarForApp.receiveMessageQueue.Enqueue(JsonConvert.DeserializeObject<RSData>(message.Substring(0, a)));       //获取有效数据
                            message = message.Substring(a + 7);
                            //form1tmp.messageHandle();
                            //netandorder.HandleTheMessageReceive();  //处理
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    GlobalVarForApp.messageHandle_thread.Interrupt();
                }
                return;
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
                sendDataThread.Interrupt();
            }

            public static void sendRSDataProc()
            {
                string tmp_str = "";
                byte[] send_buf = new byte[10000];
                int sendCount = 0;
                while (GlobalVarForApp.networkStatusBool)       //  networkstatus normal ??
                {
                    RSData tmp = new RSData();
                    while(GlobalVarForApp.sendMessageQueue.Count() != 0)
                    {
                            tmp = GlobalVarForApp.sendMessageQueue.Dequeue();
                            tmp_str = JsonConvert.SerializeObject(tmp, Formatting.Indented, setting)+ "DataEnd" ;
                            send_buf = u8.GetBytes(tmp_str);
                            try
                            {
                                sendCount = listenSocket.Send(send_buf, send_buf.Length, SocketFlags.None);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("网络故障：发送数据失败");
                                appLog.exceptionRecord("发送数据失败" + e.Message);
                            }
                            send_buf.Initialize();
                    }
                    try
                    {
                        Thread.Sleep(Timeout.Infinite);//发送数据队列为空，线程被阻止
                    }
                    catch (Exception e)
                    {

                    }
                }
                return;
            }


            //        public bool sendData(Socket
/*
            public static void thread(Object f)
            {
                networkInitialize(f);
                try
                {//程序在这里循环 监听 网络消息
                    while (true)
                    {
                        //接收服务器发送的消息
                        //判断服务器发送的消息类型
                        //对不同类型的消息进行分类处理
                        MessageBox.Show("listen");
                        network.receiveDataProc();
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Network error!");
                }
                finally
                {
                    //System.Environment.Exit(0);
                }
            }*/
        }
}
