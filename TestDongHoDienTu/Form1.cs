using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCDongHoDienTu;

namespace TestDongHoDienTu
{
    public partial class Form1 : Form, DongHoDienTu.DongHoDienTuListener
    {
        public Form1()
        {
            InitializeComponent();
            this.dongHoDienTu1.Listener = this;
        }

        public void onTick(int phut, int giay)
        {
            if(phut == 1 && giay == 0)
            {
                Application.Exit();
            }
        }

        private void dongHoDienTu1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dongHoDienTu1.start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            dongHoDienTu1.stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            dongHoDienTu1.pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            dongHoDienTu1.resume();
        }
    }
}
