using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameOfLife
{
    class Game
    {
        Board board;

        public Game(int[][] initialState)
        {
            Random r = new Random();

            int height = 10;
            int width = 10;

            initialState = new int[height][];
            for (int i = 0; i < height; i++)
            {
                initialState[i] = new int[width];
                for (int j = 0; j < width; j++)
                    //initialState[i][j] = r.Next(0, 2);
                    initialState[i][j] = 0;
            }

            int[][] a = initialState;

            a[5][2] = 1;
            a[5][3] = 1;
            a[5][4] = 1;

            board = new Board(initialState);
        }

        public void RunOne()
        {
            // run one frame of the simulation
            board.Simulate();

            // record statistics
        }

        public void DrawBoard(Graphics g, Point offset)
        {
            // draws the board

            g.Clear(Color.White);

            int cellWidth = 20;
            int cellHeight = 20;

            Pen b = new Pen(Color.Black);
            SolidBrush black = new SolidBrush(Color.Black);

            g.DrawRectangle(b, new Rectangle(offset, new Size(board.Width * cellWidth, board.Height * cellHeight)));

            for (int i = 0; i < board.Height; i++)
                g.DrawLine(b, offset.X, offset.Y + i * cellHeight, offset.X + board.Width * cellWidth, offset.Y + i * cellHeight);
            
            for (int i = 0; i < board.Width; i++)
                g.DrawLine(b, offset.X + i * cellWidth, offset.Y, offset.X + i * cellWidth, offset.Y + board.Height * cellHeight);


            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.GetCell(j, i) > 0)
                    {
                        g.FillRectangle(black, new Rectangle(
                            j * cellWidth + offset.X, i * cellHeight + offset.Y, cellWidth, cellHeight));
                    }
                }

            }

            black.Dispose();
            b.Dispose();
        }
    }
}
