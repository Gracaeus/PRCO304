using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class saveBasicInfo : MonoBehaviour
{
    [SerializeField] private InputField playerName;
    [SerializeField] private InputField charcterName;
    [SerializeField] private InputField classType;
    [SerializeField] private InputField raceTppe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveOptions ()
    {
        if (playerName != null)
        {

            PlayerPrefs.SetString("Player Name", playerName.text);
            Debug.Log(PlayerPrefs.GetString("Player Name"));
        }
    }
    public void GetInfo()
    {
        Debug.Log(PlayerPrefs.GetString("Player Name"));
    }
}
