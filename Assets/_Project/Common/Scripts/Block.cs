using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class Block
    {
        public readonly BlockID blockID;

        public Block(BlockID blockID)
        {
            this.blockID = blockID;
        }
    }
}
