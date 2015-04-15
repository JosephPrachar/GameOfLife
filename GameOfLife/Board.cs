using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Board
    {
        private int[][] boardOne;
        private int[][] boardTwo;
        private bool curBoardIsOne = true;

        private int width;
        private int height;

        public Board(int[][] startingState)
        {
            boardOne = startingState;
            width = boardOne[0].Length;
            height = boardOne.Length;

            boardTwo = new int[height][];
            for (int i = 0; i < height; i++)
            {
                boardTwo[i] = new int[width];
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

        public int GetCell(int x, int y)
        {
            return GetCurrentBoard()[y][x];
        }

        private int[][] GetCurrentBoard()
        {
            //return boardOne;
            return curBoardIsOne ? boardOne : boardTwo;
        }
        private int[][] GetBufferBoard()
        {
            //return boardTwo;
            return curBoardIsOne ? boardTwo : boardOne;
        }

        // call simulate(x, y) for each cell
        public void Simulate()
        {    
            // set the current array and the one to fill
            int[][] cur = GetCurrentBoard();
            int[][] next = GetBufferBoard();

            // compute the status of each cell in cur and put the result in next
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    next[i][j] = IsAlive(j, i, cur) ? cur[i][j] + 1 : 0;

            // clear the board for use as the next buffer
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    cur[i][j] = 0;

            // flip the current board for next frame
            curBoardIsOne = !curBoardIsOne;

            //Copy(boardTwo, boardOne);
        }

        private bool IsAlive(int x, int y, int[][] board)
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

        private int GetNumSurrounding(int x, int y, int[][] board)
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

        private void Copy(int[][] from, int[][] to)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    to[i][j] = from[i][j];
        }
    }
}
