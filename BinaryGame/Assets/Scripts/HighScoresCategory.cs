using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresCategory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnPressed(string difficulty)
    {
        PracticeOverMechanics.difficulty = difficulty;
        SceneManager.LoadScene("PracticeHighScores");
    }

}
