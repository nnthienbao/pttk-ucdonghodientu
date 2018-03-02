using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCDongHoDienTu
{
    public partial class DongHoDienTu : UserControl
    {
        public interface DongHoDienTuListener
        {
            void onTick(int phut, int giay);
        }

        private static int WIDTH_DIGIT = UCDongHoDienTu.Properties.Resources._.Width;

        int phut, giay;
        bool isTick;
        DongHoDienTuListener listener;
        public DongHoDienTu()
        {
            InitializeComponent();
            Giay = 0;
            Phut = 0;
            IsTick = false;
        }

        public int Giay
        {
            get
            {
                return giay;
            }

            set
            {
                giay = value;
            }
        }

        public int Phut
        {
            get
            {
                return phut;
            }

            set
            {
                phut = value;
            }
        }

        public bool IsTick
        {
            get
            {
                return isTick;
            }

            set
            {
                isTick = value;
            }
        }

        public DongHoDienTuListener Listener
        {
            get
            {
                return listener;
            }

            set
            {
                listener = value;
            }
        }

        public void start()
        {
            stop();
            IsTick = true;
        }

        public void stop()
        {
            IsTick = false;
            Phut = 0;
            Giay = 0;
            Invalidate();
        }

        public void pause()
        {
            IsTick = false;
        }

        public void resume()
        {
            IsTick = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsTick)
            {
                this.Giay += 1;
                if (this.Giay > 59)
                {
                    this.Giay = 0;
                    this.Phut += 1;
                    if (this.Phut > 59)
                    {
                        this.Phut = 0;
                    }
                }
                Invalidate();
                listener.onTick(Phut, Giay);
            }
        }

        private void DongHoDienTu_Paint(object sender, PaintEventArgs e)
        {
            drawClock(e.Graphics);
        }

        private void drawClock(Graphics g)
        {
            drawNumber(getDigit(Phut, 1), 0, g);
            drawNumber(getDigit(Phut, 0), 1, g);
            drawDash(2, g);
            drawNumber(getDigit(Giay, 1), 3, g);
            drawNumber(getDigit(Giay, 0), 4, g);
        }

        private void drawDash(int pos, Graphics g)
        {
            g.DrawImage(UCDongHoDienTu.Properties.Resources._, new Point(pos * WIDTH_DIGIT, 0));
        }

        private void drawNumber(int num, int pos, Graphics g)
        {
            g.DrawImage(getNumImage(num), new Point(pos * WIDTH_DIGIT, 0));
        }

        private int getDigit(int num, int pos)
        {
            while(pos > 0)
            {
                num /= 10;
                pos--;
            }

            return num % 10;
        }

        private Image getNumImage(int num)
        {
            switch(num)
            {
                case 0:
                    return UCDongHoDienTu.Properties.Resources._0;
                case 1:
                    return UCDongHoDienTu.Properties.Resources._1;
                case 2:
                    return UCDongHoDienTu.Properties.Resources._2;
                case 3:
                    return UCDongHoDienTu.Properties.Resources._3;
                case 4:
                    return UCDongHoDienTu.Properties.Resources._4;
                case 5:
                    return UCDongHoDienTu.Properties.Resources._5;
                case 6:
                    return UCDongHoDienTu.Properties.Resources._6;
                case 7:
                    return UCDongHoDienTu.Properties.Resources._7;
                case 8:
                    return UCDongHoDienTu.Properties.Resources._8;
                case 9:
                    return UCDongHoDienTu.Properties.Resources._9;
            }
            return null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
