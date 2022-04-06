using Assets.Scripts.Encryption;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject accountSettings;
    // Start is called before the first frame update
    void Start()
    {
        accountSettings.SetActive(false);
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
        accountSettings.SetActive(true);
    }
}
