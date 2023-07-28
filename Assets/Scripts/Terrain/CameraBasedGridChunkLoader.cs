using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Terrain
{
    public class CameraBasedGridChunkLoader : MonoBehaviour
    {
        private const int ChunkSize = 16; // Must be power of 2
        private const int Padding = 1;
        
        private Grid grid;
        private List<LoadedTerrain> loadees = new();
        private static HashSet<(int, int)> loaded = new();
        
        private void Awake()
        {
            loaded.Clear(); 
            grid = GetComponent<Grid>();
            loadees = GetComponentsInChildren<LoadedTerrain>().ToList();
        }
           
        private (Vector2Int min, Vector2Int max) GetChunkBounds()
        {
            var screenMin = grid.WorldToCell(Utils.ScreenMin_World());
            var screenMax = grid.WorldToCell(Utils.ScreenMax_World());
 
            var bits = (int)Mathf.Sqrt(ChunkSize);
            var chunkMin = new Vector2Int(screenMin.x >> bits, screenMin.y >> bits);
            var chunkMax = new Vector2Int(screenMax.x >> bits, screenMax.y >> bits);

            return (chunkMin, chunkMax);
        }
           
        private void LoadVisible()
        {
            (Vector2Int chunkMin, Vector2Int chunkMax) = GetChunkBounds();
            for (int i = chunkMin.x - Padding; i <= chunkMax.x + Padding; i++)
            {
                for (int j = chunkMin.y - Padding; j <= chunkMax.y + Padding; j++)
                {
                    if (!loaded.Contains((i, j)))
                    {
                        foreach (var loadee in loadees)
                        {
                            var i_cell = i * ChunkSize;
                            var j_cell = j * ChunkSize;
                            loadee.LoadArea((i_cell, j_cell), (i_cell + ChunkSize, j_cell + ChunkSize));
                        }
                        loaded.Add((i, j));
                    }
                }
            }
        }
        
        private void Update()
        {
            (Vector2Int chunkMin, Vector2Int chunkMax) = GetChunkBounds();
            chunkMin -= new Vector2Int(Padding, Padding);
            chunkMax += new Vector2Int(Padding, Padding);
            
            if (!loaded.Contains((chunkMin.x, chunkMin.y)) || !loaded.Contains((chunkMax.x, chunkMax.y)))
            {
                LoadVisible();
            }
        }
    }
}