using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 点名器;
using static System.Net.Mime.MediaTypeNames;

namespace random_name
{
    public partial class dmqform1_11 : Form
    {

        string label1_text, button1_before, button1_ontick, button1_after;
        FileStream name_stream = new FileStream("./data/list.txt", FileMode.Open);
        FileStream readme_stream = new FileStream("readme.txt", FileMode.Open);
        FileStream uiset_stream = new FileStream("./data/ui_setting.txt", FileMode.Open);
        public static List<string> name_list = new List<string>();
        public static string name_sc, uiset_sc;
        private object Label1;
        private SpeechSynthesizer speech; 
        string dyz1 = "我是多音字1";//多音字解决方案
        string dyz2 = "我是多音字2";
        public static List<string> ConfusionArray(List<string> name_list)
        {
            Random random = new Random();
            return name_list.OrderBy(x => random.Next()).ToList();
        }

        public dmqform1_11()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 重写系统Key处理事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Left || keyData == Keys.Right)
            {
                return false;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new dmqform2_11();
            form2.VisibleChanged += (_, _) => Show();
            form2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    button1.PerformClick();
                    break;
                case Keys.Right:
                    button1.PerformClick();
                    break;
                case Keys.PageDown:
                    button1.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked is false)
            {
                timer1.Interval = 60;
            }
            else if (checkBox3.Checked is true)
            {
                timer1.Interval = 35;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader name_read = new StreamReader(name_stream, UnicodeEncoding.GetEncoding("utf-8"));
            StreamReader uiset_read = new StreamReader(uiset_stream, UnicodeEncoding.GetEncoding("utf-8"));


            while ((name_sc = name_read.ReadLine()) != null)
            {
                name_list.Add(name_sc);
            }
            int count = name_list.Count;
            label4.Text = "已加载" + count + "个姓名";

            int i = 0;
            while ((uiset_sc = uiset_read.ReadLine()) != null)
            {
                i++;
                if (i == 1)
                    label1_text = uiset_sc;
                else if (i == 2)
                    button1_before = uiset_sc;
                else if (i == 3)
                    button1_ontick = uiset_sc;
                else if (i == 4)
                    button1_after = uiset_sc;
            }

            name_stream.Close();
            label1.Text = label1_text;
            button1.Text = button1_before;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private async void button3_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(100);
            button1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader readme_read = new StreamReader(readme_stream, UnicodeEncoding.GetEncoding("utf-8"));
            MessageBox.Show(readme_read.ReadToEnd() + "\n名单设置：点名器所在位置的/data/list就是名单\n\n2024.8.23");
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            name_list = ConfusionArray(name_list);
            label1.Text = name_list[new Random().Next(name_list.Count)];


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            name_list.Clear();
            FileStream name_stream = new FileStream("./data/list.txt", FileMode.Open);
            StreamReader name_read = new StreamReader(name_stream, UnicodeEncoding.GetEncoding("utf-8"));
            while ((name_sc = name_read.ReadLine()) != null)
            {
                name_list.Add(name_sc);
            }
            name_stream.Close();
            int count = name_list.Count;
            label4.Text = "还剩余" + count + "个姓名";
            button1.Focus();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled is false)
            {
                timer1.Start();
                button1.Text = button1_ontick;
            }
            else if (timer1.Enabled is true)
            {

                string text = label1.Text;


                if (checkBox1.Checked is true)
                {
                    timer1.Stop();
                    button1.Enabled = false;
                    button1.Hide();

                    bool qzx_result = dyz1.Equals(label1.Text);
                    bool tzl_result = dyz2.Equals(label1.Text);
                    await Task.Delay(50);

                    if (qzx_result)
                    {
                        //接受文本框的文字
                        SpVoice voice1 = new SpVoice();
                        //音量
                        voice1.Volume = 100;
                        //语速
                        voice1.Rate = 1;
                        //朗读内容
                        voice1.Speak("我是多音字1的正确读音");//假如叫“张单”时，正确读音为“chan”，就应在此处改为“张蝉”，但显示仍为“张单”
                    }

                    else if (tzl_result)
                    {
                        //接受文本框的文字
                        SpVoice voice1 = new SpVoice();
                        //音量
                        voice1.Volume = 100;
                        //语速
                        voice1.Rate = 1;
                        //朗读内容
                        voice1.Speak("我是多音字2的正确读音");//同上
                    }
                    else
                    {
                        //接受文本框的文字
                        SpVoice voice = new SpVoice();
                        //音量
                        voice.Volume = 100;
                        //语速
                        voice.Rate = 1;
                        //朗读内容
                        voice.Speak(text);
                    }

                    button1.Show();
                    
                    int count = name_list.Count;
                    label4.Text = "还剩余" + count + "个姓名";
                    button1.Text = button1_after;
                    await Task.Delay(10);
                    button1.Enabled = true;
                    button1.Focus();



                }
                else if (checkBox1.Checked is false)
                {
                    timer1.Stop();
                    
                    int count = name_list.Count;
                    label4.Text = "还剩余" + count + "个姓名";
                    button1.Text = button1_after;
                }


                if (name_list.Count == 0)
                {
                    MessageBox.Show("所有人已被点过，即将重置名单", "重置名单", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileStream name_stream = new FileStream("./data/list.txt", FileMode.Open);
                    StreamReader name_read = new StreamReader(name_stream, UnicodeEncoding.GetEncoding("utf-8"));
                    while ((name_sc = name_read.ReadLine()) != null)
                    {
                        name_list.Add(name_sc);
                    }
                    name_stream.Close();
                    int count = name_list.Count;
                    label4.Text = "还剩余" + count + "个姓名";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

    }
}
