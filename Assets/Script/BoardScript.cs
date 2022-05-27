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

        }

        if (!BoardOutCheck((int)pos.x, (int)pos.y))
        {
            return false;
        }

        if (BlockCheck((int)pos.x, (int)pos.y,block))
        {
            return false;
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
            Vector2 pos = RoundingScript.Round(item.position);

            grid[(int)pos.x, (int)pos.y] = item;
        }
    }
}
