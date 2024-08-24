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
using static System.Net.Mime.MediaTypeNames;

namespace random_name
{
    public partial class dmqform2_11 : Form
    {

        string qzx = "郄泽熙";
        string tzl = "唐志蠡";


        public dmqform2_11()
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

                    
                    this.label2.Visible = false;
                }
                else if (checkBox1.Checked is false)
                {
                    timer1.Stop();
                    
                }
                if (dmqform1_11.name_list.Count == 0)
                {
                    MessageBox.Show("所有人已被点过，即将重置名单", "重置名单", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileStream name_stream = new FileStream("./data/list.txt", FileMode.Open);
                    StreamReader name_read = new StreamReader(name_stream, UnicodeEncoding.GetEncoding("utf-8"));
                    while ((dmqform1_11.name_sc = name_read.ReadLine()) != null)
                    {
                        dmqform1_11.name_list.Add(dmqform1_11.name_sc);
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
            label1.Text = dmqform1_11.name_list[new Random().Next(dmqform1_11.name_list.Count)];
            label2.Text = dmqform1_11.name_list[new Random().Next(dmqform1_11.name_list.Count)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("返回标准模式？", "点名器（PPT模式）", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Hide();
                //点确定的代码
            }
            else
            {
                //点取消的代码        
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dr = MessageBox.Show("退出点名器？", "点名器（PPT模式）", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                System.Environment.Exit(0);
                //点确定的代码
            }
            else
            {
                e.Cancel = true;
                //点取消的代码        
            }
        }

        private async void Form2_MouseEnter(object sender, EventArgs e)
        {
        }

        private async void label1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
            await Task.Delay(8000);
            this.Opacity = 0.3;
        }
    }
}
