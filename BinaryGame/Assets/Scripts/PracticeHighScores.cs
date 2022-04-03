using Assets.Scripts;
using Assets.Scripts.Encryption;
using Assets.Scripts.Files;
using System.Collections;
using System.Collections.Generic;
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
        personalScores = FileIO.ReadTextFile(FileNames.practiceFile, FileNames.dir, Globals.KeyPersonalHighScores);
        for (int i = 0; i < personalScores.Count; i++)
        {
            personalScoresText.text += StringEncryption.DecryptStringWithoutConversion(Globals.KeyPersonalHighScores ,personalScores[i]) + "\n";
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
