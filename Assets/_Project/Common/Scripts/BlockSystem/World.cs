using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class World
    {
        // チャンク単位でのワールドの大きさ
        public const int CHUNK_RADIUS = 4;
        public const int CHUNK_SIZE = CHUNK_RADIUS * 2 + 1;
        public const int CHUNK_HEIGHT = 4;

        // ブロック単位でのワールドの大きさ
        public const int SIZE = CHUNK_SIZE * Chunk.SIZE;
        public const int HEIGHT = CHUNK_HEIGHT * Chunk.SIZE;

        private Chunk[] chunks = new Chunk[CHUNK_SIZE * CHUNK_SIZE * CHUNK_HEIGHT];

        public World()
        {
            ChunkIterator((x, y, z) =>
            {
                SetChunk(new ChunkCoordinate(x, y, z), new Chunk());
            });
        }

        private Chunk GetChunk(ChunkCoordinate cc)
        {
            return chunks[cc.ToIndex()];
        }

        private void SetChunk(ChunkCoordinate cc, Chunk chunk)
        {
            chunks[cc.ToIndex()] = chunk;
        }

        public Block GetBlock(GlobalCoordinate gc)
        {
            var chunk = GetChunk(gc.chunkCoordinate);
            var block = chunk.GetBlock(gc.localCoordinate);
            return block;
        }

        public void SetBlock(GlobalCoordinate gc, Block block)
        {
            var chunk = GetChunk(gc.chunkCoordinate);
            chunk.SetBlock(gc.localCoordinate, block);
        }

        public void ChunkIterator(
            System.Action<int, int, int> action,
            int xs = 0,
            int xe = CHUNK_SIZE,
            int ys = 0,
            int ye = CHUNK_HEIGHT,
            int zs = 0,
            int ze = CHUNK_SIZE)
        {
            for (int y = ys; y < ye; y++)
                for (int z = zs; z < ze; z++)
                    for (int x = xs; x < xe; x++)
                        action(x, y, z);
        }

        public void BlockIterator(
            System.Action<int, int, int> action,
            int xs = 0,
            int xe = SIZE,
            int ys = 0,
            int ye = HEIGHT,
            int zs = 0,
            int ze = SIZE)
        {
            for (int y = ys; y < ye; y++)
                for (int z = zs; z < ze; z++)
                    for (int x = xs; x < xe; x++)
                        action(x, y, z);
        }
    }
}
