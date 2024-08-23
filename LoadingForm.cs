using random_name;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 高三五班点名器
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(10);
            new Form1().Show();
            this.Hide();
        }
    }
}
