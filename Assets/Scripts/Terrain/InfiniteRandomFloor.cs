using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Terrain
{
    public class InfiniteRandomFloor : MonoBehaviour, LoadedTerrain
    {
        [SerializeField] private List<TileBase> floorTiles;

        private const float Zoom = .99f;

        private Tilemap tilemap;

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }

        public void LoadArea((int x,int y) min, (int x, int y) max)
        {
            for (int i = min.x; i <= max.x; i++)
            {
                for (int j = min.y; j <= max.y; j++)
                {
                    var tilePosition = new Vector3Int(i, j);
                    
                    // TODO:: Find better way to do this. I don't actually want the smoothness of Perlin here, just the coordinate-ness.
                    var noise = Mathf.PerlinNoise(i * Zoom, j * Zoom);
                    int tile = Mathf.Abs((int)(noise * 1000000)) % 4;
                    
                    tilemap.SetTile(tilePosition, floorTiles[tile]);
                }
            }
        }
    }
}