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

        public override string ToString()
        {
            return $"ChunkCoordinate({x}, {y}, {z})";
        }

        public override bool Equals(object obj) => this.Equals(obj as ChunkCoordinate);

        public bool Equals(ChunkCoordinate other)
        {
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (this.x != other.x) return false;
            if (this.y != other.y) return false;
            if (this.z != other.z) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
