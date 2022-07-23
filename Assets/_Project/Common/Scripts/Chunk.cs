using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class Chunk
    {
        public const int SIZE = 16;
        public const int HEIGHT = 64;

        private Block[] blocks = new Block[SIZE * SIZE * HEIGHT];

        private Block GetBlock(LocalCoordinate coordinate)
        {
            return blocks[coordinate.ToIndex()];
        }

        private void SetBlock(LocalCoordinate coordinate, Block block)
        {
            blocks[coordinate.ToIndex()] = block;
        }
    }
}
