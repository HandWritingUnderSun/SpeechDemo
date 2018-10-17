using System;
using System.IO;
using System.Speech.Recognition;//识别语音
using System.Speech.Synthesis;//朗读语音
using System.Threading;
using System.Windows.Forms;
using System.Text;

/**
 * 语音是如何训练的？变成自己的声音
 * 
 * */

namespace SpeechDemo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private SpeechSynthesizer synth = new SpeechSynthesizer();
        int volumeValue = 20;

        private void Frm_Main_Load(object sender, EventArgs e)
        {

            //选择不同的发音
            //synth.SelectVoice("Microsoft Anna");//美式发音，但只能读英文
            synth.SelectVoice("Microsoft Lili");//能读中英文

            synth.Volume =volumeValue;//音量，范围[0~100]
            tBar_Volume.Value = volumeValue / 5;
            synth.Rate = 0;//频率，范围[-10~10]

            string strHello = "你好，欢迎使用Visual Studio 2017";

            synth.Speak(strHello);

            //创建中文识别器            
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("zh-CN")))
            {
                //初始化命令词                
                Choices conmmonds = new Choices();                //添加命令词                
                conmmonds.Add(new string[] { "早", "晚安", "Hello", "Good Morning" });//初始化命令词管理

                GrammarBuilder gBuilder = new GrammarBuilder();                //将命令词添加到管理中                
                gBuilder.Append(conmmonds);                //实例化命令词管理                
                Grammar grammar = new Grammar(gBuilder);
                //-----------------                 
                //创建并加载听写语法(添加命令词汇识别的比较精准)                
                recognizer.LoadGrammar(grammar);                //为语音识别事件添加处理程序。                
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRRecongized);                //将输入配置到语音识别器。                
                recognizer.SetInputToDefaultAudioDevice();                //启动异步，连续语音识别。                
                recognizer.RecognizeAsync(RecognizeMode.Multiple);                 //保持控制台窗口打开。                
            }
        }

        private void btn_Speek_Click(object sender, EventArgs e)
        {
            //string s = tB_SpeekText.Text.ToString();

            if (tB_SpeekText.Text.Trim().Length == 0)
            {
                MessageBox.Show("空内容无法演示!", "错误提示");
                return;
            }
            else
            {
                new Thread(Speak).Start();
                this.SaveFile(tB_SpeekText.Text.Trim());
            }

            //synth.Speak(s);//同步朗读
            //synth.SpeakAsync(s);//异步朗读

            //synth.SetOutputToWaveFile("C:\\message.wav");
        }

        private void btn_Hear_Click(object sender, EventArgs e)
        {
            this.ReadlocalFile();
        }

        /// <summary>
        /// speechrecognized事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recognizer_SpeechRRecongized(object sender, SpeechRecognizedEventArgs e)
        {
            synth.Speak(e.Result.Text);
            tB_SpeekText.Text = e.Result.Text;
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (synth.State == SynthesizerState.Speaking)
            {
                synth.Pause();
                btn_Pause.Text = "继续";
            }
            if (synth.State == SynthesizerState.Paused)
            {
                synth.Resume();
                btn_Pause.Text = "暂停";
            }
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            synth.Dispose();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
        }

        private void Speak()
        {
            synth.SpeakAsync(tB_SpeekText.Text.ToString());
            //synth.Speak(tB_SpeekText.Text.ToString());//语音阅读方法
            synth.SpeakCompleted += speech_SpeakCompleted;//绑定事件
        }


        /// <summary>
        /// 语音阅读完成触发此事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void speech_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            MessageBox.Show("完成！！！");
        }

        /// <summary>
        /// 生成语音文件的方法
        /// </summary>
        /// <param name="text"></param>
        private void SaveFile(string text)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.wav|*.wav|*.mp3|*.mp3";
            dialog.ShowDialog();

            string path = dialog.FileName;
            if (path.Trim().Length == 0)
            {
                return;
            }
            speech.SetOutputToWaveFile(path);
            speech.Volume = volumeValue;
            speech.Rate = 0;
            speech.Speak(text);
            speech.SetOutputToNull();
            MessageBox.Show("生成成功!在" + path + "路径中！", "提示");

        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 读取本地文本文件的方法
        /// </summary>
        private void ReadlocalFile()
        {
            var open = new OpenFileDialog();

            open.ShowDialog();

            //得到文件路径
            string path = open.FileName;

            if (path.Trim().Length == 0)
            {

                return;
            }

            var os = new StreamReader(path, Encoding.UTF8);
            string str = os.ReadToEnd();
            tB_SpeekText.Text = str;
        }

        /// <summary>
        /// 音量进度条拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBar_Volume_Scroll(object sender, EventArgs e)
        {
            //因为trackBar1的值为（0-10）之间而音量值为（0-100）所以要乘10；
            synth.Volume = tBar_Volume.Value * 5;
            //volumeValue = tBar_Volume.Value * 10;
        }

        #region 后续
        //语音合成
        //4.PromptBuilder pb = new PromptBuilder();
        //speak.SelectVoice("Microsoft Lili");
        //pb.ClearContent();

        //.Net 4.0 的实现方式： 
        /*
            Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
            dynamic spVoice = Activator.CreateInstance(type);
            spVoice.Speak("你好,欢迎使用 CSharp 4.0！");
            */

        //5.语音完成
        /*
            speak.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(speak_SpeakCompleted);
            void speak_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
            {
            txt.Text = "完成";
            }
            */


        //event handler 
        //reader.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(reader_SpeakCompleted);
        //或
        //sp.SpeakCompleted += (s, arg) => txt.Text = "true";
        #endregion


    }
}
