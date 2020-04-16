﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//Declaing Each Item
		public static int p1;
		public static int p2;
		public static int p3;

		//Declaring Total, Bet, and Credits
		public static long credits = 100;
		public static long total = 0;
		public static int bet = 5;

		private void Form1_Load( object sender, EventArgs e )
		{
			pictureBox1.Image = Image.FromFile( "2.png" );
			pictureBox2.Image = Image.FromFile( "3.png" );
			pictureBox3.Image = Image.FromFile( "1.png" );
			pictureBox4.Image = Image.FromFile( "slots.png" );

			// Transparent background...  
			pictureBox1.BackColor = Color.Transparent;
			pictureBox2.BackColor = Color.Transparent;
			pictureBox3.BackColor = Color.Transparent;

			// Change parent for overlay PictureBox...
			pictureBox1.Parent = pictureBox4;
			pictureBox2.Parent = pictureBox4;
			pictureBox3.Parent = pictureBox4;

		}

		//Generates Random Numbers
		public static class IntUtil
		{
			private static Random random;
			private static void Init()
			{
				if ( random == null ) random = new Random();
			}

			public static int Random( int min, int max )
			{
				Init();
				return random.Next( min, max );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if ( credits >= bet )
			{
				credits = credits - bet;
				label1.Text = "Credits: " + credits.ToString();

				for ( var i = 0; i < 10; i++ )
				{
					p1 = IntUtil.Random( 1, 4 );
					p2 = IntUtil.Random( 1, 4 );
					p3 = IntUtil.Random( 1, 4 );
				}

				if ( pictureBox1.Image != null ) pictureBox1.Image.Dispose();
				pictureBox1.Image = Image.FromFile( p1.ToString() + ".png" );

				if ( pictureBox2.Image != null ) pictureBox2.Image.Dispose();
				pictureBox2.Image = Image.FromFile( p2.ToString() + ".png" );

				if ( pictureBox1.Image != null ) pictureBox3.Image.Dispose();
				pictureBox3.Image = Image.FromFile( p3.ToString() + ".png" );

				total = 0;

				if ( p1 == 3 ) total = total + 5;
				if ( p1 == 2 & p2 == 2) total = total + 10;
				if ( p1 == 3 & p2 == 3) total = total + 10;
				if ( p1 == 1 & p2 == 1 & p3 == 1) total = total + 20;
				if ( p1 == 2 & p2 == 2 & p3 == 2) total = total + 30;
				if ( p1 == 3 & p2 == 3 & p3 == 3) total = total + 50;

				credits = credits + total;
				label3.Text = "Win: " + total.ToString();
				label1.Text = "Credits: " + credits.ToString();
			}
		}
	}
}
