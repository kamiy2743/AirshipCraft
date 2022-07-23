using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class Chunk
    {
        public const int SIZE = 16;

        private Block[] blocks = new Block[SIZE * SIZE * SIZE];

        public Chunk()
        {
            BlockIterator((x, y, z) =>
            {
                SetBlock(new LocalCoordinate(x, y, z), Block.Empty);
            });
        }

        public Block GetBlock(LocalCoordinate lc)
        {
            return blocks[lc.ToIndex()];
        }

        public void SetBlock(LocalCoordinate lc, Block block)
        {
            blocks[lc.ToIndex()] = block;
        }

        public void BlockIterator(
            System.Action<int, int, int> action,
            int xs = 0,
            int xe = SIZE,
            int ys = 0,
            int ye = SIZE,
            int zs = 0,
            int ze = SIZE)
        {
            for (int y = ys; y < ye; y++)
                for (int z = zs; z < ze; z++)
                    for (int x = xs; x < xe; x++)
                        action(x, y, z);
        }
    }
}
