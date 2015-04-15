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
        private byte currentBoard = 0;

        public Board(int[][] startingState)
        {

        }

        public void Simulate()
        {
            // call simulate(x, y) for each cell
        }

        private void Simulate(int x, int y)
        {
            // computes the life or death of the current board via counting surrounding cells
        }

        private int[] GetSurrounding(int x, int y)
        {
            return null;
        }

        private void Copy(int[][] from, int[][] to)
        {
            
        }
    }
}
