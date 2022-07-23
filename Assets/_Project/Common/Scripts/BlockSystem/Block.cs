using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class Block
    {
        public readonly BlockID blockID;

        public static Block Empty => _empty ??= new Block(new BlockID(0));
        private static Block _empty;

        public Block(BlockID blockID)
        {
            this.blockID = blockID;
        }
    }
}
