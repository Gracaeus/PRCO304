using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

public class obstacleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedSelected()
    {
        manager.GetComponent<placementManager>().chosenBox = "Red";
        Debug.Log(manager.GetComponent<placementManager>().chosenBox);
    }

    public void YellowSelected()
    {
        manager.GetComponent<placementManager>().chosenBox = "Yellow";
        Debug.Log(manager.GetComponent<placementManager>().chosenBox);
    }
    public void Deselect()
    {
        manager.GetComponent<placementManager>().chosenBox = "Deselect";
    }

    public void Barrel()
    {
        manager.GetComponent<placementManager>().chosenBox = "Barrel";
    }
    public void Edit()
    {
        manager.GetComponent<placementManager>().chosenBox = "Edit";
    }
}
