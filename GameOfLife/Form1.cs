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
            sbHistory.Minimum = 0;

            game = new Game(null);
            sbHistory.Maximum = game.GetNumberOfBoards();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (sbHistory.Value == sbHistory.Maximum - 1)
                {
                    game.RunOne();
                    sbHistory.Maximum = game.GetNumberOfBoards();
                    sbHistory.Value++;
                }
                else
                    sbHistory.Value++;
            }
            if (e.KeyCode == Keys.G)
                this.Invalidate();
            if (e.KeyCode == Keys.H)
                game.RunOne();

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.DrawBoard(e.Graphics, new Point(20, 40), sbHistory.Value);
        }

        private void sbHistory_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void sbHistory_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_KeyDown(sender, e);
        }
    }
}
