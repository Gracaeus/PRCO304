using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class objectEditor : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private float value;
    private Transform selectedObject;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate()
    {
        selectedObject = manager.GetComponent<objectPlacementRaycast>().selectedObstacle;
        if (selectedObject.CompareTag("Obstacle"))
        {
            value = selectedObject.transform.rotation.y;
            value += 90.0f;
            selectedObject.Rotate(new Vector3(0, 0, value));
        }
        else if (selectedObject.CompareTag("Decorations"))
        {
            value = selectedObject.transform.rotation.y;
            value += 90.0f;
            selectedObject.Rotate(new Vector3(0, value, 0));
        }



    }
}
