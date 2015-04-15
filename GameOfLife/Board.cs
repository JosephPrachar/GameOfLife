using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Board
    {
        private byte[][] boardOne;
        private byte[][] boardTwo;
        private bool curBoardIsOne = true;

        private int width;
        private int height;

        public Board(byte[][] startingState)
        {
            boardOne = startingState;
            width = boardOne[0].Length;
            height = boardOne.Length;

            boardTwo = new byte[height][];
            for (int i = 0; i < height; i++)
            {
                boardTwo[i] = new byte[width];
                for (int j = 0; j < width; j++)
                    boardTwo[i][j] = 0;
            }
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public byte GetCell(int x, int y)
        {
            return GetCurrentBoard()[y][x];
        }

        private byte[][] GetCurrentBoard()
        {
            return curBoardIsOne ? boardOne : boardTwo;
        }
        private byte[][] GetBufferBoard()
        {
            return curBoardIsOne ? boardTwo : boardOne;
        }

        public void Simulate()
        {    
            // set the current array and the one to fill
            byte[][] cur = GetCurrentBoard();
            byte[][] next = GetBufferBoard();

            // compute the status of each cell in cur and put the result in next
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    next[i][j] = IsAlive(j, i, cur) ? (byte)(cur[i][j] + 1) : (byte)0;

            // clear the board for use as the next buffer
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    cur[i][j] = 0;

            // flip the current board for next frame
            curBoardIsOne = !curBoardIsOne;
        }

        private bool IsAlive(int x, int y, byte[][] board)
        {
            // computes the life or death of the current board via counting surrounding cells
            int numAlive = GetNumSurrounding(x, y, board);

             if (board[y][x] == 0) // cell is dead
            {
                if (numAlive == 3)
                    return true;
                else
                    return false;
            }
            else // cell is alive
            {
                if (numAlive == 2 || numAlive == 3)
                    return true;
                else
                    return false;
            }
        }

        private int GetNumSurrounding(int x, int y, byte[][] board)
        {
            int toReturn = 0;
            for (int i = y - 1; i <= y + 1; i++)
                for (int j = x - 1; j <= x + 1; j++)
                    if (i >= 0 && j >= 0 && i < height && j < width)
                        if (board[i][j] > 0)
                            toReturn++;

            if (board[y][x] > 0)
                toReturn--;
            return toReturn;
        }
    }
}
