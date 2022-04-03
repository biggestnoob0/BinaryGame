using Assets.Scripts.Encryption;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPracticeClicked()
    {
        SceneManager.LoadScene("DifficultySelector");
    }
    public void OnHighScoresClicked()
    {
        SceneManager.LoadScene("HighScoresCategory");
    }
    public void OnExitClicked()
    {
        Application.Quit();
    }
    public void OnAccountClick()
    {
        GameObject.Find("AccountSettingsCanvas").SetActive(true);
    }
}
