using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Turret;
    public GameObject WhiteTile;
    public GameObject BlackTile;
    public GameObject SpawnPoint;
    public GameObject DestPoint;

    [Header("Tiles parent")]
    public Transform parentObject;
    public string parentLayerName = "Environment";

    public static List<Vector3> PathTiles;
    public static Vector3 spawnPoint;
    public static Vector3 destPoint;
    private int mapSize = 16;

    private int[,] matrix;
    private List<int> valid_moves = new List<int>();

    void Start()
    {
        matrix = new int[mapSize, mapSize];
        GeneratePath();
    }

    private void GeneratePath()
    {
        CreatePath();

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (matrix[i, j] == 0)
                {
                    GameObject whiteTile = (GameObject)Instantiate(WhiteTile, new Vector3(i, 0, j), Quaternion.identity);
                    whiteTile.transform.parent = parentObject;
                    whiteTile.layer = LayerMask.NameToLayer(parentLayerName);
                }
                    
                else
                {
                    GameObject blackTile = (GameObject)Instantiate(BlackTile, new Vector3(i, 0, j), Quaternion.identity);
                    blackTile.transform.parent = parentObject;
                    blackTile.layer = LayerMask.NameToLayer(parentLayerName);
                }
            }
        }

        GameObject spawnPointGO = (GameObject)Instantiate(SpawnPoint, spawnPoint, Quaternion.identity);
        spawnPointGO.transform.parent = parentObject;
        spawnPointGO.layer = LayerMask.NameToLayer(parentLayerName);

        GameObject destPointGO = (GameObject)Instantiate(DestPoint, destPoint, Quaternion.identity);
        destPointGO.transform.parent = parentObject;
        destPointGO.layer = LayerMask.NameToLayer(parentLayerName);
    }

    private void CreatePath()
    {
        PathTiles = new List<Vector3>();

        System.Random random = new System.Random();
        int row = 1;
        int column = random.Next(mapSize / 4, mapSize / 4 * 3);

        matrix[row, column] = 1;
        spawnPoint = new Vector3(row, 0.6125f, column);

        while (row < mapSize - 2)
        {
            /* The frontier contains all legal moves to make from the current position*/
            CreateNewFrontier(row, column);

            /* Select random one move */
            int index = random.Next(0, valid_moves.Count / 2);

            row = valid_moves[index * 2];
            column = valid_moves[index * 2 + 1];

            matrix[row, column] = 1;
            PathTiles.Add(new Vector3(row, 0.4f, column));
        }
        destPoint = new Vector3(row, 0.6125f, column);
    }

    private void CreateNewFrontier(int row, int column)
    {
        valid_moves.Clear();

        if (column + 3 < mapSize)
            AddToFrontier(row, column + 1);
        if (column - 3 >= 0)
            AddToFrontier(row, column - 1);
        if (row + 1 < mapSize)
            AddToFrontier(row + 1, column);
    }

    /* No node to be added in the frontier can touch more than 2 nodes on any cardinal direction */
    private void AddToFrontier(int row, int column)
    {
        /* Making sure that the current position is not already on the path*/
        if (matrix[row, column] == 0)
        {
            int markedNeighbors = 0;

            if (row - 1 >= 0 && matrix[row - 1, column] == 1)
                markedNeighbors += 1;

            if (row + 1 < mapSize && matrix[row + 1, column] == 1)
                markedNeighbors += 1;

            if (column - 1 >= 0 && matrix[row, column - 1] == 1)
                markedNeighbors += 1;

            if (column + 1 < mapSize && matrix[row, column + 1] == 1)
                markedNeighbors += 1;

            if (markedNeighbors < 2)
            {
                valid_moves.Add(row);
                valid_moves.Add(column);
            }
        }
    }
}
