using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class objectPlacement : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public Camera mycam;
    private float zPos;

    private bool setLock;
    private Vector3 connectPos;

    //void Update()
    //{
        
    //    transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
    //}
    void OnMouseDown()
    {
        zPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        screenPoint = Camera.main.WorldToScreenPoint(Input.mousePosition);
        offset = gameObject.transform.position - GetMouseWorldPos();
        setLock = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        if(setLock !=false)
        {
            transform.position = GetMouseWorldPos() + offset;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Connectable")
        {
            connectPos = collision.gameObject.GetComponent<gridCreatorV2>().connectPos;
            gameObject.transform.position = connectPos;
            setLock = false;
        }
    }
}
