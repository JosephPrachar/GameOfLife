﻿using System;
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
            return curBoardIsOne ? boardOne : boardTwo;
        }
        private int[][] GetBufferBoard()
        {
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
                    next[j][i] = IsAlive(i, j, cur) ? cur[j][i]++ : 0;

            // flip the current board for next frame
            curBoardIsOne = !curBoardIsOne;
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
                if (numAlive != 2 || numAlive != 3)
                    return false;
                else
                    return true;
            }
        }

        private int GetNumSurrounding(int x, int y, int[][] board)
        {
            int toReturn = 0;
            for (int i = y - 1; i <= y + 1; i++)
                for (int j = x - 1; j <= j + 1; j++)
                    if (i >= 0 && j >= 0 && i < height && j < width)
                        if (board[i][j] > 0)
                            toReturn++;
            return toReturn;
        }
    }
}
