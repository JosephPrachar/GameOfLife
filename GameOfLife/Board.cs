using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Board
    {
        private List<byte[][]> boards;

        private int width;
        private int height;

        public Board(byte[][] startingState)
        {
            boards = new List<byte[][]>();
            boards.Add(startingState);

            width = startingState[0].Length;
            height = startingState.Length;
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public int NumOfBoards
        {
            get { return boards.Count; }
        }

        public byte GetCell(int x, int y)
        {
            return GetCurrentBoard()[y][x];
        }
        public byte GetCell(int x, int y, int boardIndex)
        {
            return boards[boardIndex][y][x];
        }

        private byte[][] GetCurrentBoard()
        {
            return boards[boards.Count - 1];
        }

        public void Simulate()
        {    
            // set the current array and the one to fill
            byte[][] cur = GetCurrentBoard();
            byte[][] next = NewBoard();

            // compute the status of each cell in cur and put the result in next
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    next[i][j] = IsAlive(j, i, cur) ? (byte)(cur[i][j] + 1) : (byte)0;

            boards.Add(next);
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

        private byte[][] NewBoard()
        {
            byte[][] toReturn = new byte[height][];
            for (int i = 0; i < height; i++)
            {
                toReturn[i] = new byte[width];
                for (int j = 0; j < width; j++)
                    toReturn[i][j] = 0;
            }
            return toReturn;
        }
    }
}
