using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMapCreation()
    {
        SceneManager.LoadScene("Main Screen");
    }
    public void LoadCharacterCreation()
    {
        SceneManager.LoadScene("Basic Info");
    }
    public void MapView()
    {
        SceneManager.LoadScene("View Map");
    }
    public void CharacterView()
    {
        SceneManager.LoadScene("Player Screen");
    }
    public void CharacterActions()
    {
        SceneManager.LoadScene("Character Actions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Close()
    {
        Application.Quit();
    }
}
