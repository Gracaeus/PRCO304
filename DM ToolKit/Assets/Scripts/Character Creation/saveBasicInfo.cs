using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[Serializable]
public class saveBasicInfo : MonoBehaviour
{
    [SerializeField] private InputField playerName;
    [SerializeField] private InputField characterName;
    [SerializeField] private InputField classType;
    [SerializeField] private InputField raceTpye;
    [SerializeField] private InputField hp;
    [SerializeField] private InputField ac;
    [SerializeField] private InputField level;
    [SerializeField] private InputField xp;
    [SerializeField] private InputField apm;
    [SerializeField] private InputField s1;
    [SerializeField] private InputField s2;
    [SerializeField] private InputField s3;
    [SerializeField] private InputField s4;
    [SerializeField] private InputField s5;
    [SerializeField] private InputField s6;
    [SerializeField] private InputField s7;
    [SerializeField] private InputField s8;
    [SerializeField] private InputField s9;
    private GameObject title;
    private string titleText;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.FindGameObjectWithTag("Title");
        titleText = title.GetComponent<Text>().text;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveOptions ()
    {
        //SceneManager.LoadScene("Basic Stats");

        if (titleText == "Basic Info:")
        {
            if (playerName != null)
            {
                PlayerPrefs.SetString("Player Name", playerName.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (characterName != null)
            {
                PlayerPrefs.SetString("Character Name", characterName.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (classType != null)
            {
                PlayerPrefs.SetString("Class", classType.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (raceTpye != null)
            {
                PlayerPrefs.SetString("Race", raceTpye.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            SceneManager.LoadScene("Basic Stats");
        }
        else if (title.GetComponent<Text>().text == "Base Stats:")
        {
            if (hp != null)
            {
                PlayerPrefs.SetString("Health", hp.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (ac != null)
            {
                PlayerPrefs.SetString("AC", ac.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (level != null)
            {
                PlayerPrefs.SetString("Level", level.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (xp != null)
            {
                PlayerPrefs.SetString("XP", xp.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            SceneManager.LoadScene("Action Stats");
        }
        else if (title.GetComponent<Text>().text == "Action Stats:")
        {
            if (apm != null)
            {
                PlayerPrefs.SetString("APM", apm.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s1 != null)
            {
                PlayerPrefs.SetString("s1", s1.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s2 != null)
            {
                PlayerPrefs.SetString("s2", s2.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s3 != null)
            {
                PlayerPrefs.SetString("s3", s3.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s4 != null)
            {
                PlayerPrefs.SetString("s4", s4.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s5 != null)
            {
                PlayerPrefs.SetString("s5", s5.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s6 != null)
            {
                PlayerPrefs.SetString("s6", s6.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s7 != null)
            {
                PlayerPrefs.SetString("s7", s7.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s8 != null)
            {
                PlayerPrefs.SetString("s8", s8.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            if (s9 != null)
            {
                PlayerPrefs.SetString("s9", s9.text);
                Debug.Log(PlayerPrefs.GetString("Player Name"));
            }
            SceneManager.LoadScene("Character Finished");
        }


    }

    public void BackToBasicInfo()
    {
        SceneManager.LoadScene("Basic Info");
    }
    public void BackToBasicStats()
    {
        SceneManager.LoadScene("Basic Stats");
    }
    public void BackToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GetInfo()
    {
        Debug.Log(PlayerPrefs.GetString("Player Name"));
    }
}
