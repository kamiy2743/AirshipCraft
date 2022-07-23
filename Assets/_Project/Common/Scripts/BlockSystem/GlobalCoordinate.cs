using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    // ワールドで一意なブロックの座標
    public class GlobalCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public readonly ChunkCoordinate chunkCoordinate;
        public readonly LocalCoordinate localCoordinate;

        public GlobalCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= World.SIZE) throw new System.Exception("x座標が不正です: " + x);
            if (y < 0 || y >= World.HEIGHT) throw new System.Exception("y座標が不正です: " + y);
            if (z < 0 || z >= World.SIZE) throw new System.Exception("z座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;

            chunkCoordinate = new ChunkCoordinate(
                Mathf.FloorToInt(x / Chunk.SIZE),
                Mathf.FloorToInt(y / Chunk.SIZE),
                Mathf.FloorToInt(z / Chunk.SIZE));

            localCoordinate = new LocalCoordinate(
                x - (chunkCoordinate.x * Chunk.SIZE),
                y - (chunkCoordinate.y * Chunk.SIZE),
                z - (chunkCoordinate.z * Chunk.SIZE));
        }

        public static GlobalCoordinate FromVector3(Vector3 vec)
        {
            return new GlobalCoordinate((int)vec.x, (int)vec.y, (int)vec.z);
        }

        public override string ToString()
        {
            return $"GlobalCoordinate({x}, {y}, {z})";
        }

        public override bool Equals(object obj) => this.Equals(obj as GlobalCoordinate);

        public bool Equals(GlobalCoordinate other)
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
