using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform[,] grid;

    [SerializeField] 
    private Transform emptySprite;

    [SerializeField]
    private int height = 30, width = 10, header = 8;

    private void Awake()
    {
        grid = new Transform[width, height];
    }

    Vector2 pos;

    private void Start()
    {
        CreateBoard();
    }


    void CreateBoard()
    {
        if (emptySprite)
        {
            for (int y = 0; y < height - header; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Transform clone = Instantiate(emptySprite, new Vector3(x, y, 0), Quaternion.identity);

                    clone.transform.parent = transform;
                }
            }

        }
    }

   public bool CheckPosition(BlockScript block)
    {
        foreach (Transform item in block.transform)
        {
            pos = RoundingScript.Round(item.position);



            if (!BoardOutCheck((int)pos.x, (int)pos.y))
            {
                return false;
            }

            if (BlockCheck((int)pos.x, (int)pos.y, block))
            {
                return false;
            }
        }
        return true;    
    }

    
	


    bool BoardOutCheck(int x,int y)
    {
        return (x >= 0 && x < width && y >= 0);
    }


    bool BlockCheck(int x, int y,BlockScript block)
    {
        return (grid[x, y] != null && grid[x,y].parent != block.transform);
    }


    public void SaveBlockInGrid(BlockScript block)
    {
        foreach (Transform item in block.transform)
        {
            pos = RoundingScript.Round(item.position);

            grid[(int)pos.x, (int)pos.y] = item;
        }
    }

    public void ClearAllRows()
    {
        for (int y = 0; y < height; y++)
        {
            if (IsComplete(y))
            {
                ClearRow(y);

                ShiftRowsDown(y + 1);

                y--;
            }
        }
    }

    bool IsComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }

    void ClearRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                Destroy(grid[x, y].gameObject);
                Debug.Log("block");
            }
            grid[x,y] = null;
        }
    }

    void ShiftRowsDown(int startY)
    {
        for (int y = startY; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x,y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x,y] = null;
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

   public bool OverLimit(BlockScript block)
    {
        foreach(Transform item in block.transform)
        {
            if (item.transform.position.y >= height -header)
            {
                return true;
            }
        }

        return false;
    }
}
