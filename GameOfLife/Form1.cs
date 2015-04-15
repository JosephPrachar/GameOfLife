using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();

            game = new Game(null);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                game.RunOne();
                this.Invalidate();
            }
            if (e.KeyCode == Keys.G)
                this.Invalidate();
            if (e.KeyCode == Keys.H)
                game.RunOne();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.DrawBoard(e.Graphics, new Point(20, 20));
        }
    }
}
