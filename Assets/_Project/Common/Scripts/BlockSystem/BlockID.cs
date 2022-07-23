using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class BlockID
    {
        public readonly int value;
        private const int MAX = 64;

        public BlockID(int value)
        {
            if (value < 0 || value >= MAX) throw new System.Exception("ブロックIDが不正です: " + value);

            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override bool Equals(object obj) => this.Equals(obj as BlockID);

        public bool Equals(BlockID other)
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

            return this.value == other.value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
