using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class LocalCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public LocalCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= Chunk.SIZE) throw new System.Exception("x座標が不正です: " + x);
            if (y < 0 || y >= Chunk.HEIGHT) throw new System.Exception("y座標が不正です: " + y);
            if (z < 0 || z >= Chunk.SIZE) throw new System.Exception("z座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int ToIndex()
        {
            return x + (z * Chunk.SIZE) + (y * Chunk.SIZE * Chunk.SIZE);
        }
    }
}
