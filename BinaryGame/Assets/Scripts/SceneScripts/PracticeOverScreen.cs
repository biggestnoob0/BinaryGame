using Assets.Scripts;
using Assets.Scripts.Converters;
using Assets.Scripts.Encryption;
using Assets.Scripts.Files;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeOverScreen : MonoBehaviour
{
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + PracticeGameMechanics.score.ToString();
        // sets file name to applications data path plus \practice\highscores + the games difficulty + the extension
        string input = "You" + ";" + PracticeGameMechanics.score;
        switch (PracticeOverMechanics.difficulty.ToLower())
        {
            case "easy":
                FileIO.WriteLine(input, FileNames.practiceEasyHighscores, FileNames.practiceDir, Globals.KeyPersonalHighScores);
                break;
            case "medium":
                FileIO.WriteLine(input, FileNames.practiceMediumHighscores, FileNames.practiceDir, Globals.KeyPersonalHighScores);
                break;
            case "hard":
                FileIO.WriteLine(input, FileNames.practiceHardHighscores, FileNames.practiceDir, Globals.KeyPersonalHighScores);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgainClicked()
    {
        SceneManager.LoadScene("PracticeGame");
    }
    public void MainMenuClicked()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
