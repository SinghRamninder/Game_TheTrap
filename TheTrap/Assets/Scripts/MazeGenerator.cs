using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
    public int rows = 22;
    public int columns = 12;
    private int maxplates;
    private bool[,] maze;
    public Tilemap tilemap;
    public TileBase[] wall;
    public GameObject plateprefab;
    public Transform tilemapparent;

    private void Start()
    {
        maze = new bool[rows, columns];
        maxplates = Random.Range(10, rows);
        mazeGenerator();
        DrawMaze();
    }

    private void Update()
    {
        GameObject[] plates = GameObject.FindGameObjectsWithTag("Plate");

        if (plates.Length < 15)
        {
            DrawPlates();
        }
    }

    void mazeGenerator()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                maze[r, c] = false;
            }
        }

        Vector2Int start = new Vector2Int(0, Random.Range(0, columns));
        Vector2Int init = new Vector2Int(1, Random.Range(0, columns));
        Vector2Int end = new Vector2Int(rows - 1, Random.Range(0, columns));
            maze[start.x, start.y] = true;
            maze[init.x, init.y] = true;
            maze[end.x, end.y] = true;

        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(init);

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            List<Vector2Int> possible = neighborscheck(current);

            if (possible.Count > 0)
            {
                Vector2Int chosenNeighbor = possible[Random.Range(0, possible.Count)];
                Vector2Int path = (current + chosenNeighbor) / 2;

                maze[path.x, path.y] = true;
                maze[chosenNeighbor.x, chosenNeighbor.y] = true;

                stack.Push(chosenNeighbor);
            }
            else
            {
                stack.Pop();
            }
        }

        bool upanddownwall = mazechecker();

        if (!maze[start.x + 1, start.y] || !maze[end.x - 1, end.y] || !upanddownwall)
        {
            mazeGenerator();
        }

    }

    List<Vector2Int> neighborscheck(Vector2Int current)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        Vector2Int[] directions = { new Vector2Int(0, -2), new Vector2Int(0, 2), new Vector2Int(2, 0), new Vector2Int(-2, 0) };

        foreach (Vector2Int dir in directions)
        {
            Vector2Int probneighbor = current + dir;
            if (probneighbor.x >= 0 && probneighbor.x < rows && probneighbor.y >= 0 && probneighbor.y < columns && !maze[probneighbor.x, probneighbor.y])
            {
                neighbors.Add(probneighbor);
            }
        }

        return neighbors;
    }

    bool mazechecker()
    {

        for (int x = 1; x < rows; x++)
        {
            if (maze[x, 0])
            {
                return false;
            }
        }

        return true;

    }

    void DrawMaze()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (!maze[r, c])
                {
                    int i = Random.Range(0, wall.Length);
                    Vector3Int position = new Vector3Int(r, c, 0);
                    tilemap.SetTile(position, wall[i]);
                }
            }
        }

        DrawPlates();
    }

    void DrawPlates()
    {
        for (int i = 0; i < rows + 5; i++)
        {
            int r = Random.Range(0, rows);
            int c = Random.Range(0, columns);

            if (maze[r, c])
            {
                Vector3 worldpas = tilemap.CellToWorld(new Vector3Int(r, c, 0)) + new Vector3(0.9f, 0.9f, 0);
                Instantiate(plateprefab, worldpas, Quaternion.identity, tilemapparent);
            }
        }
    }
}
