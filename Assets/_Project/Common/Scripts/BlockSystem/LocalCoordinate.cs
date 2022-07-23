using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    // チャンク内のブロックの座標
    public class LocalCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public LocalCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= Chunk.SIZE) throw new System.Exception("x座標が不正です: " + x);
            if (y < 0 || y >= Chunk.SIZE) throw new System.Exception("y座標が不正です: " + y);
            if (z < 0 || z >= Chunk.SIZE) throw new System.Exception("z座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int ToIndex()
        {
            return x + (z * Chunk.SIZE) + (y * Chunk.SIZE * Chunk.SIZE);
        }

        public override string ToString()
        {
            return $"LocalCoordinate({x}, {y}, {z})";
        }

        public override bool Equals(object obj) => this.Equals(obj as LocalCoordinate);

        public bool Equals(LocalCoordinate other)
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
