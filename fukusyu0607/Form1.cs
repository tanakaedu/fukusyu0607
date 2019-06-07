using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukusyu0607
{
	public partial class Form1 : Form
	{
		// 疑似乱数
		// ランダムのシード(種)を指定して初期化したら、
		// それを使い続ける。
		private static Random rand = new Random();
		int vx = rand.Next(-10, 11);
		int vy = rand.Next(-10, 11);
		int time = 100*5;

		public Form1()
		{
			InitializeComponent();

			// 以下に、label1.Leftとlabel1.Topの座標をランダムで求めよ

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Left += vx;
			label1.Top += vy;

			// マウスと重なった時、タイマーを止める
			Point p = PointToClient(MousePosition);

			if (	(p.X >= label1.Left)
				&&	(p.X < label1.Right)
				&&	(p.Y >= label1.Top)
				&&	(p.Y < label1.Bottom)
				)
			{
				timer1.Enabled = false;
			}

			// 左で跳ね仮り(Math.Abs(vx)で、vxの絶対値)
			if (label1.Left < 0)
			{
				vx = Math.Abs(vx);
			}
			// 上で跳ね返り
			if (label1.Top < 0)
			{
				vy = Math.Abs(vy);
			}
			// 右で跳ね仮り
			//// フォームの右端 = ClientSize.Width
			//// ラベルの右端 = label1.Right
			if (label1.Right > ClientSize.Width)
			{
				vx = -Math.Abs(vx);
			}
			// 下で跳ね仮り
			if (label1.Bottom > ClientSize.Height)
			{
				vy = -Math.Abs(vy);
			}

			time--;
			label2.Text = "Time: " + time;
		}
	}
}
