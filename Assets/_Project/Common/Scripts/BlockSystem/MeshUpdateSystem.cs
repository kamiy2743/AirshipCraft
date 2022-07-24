using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class MeshUpdateSystem : MonoBehaviour
    {
        private const int UPDATE_CHUNK_RADIUS = 2;

        private ChunkCoordinate currentPlayerChunk;
        private ChunkCoordinate lastPlayerChunk;

        private Queue<ChunkCoordinate> updateChunkQueue = new Queue<ChunkCoordinate>();

        void Update()
        {
            UpdatePlayerChunk();

            if (currentPlayerChunk.Equals(lastPlayerChunk)) return;

            SelectUpdateChunks();
        }

        private void UpdatePlayerChunk()
        {
            lastPlayerChunk = currentPlayerChunk;

            // TODO プレイヤーから取得するようにする
            currentPlayerChunk = new ChunkCoordinate(2, 0, 2);
        }

        private void SelectUpdateChunks()
        {
            var pc = currentPlayerChunk;
            AddUpdateChunk(pc);

            for (int r = 1; r <= UPDATE_CHUNK_RADIUS; r++)
            {
                for (int x = pc.x - r; x < pc.x + r; x++)
                {
                    if (ChunkCoordinate.TryValidationCheck(x, pc.y, pc.z + r, out ChunkCoordinate cc))
                    {
                        AddUpdateChunk(cc);
                    }
                }
                for (int z = pc.z + r; z > pc.z - r; z--)
                {
                    if (ChunkCoordinate.TryValidationCheck(pc.x + r, pc.y, z, out ChunkCoordinate cc))
                    {
                        AddUpdateChunk(cc);
                    }
                }
                for (int x = pc.x + r; x > pc.x - r; x--)
                {
                    if (ChunkCoordinate.TryValidationCheck(x, pc.y, pc.z - r, out ChunkCoordinate cc))
                    {
                        AddUpdateChunk(cc);
                    }
                }
                for (int z = pc.z - r; z < pc.z + r; z++)
                {
                    if (ChunkCoordinate.TryValidationCheck(pc.x - r, pc.y, z, out ChunkCoordinate cc))
                    {
                        AddUpdateChunk(cc);
                    }
                }
            }
        }

        private void AddUpdateChunk(ChunkCoordinate cc)
        {
            if (updateChunkQueue.Contains(cc)) return;

            updateChunkQueue.Enqueue(cc);
        }
    }
}
