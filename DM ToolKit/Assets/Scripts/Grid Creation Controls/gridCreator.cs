using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCreator : MonoBehaviour
{
    [HideInInspector]
    public int gridWidth;
    [HideInInspector]
    public int gridHeight;
    public GameObject Grid;
    public Vector3 point;

    // Update is called once per frame
    void Update()
    {
        //DrawGrid(2, 8);
    }

    private void DrawGrid(int width, int height)
    {
        Vector3 widthLine = Vector3.right * (width);
        Vector3 heightLine = Vector3.forward * (height);

        for (int i = 0; i <= width; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <=height;j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }
    }

    private void CreateGrid()
    {
        for (int i =0; i<=8;i++)
        {
            int x = 0 + (i * 5);
            point.x = x;
            //Instantiate(Grid, point);

        }
    }
}
