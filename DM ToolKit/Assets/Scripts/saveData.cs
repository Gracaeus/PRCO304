using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[Serializable]
public class saveData : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] public GameObject[] gridSquare;
    public GameObject[] exsistingObstacles;

    [SerializeField] private string saveFilePath = "/SaveFileFloor.dat";
    private string saveObstacleFilePath = "/SaveFileWalls.dat";

    [SerializeField] public GameObject floor;
    public GameObject wall;

    [SerializeField] private objectData dataSet;

    public GameObject set;
    public Text SaveText;
    public GameObject LoadText;
    [Serializable]
    class objectData
    {

        [SerializeField] public float xAxis;
        [SerializeField] public float yAxis;
        [SerializeField] public float zAxis;
        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public string name;
        //public Quaternion rotation;
        //[SerializeField] public GameObject name;

        [SerializeField]
        public objectData()
        { }
        [SerializeField]
        public objectData(float x, float y, float z)
        {
            xAxis = x;
            yAxis = y;
            zAxis = z;
            //name = floor;
        }
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("Map Saved") == 1)
        {
            LoadButton();
        }
    }
    [SerializeField]
    public void SaveButton()
    {
        SaveData();

        print(Application.persistentDataPath + saveFilePath);
    }
    [SerializeField]
    void SaveData()
    {
        File.Delete(Application.dataPath + saveFilePath);
        FileStream file = null;


        try
        {
            gridSquare = GameObject.FindGameObjectsWithTag("Grid");
            BinaryFormatter saveFileFormatter = new BinaryFormatter();
            //string fileName = System.IO.Path.Combine(Application.persistentDataPath, saveFilePath);
            file = File.Create(Application.persistentDataPath + saveFilePath);
            List<objectData> newDataCollection = new List<objectData>();

            foreach (GameObject newObject in gridSquare)
            {
                objectData newData = new objectData();
                newData.xAxis = newObject.transform.position.x;
                newData.yAxis = newObject.transform.position.y;
                newData.zAxis = newObject.transform.position.z;
                newData.rotationX = newObject.transform.rotation.eulerAngles.x;
                newData.rotationY = newObject.transform.rotation.eulerAngles.y;
                newData.rotationZ = newObject.transform.rotation.eulerAngles.z;
                //newData.name = newObject.gameObject;
                newDataCollection.Add(newData);
            }
            saveFileFormatter.Serialize(file, newDataCollection);

            exsistingObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            file = File.Create(Application.persistentDataPath + saveObstacleFilePath);
            List<objectData> newObstacleCollection = new List<objectData>();

            foreach (GameObject newObject in exsistingObstacles)
            {
                objectData newData = new objectData();
                newData.xAxis = newObject.transform.position.x;
                newData.yAxis = newObject.transform.position.y;
                newData.zAxis = newObject.transform.position.z;
                newData.rotationX = newObject.transform.rotation.eulerAngles.x;
                newData.rotationY = newObject.transform.rotation.eulerAngles.y;
                newData.rotationZ = newObject.transform.rotation.eulerAngles.z;
                //newData.rotation = newObject.transform.rotation;
                //newData.name = newObject.gameObject;
                newObstacleCollection.Add(newData);
            }
            saveFileFormatter.Serialize(file, newObstacleCollection);

        }
        catch (Exception e)
        {
            if (e != null)
            {
                print("Saving Error");
                StartCoroutine(TextError());
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
                StartCoroutine(TextUpdate());

            }
        }
        IEnumerator TextUpdate()
        {
            SaveText.text = "Save Complete";
            print("Saving Stream Closed");
            PlayerPrefs.SetInt("Map Saved", 1);
            yield return new WaitForSeconds(2);
            SaveText.text = "";
        }
        IEnumerator TextError()
        {
            SaveText.text = "Save error, try again";
            yield return new WaitForSeconds(2);
            SaveText.text = "";
        }

    }
  
    public void LoadButton()
    {
        gridSquare = GameObject.FindGameObjectsWithTag("Grid");
        foreach (GameObject target in gridSquare)
        {
            GameObject.Destroy(target);
        }
        GameObject[] gridObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject target in gridObstacles)
        {
            GameObject.Destroy(target);
        }
        GameObject[] decor = GameObject.FindGameObjectsWithTag("Decorations");
        foreach (GameObject target in decor)
        {
            GameObject.Destroy(target);
        }
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        LoadData();
    }

    [SerializeField]
    void LoadData()
    {
        FileStream file = null;

        //BinaryFormatter loadFileFormatter = new BinaryFormatter();
        //file = File.Open(Application.persistentDataPath + saveFilePath, FileMode.Open);
        //dataSet = loadFileFormatter.Deserialize(file) as objectData;
        //print(dataSet.xAxis);
        //file.Close();
        try
        {
            BinaryFormatter loadFileFormatter = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + saveFilePath, FileMode.Open);
            List<objectData> loadedData = (List<objectData>)loadFileFormatter.Deserialize(file);

            foreach (objectData newData in loadedData)
            {

                Vector3 pos = new Vector3(newData.xAxis, newData.yAxis, newData.zAxis);
                Instantiate(floor, pos, floor.transform.rotation);
            }

            file = File.Open(Application.persistentDataPath + saveObstacleFilePath, FileMode.Open);
            List<objectData> loadedObstacleData = (List<objectData>)loadFileFormatter.Deserialize(file);

            foreach (objectData newData in loadedObstacleData)
            {
                Vector3 pos = new Vector3(newData.xAxis, newData.yAxis, newData.zAxis);
                wall.transform.rotation = Quaternion.Euler(newData.rotationX, newData.rotationY, newData.rotationZ);
                Instantiate(wall, pos, wall.transform.rotation);

            }
        }
        catch (Exception e)
        {
            if(e != null)
            {
                print("Loading Error");
                StartCoroutine(LoadError());
            }
        }

        finally
        {
            if(file != null)
            {
                file.Close();
                print("Loading Stream Closed");
            }
        }       
        IEnumerator LoadComplete()
        {
            SaveText.text = "Load Complete";
            yield return new WaitForSeconds(2);
            SaveText.text = "";
        }
        IEnumerator LoadError()
        {
            SaveText.text = "Load error, try again";
            yield return new WaitForSeconds(1);
            SaveText.text = "";
        }


    }
}
