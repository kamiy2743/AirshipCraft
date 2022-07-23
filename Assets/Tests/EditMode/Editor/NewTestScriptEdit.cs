using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BlockSystem;

public class NewTestScriptEdit
{
    // A Test behaves as an ordinary method
    [Test]
    public void SetしたブロックをGetでアクセスできるか()
    {
        var chunk = new Chunk();
        var block = new Block(new BlockID(0));
        var lc = new LocalCoordinate(0, 0, 0);
        chunk.SetBlock(lc, block);
        Assert.AreEqual(block, chunk.GetBlock(lc));
    }

    [Test]
    public void チャンク内すべてのブロックにアクセス()
    {
        var chunk = new Chunk();

        for (int x = 0; x < Chunk.SIZE; x++)
        {
            for (int z = 0; z < Chunk.SIZE; z++)
            {
                for (int y = 0; y < Chunk.SIZE; y++)
                {
                    var block = chunk.GetBlock(new LocalCoordinate(x, y, z));
                }
            }
        }

        Assert.Pass();
    }
}
