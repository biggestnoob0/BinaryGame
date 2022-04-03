using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyBtnPressed(string difficulty)
    {
        switch (difficulty.ToLower())
        {
            case "easy":
                PracticeGameMechanics.bits = 4;
                SceneManager.LoadScene("PracticeGame");
                break;
            case "medium":
                PracticeGameMechanics.bits = 6;
                SceneManager.LoadScene("PracticeGame");
                break;
            case "hard":
                PracticeGameMechanics.bits = 8;
                SceneManager.LoadScene("PracticeGame");
                break;
            default:
                Debug.Log("invalid difficulty");
                break;


        }
    }
}
