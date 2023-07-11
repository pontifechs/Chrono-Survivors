using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace terrain
{
    public class InfiniteVerticalWalls : MonoBehaviour, LoadedTerrain
    {
        [SerializeField] TileBase leftWall;
        [SerializeField] TileBase rightWall;

        [SerializeField] int leftWallPos;
        [SerializeField] int rightWallPos;

        private Tilemap tilemap;

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }

        public void LoadArea((int x, int y) min, (int x, int y) max)
        {
            if ((min.x < leftWallPos) && (leftWallPos < max.x))
            {
                for (int j = min.y; j <= max.y; j++)
                {
                    tilemap.SetTile(new Vector3Int(leftWallPos, j), leftWall);
                }
            }
    
            if ((min.x < rightWallPos) && (rightWallPos< max.x))
            {
                 for (int j = min.y; j <= max.y; j++)
                 {
                     tilemap.SetTile(new Vector3Int(rightWallPos, j), rightWall);
                 }               
            }
        }
    }
}
