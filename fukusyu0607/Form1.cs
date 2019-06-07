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
		int vx3 = rand.Next(-10, 11);
		int vy3 = rand.Next(-10, 11);
		int vx4 = rand.Next(-10, 11);
		int vy4 = rand.Next(-10, 11);
		int time = 100 * 5;
		int left = 3;

		public Form1()
		{
			InitializeComponent();

			// 以下に、label1.Leftとlabel1.Topの座標をランダムで求めよ
			label1.Left = rand.Next(ClientSize.Width - label1.Width);
			label1.Top = rand.Next(ClientSize.Height - label1.Height);

			label3.Left = rand.Next(ClientSize.Width - label3.Width);
			label3.Top = rand.Next(ClientSize.Height - label3.Height);
			label4.Left = rand.Next(ClientSize.Width - label4.Width);
			label4.Top = rand.Next(ClientSize.Height - label4.Height);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Left += vx;
			label1.Top += vy;

			label3.Left += vx3;
			label3.Top += vy3;

			label4.Left += vx4;
			label4.Top += vy4;

			// マウスと重なった時、タイマーを止める
			Point p = PointToClient(MousePosition);

			if ((p.X >= label1.Left)
				&& (p.X < label1.Right)
				&& (p.Y >= label1.Top)
				&& (p.Y < label1.Bottom)
				&& label1.Visible
				)
			{
				left--;
				label1.Visible = false;
				if (left <= 0)
				{
					timer1.Enabled = false;
				}
			}

			if ((p.X >= label3.Left)
	&& (p.X < label3.Right)
	&& (p.Y >= label3.Top)
	&& (p.Y < label3.Bottom)
				&& label3.Visible
	)
			{
				left--;
				label3.Visible = false;
				if (left <= 0)
				{
					timer1.Enabled = false;
				}
			}

			if ((p.X >= label4.Left)
	&& (p.X < label4.Right)
	&& (p.Y >= label4.Top)
	&& (p.Y < label4.Bottom)
				&& label4.Visible
	)
			{
				left--;
				label4.Visible = false;
				if (left <= 0)
				{
					timer1.Enabled = false;
				}
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

			// 左で跳ね仮り(Math.Abs(vx)で、vxの絶対値)
			if (label3.Left < 0)
			{
				vx3 = Math.Abs(vx3);
			}
			// 上で跳ね返り
			if (label3.Top < 0)
			{
				vy3 = Math.Abs(vy3);
			}
			// 右で跳ね仮り
			//// フォームの右端 = ClientSize.Width
			//// ラベルの右端 = label1.Right
			if (label3.Right > ClientSize.Width)
			{
				vx3 = -Math.Abs(vx3);
			}
			// 下で跳ね仮り
			if (label3.Bottom > ClientSize.Height)
			{
				vy3 = -Math.Abs(vy3);
			}


			// 左で跳ね仮り(Math.Abs(vx)で、vxの絶対値)
			if (label4.Left < 0)
			{
				vx4 = Math.Abs(vx4);
			}
			// 上で跳ね返り
			if (label4.Top < 0)
			{
				vy4 = Math.Abs(vy4);
			}
			// 右で跳ね仮り
			//// フォームの右端 = ClientSize.Width
			//// ラベルの右端 = label1.Right
			if (label4.Right > ClientSize.Width)
			{
				vx4 = -Math.Abs(vx4);
			}
			// 下で跳ね仮り
			if (label4.Bottom > ClientSize.Height)
			{
				vy4 = -Math.Abs(vy4);
			}

			time--;
			label2.Text = "Time: " + time;
		}
	}
}