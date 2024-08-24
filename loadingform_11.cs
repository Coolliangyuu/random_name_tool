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

namespace 点名器
{
    public partial class loadingform_11 : Form
    {
        public loadingform_11()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(10);
            new dmqform1_11().Show();
            this.Hide();
        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
