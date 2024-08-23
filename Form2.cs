using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Threading.Tasks;

namespace random_name
{
    public partial class Form2 : Form
    {

        string qzx = "郄泽熙";
        string tzl = "唐志蠡";


        public Form2()
        {
            InitializeComponent();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }


        private async void label1_Click(object sender, EventArgs e)
        {
            string text = label1.Text;
            if (timer1.Enabled is false)
            {
                this.Opacity = 1;
                timer1.Start();
            }
            else if (timer1.Enabled is true)
            {
                if (checkBox1.Checked is true)
                {
                    timer1.Stop();
                    this.Opacity = 1;
                    this.label2.Visible = true;
                    bool qzx_result = qzx.Equals(label1.Text);
                    bool tzl_result = tzl.Equals(label1.Text);
                    if (qzx_result)
                    {
                        //接受文本框的文字
                        SpVoice voice1 = new SpVoice();
                        //音量
                        voice1.Volume = 100;
                        //语速
                        voice1.Rate = 1;
                        //朗读内容
                        voice1.Speak("怯泽熙");
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
                        voice1.Speak("唐志里");
                    }
                    else
                    {
                        SpVoice voice = new SpVoice();
                        //音量
                        voice.Volume = 100;
                        //语速
                        voice.Rate = 1;
                        //朗读内容
                        voice.Speak(text);
                    }
                    //接受文本框的文字

                    Form1.name_list.Remove(text);
                    this.label2.Visible = false;
                }
                else if (checkBox1.Checked is false)
                {
                    timer1.Stop();
                    Form1.name_list.Remove(text);
                }
                if (Form1.name_list.Count == 0)
                {
                    MessageBox.Show("所有人已被点过，即将重置名单", "重置名单", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileStream name_stream = new FileStream("./data/list.txt", FileMode.Open);
                    StreamReader name_read = new StreamReader(name_stream, UnicodeEncoding.GetEncoding("utf-8"));
                    while ((Form1.name_sc = name_read.ReadLine()) != null)
                    {
                        Form1.name_list.Add(Form1.name_sc);
                    }
                    name_stream.Close();
                }

                this.Opacity = 1;
                await Task.Delay(10000);
                this.Opacity = 0.3;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Form1.name_list[new Random().Next(Form1.name_list.Count)];
            label2.Text = Form1.name_list[new Random().Next(Form1.name_list.Count)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认退出点名器？", "高二五班点名器（PPT模式）", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                System.Environment.Exit(0);//点确定的代码
            }
            else
            {        
                //点取消的代码        
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void label1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
            await Task.Delay(8000);
            this.Opacity = 0.3;
        }



    }
}
