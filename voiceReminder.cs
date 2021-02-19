using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Threading;

namespace zk
{
    class voiceReminder
    {
        public static Queue<string> speakerContentQueue = new Queue<string>();
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static string voice = "";
        static public Thread thisThread;

        static public void speakerIni()
        {
            thisThread=new Thread(voiceReminder.speakerThread);
            thisThread.Start();
            synth.SetOutputToDefaultAudioDevice();
            speakerContentQueue.Clear();
        }

        static public void addVoice(string voice)
        {
            speakerContentQueue.Enqueue(voice);
            thisThread.Interrupt();
        }

        static public void speakerThread(Object thisTh)
        {
            //thisThread = (Thread)thisTh;
            while (true)
            {
                while (speakerContentQueue.Count > 0)
                {
                    //需要锁住 -----   speakerContentQueue      -----变量
                    voice = speakerContentQueue.Dequeue();
                    synth.Speak(voice);
                }
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
