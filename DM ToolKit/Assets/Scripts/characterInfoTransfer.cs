using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterInfoTransfer : MonoBehaviour
{
    [SerializeField] private Text playerName;
    [SerializeField] private Text characterName;
    [SerializeField] private Text classType;
    [SerializeField] private Text raceTpye;
    [SerializeField] private Text hp;
    [SerializeField] private Text ac;
    [SerializeField] private Text level;
    [SerializeField] private Text speed;
    [SerializeField] private Text apm;
    [SerializeField] private Text s1;
    [SerializeField] private Text s2;
    [SerializeField] private Text s3;
    [SerializeField] private Text s4;
    [SerializeField] private Text s5;
    [SerializeField] private Text s6;
    [SerializeField] private Text s7;
    [SerializeField] private Text s8;
    [SerializeField] private Text s9;

    private GameObject title;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        title = GameObject.FindGameObjectWithTag("Title");
        print(title.GetComponent<Text>().text);
        if (title.GetComponent<Text>().text == "Actions:")
        {
            LoadActions();
        }
    }

    public void LoadStats()
    {
        playerName.text = PlayerPrefs.GetString("Character Name");
        classType.text = PlayerPrefs.GetString("Class");
        level.text = PlayerPrefs.GetString("Level");
        hp.text = PlayerPrefs.GetString("Health");
        ac.text = PlayerPrefs.GetString("AC");
        speed.text = PlayerPrefs.GetString("Speed");
    }

    void LoadActions()
    {
        apm.text = PlayerPrefs.GetString("APM");
        s1.text = PlayerPrefs.GetString("s1");
        s2.text = PlayerPrefs.GetString("s2");
        s3.text = PlayerPrefs.GetString("s3");
        s4.text = PlayerPrefs.GetString("s4");
        s5.text = PlayerPrefs.GetString("s5");
        s6.text = PlayerPrefs.GetString("s6");
        s7.text = PlayerPrefs.GetString("s7");
        s8.text = PlayerPrefs.GetString("s8");
        s9.text = PlayerPrefs.GetString("s9");
    }
}
