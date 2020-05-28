using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]

public class gridGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public Vector3 pos;
    public InputField widthInput;
    public InputField heightInput;

    private int width;
    private int height;

    // Start is called before the first frame update
    void Start()
    {
        pos.Set(0, 0, 0);
        //
        Debug.Log("Start Working");
    }

    // Update is called once per frame
    void Update()
    {
        ////GridCreator(3, 4, pos);
        //Debug.Log("Update Working");
    }

    void GridCreator (int width, int height, Vector3 pos)
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j =0; j < height; ++j)
            {
                pos.Set(i, 0, j);
                Instantiate(tilePrefab, pos, tilePrefab.transform.rotation);
            }
        }
    }

    public void GetHeight ()
    {
        
        GameObject[] gridObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject target in gridObstacles)
        {
            GameObject.Destroy(target);
        }
        GameObject[] gridSquare = GameObject.FindGameObjectsWithTag("Grid");
        foreach (GameObject target in gridSquare)
        {
            GameObject.Destroy(target);
        }
        GameObject[] decor = GameObject.FindGameObjectsWithTag("Decorations");
        foreach (GameObject target in decor)
        {
            GameObject.Destroy(target);
        }
        int check;
        if (int.TryParse(widthInput.text.ToString(), out check)&& int.TryParse(heightInput.text.ToString(), out check))
        {
            width = Int32.Parse(widthInput.text.ToString());
            height = Int32.Parse(heightInput.text.ToString());
            GridCreator(width, height, pos);
        }
        else
        {
            Debug.Log("Failed");
        }

    }
    
}
