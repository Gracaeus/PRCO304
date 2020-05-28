using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class objectPlacementRaycast : MonoBehaviour
{
    [SerializeField] private Material SelectedMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject manager;

    private string selectedColours;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject barrel;

    [SerializeField] private string selectableTag = "Grid";

    public Transform selectedObstacle;
    public List<Transform> selectedObject = new List<Transform>();

    //public float Reach = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(selectedObject.Count);
            //Debug.DrawRay(transform.position, fwd * Reach, Color.red);
            //var fwd = transform.TransformDirection(Vector3.forward);

            BoxSelection();            
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit) /*&& hit.transform.gameObject.tag == "Grid"*/)
            {
                
                var selection = hit.transform;
                Vector3 selectionLocation = selection.transform.position;
                Debug.Log(selection.transform.gameObject.tag);
                Debug.Log(selection.childCount);
                //selectionLocation.y = 0.6f;
                if (selection.CompareTag(selectableTag))
                {
                    if (selectionLocation != null)
                    {
                        if (selectedColours == "Red")
                        {
                            Instantiate(wall, selectionLocation, wall.transform.rotation);
                        }
                        else if (selectedColours == "Yellow")
                        {
                            selectionLocation.y = 0.1f;
                            selectionLocation.x += -0.1f;
                            selectionLocation.z += 0.3f;
                            Instantiate(table, selectionLocation, table.transform.rotation);
                        }
                        else if (selectedColours == "Barrel")
                        {
                            Instantiate(barrel, selectionLocation, barrel.transform.rotation);
                        }
                    }
                }

                if (selection.CompareTag("Obstacle")||selection.CompareTag("Decorations"))
                {
                    if (selectedColours == "Deselect")
                    {
                        Destroy(selection.transform.gameObject);
                    }
                    else if(selectedColours == "Edit")
                    {
                        //var selectionRenderer = selection.GetComponent<Renderer>();
                        //if (selectedObject.Count>0)
                        //{
                        //    selectedObject[0].GetComponent<Renderer>().material = defaultMaterial;
                        //    selectedObject.Clear();
                        //    Debug.Log("Cleared");
                        //}
                        //else if (selectedObject.Count == 0)
                        //{
                        //    selectedObject.Add(selection);
                        //    if (selectionRenderer != null)
                        //    {
                        //        selectionRenderer.material = SelectedMaterial;
                        //    }
                        //}
                        selectedObstacle = selection;

                    }
                }
            }
        }

    }

    void BoxSelection()
    {
        selectedColours= manager.GetComponent<placementManager>().chosenBox;
    }

}
