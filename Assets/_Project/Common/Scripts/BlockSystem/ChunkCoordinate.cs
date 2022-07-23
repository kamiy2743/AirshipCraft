using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    // チャンクの座標
    public class ChunkCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public ChunkCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= World.CHUNK_SIZE) throw new System.Exception("xチャンク座標が不正です: " + x);
            if (y < 0 || y >= World.CHUNK_HEIGHT) throw new System.Exception("yチャンク座標が不正です: " + y);
            if (z < 0 || z >= World.CHUNK_SIZE) throw new System.Exception("zチャンク座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int ToIndex()
        {
            return x + (z * World.CHUNK_SIZE) + (y * World.CHUNK_SIZE * World.CHUNK_SIZE);
        }
    }
}
