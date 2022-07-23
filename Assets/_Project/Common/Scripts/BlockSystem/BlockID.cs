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
    }
}
