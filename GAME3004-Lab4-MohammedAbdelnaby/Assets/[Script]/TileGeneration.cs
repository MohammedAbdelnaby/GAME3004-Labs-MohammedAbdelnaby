using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField]
    private Vector2 GridSize;

    [SerializeField]
    private List<GameObject> Tiles;

    [SerializeField]
    private Vector2 TileSize;

    [SerializeField]
    private Transform TileParent;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int z = 0; z < GridSize.x; z++)
        {
            for (int x = 0; x < GridSize.y; x++)
            {
                int random = Random.Range(0, Tiles.Count);
                GameObject.Instantiate(Tiles[random],                                       //Tile
                                       new Vector3(TileSize.x * x, 0.0f, TileSize.y * z),   //Grid position
                                       Quaternion.identity,                                 //Rotation
                                       TileParent);                                         //Parent
            }
        }
    }
}
