using Assets.Scripts;
using Assets.Scripts.Encryption;
using Assets.Scripts.Files;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeHighScores : MonoBehaviour
{
    Text personalScoresText;
    List<string> personalScores = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        personalScoresText = GameObject.Find("PersonalScoresText").GetComponent<Text>();
        switch(PracticeOverMechanics.difficulty.ToLower())
        {
            case "easy":
                personalScores = FileIO.ReadTextFile(FileNames.practiceEasyHighscores, FileNames.dir, Globals.KeyPersonalHighScores);
                break;
            case "medium":
                personalScores = FileIO.ReadTextFile(FileNames.practiceMediumHighscores, FileNames.dir, Globals.KeyPersonalHighScores);
                break;
            case "hard":
                personalScores = FileIO.ReadTextFile(FileNames.practiceHardHighscores, FileNames.dir, Globals.KeyPersonalHighScores);
                break;
            default:
                break;
        }
        if (personalScores != null)
        {
            string textToOutput = "";
            for (int i = 0; i < personalScores.Count; i++)
            {
                textToOutput = personalScores[i].Replace(";", ",");
                personalScoresText.text += textToOutput + "\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainMenuClicked()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
