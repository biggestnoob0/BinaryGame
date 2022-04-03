using Assets.Scripts;
using Assets.Scripts.BinaryDenary;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Converters;

public class PracticeGame : MonoBehaviour
{
    public GameObject[] bits = new GameObject[10];
    GameObject denaryInput;
    GameObject questionText;
    GameObject scoreText;
    GameObject correctText;
    Text timerText;
    Color red = new Color32(255, 88, 47, 255);
    Color green = new Color32(76, 255, 84, 255);
    private void Awake()
    {
        PracticeGameMechanics.RestartGame();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        denaryInput = GameObject.FindGameObjectWithTag("DenaryInput");
        questionText = GameObject.Find("Question");
        scoreText = GameObject.Find("Score");
        correctText = GameObject.Find("Correct");
        timerText = GameObject.Find("Timer").GetComponentInChildren<Text>();
        correctText.SetActive(false);
        for (int i = bits.Length - 1; i >= PracticeGameMechanics.bits ; i--)
        {
            bits[i].SetActive(false);
        }
        // calls questiongenerator to get first question
        PracticeGameMechanics.GenerateQuestion();
        OnNewQuestion();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnBitClicked(int bitArrayIndex)
    {
        // if bits current text value is 1, change to 0 etc
        if (bits[bitArrayIndex].transform.GetChild(0).GetComponentInChildren<Text>().text.Equals("1"))
        {
            bits[bitArrayIndex].GetComponent<Image>().color = red;
            bits[bitArrayIndex].transform.GetChild(0).GetComponentInChildren<Text>().text = "0";

            //if binary answer is correct do this
            if (PracticeGameMechanics.IsBinaryAnswerCorrect(BitsValue()))
            {
                PracticeGameMechanics.GenerateQuestion();
                PracticeGameMechanics.score += 10;
                StartCoroutine(ShowCorrectText());
                OnNewQuestion();
            }
        }
        // if bits current text value is not 1, change to 1 etc
        else
        {
            bits[bitArrayIndex].GetComponent<Image>().color = green;
            bits[bitArrayIndex].transform.GetChild(0).GetComponentInChildren<Text>().text = "1";

            //if binary answer is correct do this
            if (PracticeGameMechanics.IsBinaryAnswerCorrect(BitsValue()))
            {
                PracticeGameMechanics.GenerateQuestion();
                PracticeGameMechanics.score += 10;
                StartCoroutine(ShowCorrectText());
                OnNewQuestion();
            }
        }
    }
    public void OnDenaryTextChanged()
    {
        int denary;
        //checks if the text field contains any letters
        bool parsed = int.TryParse(denaryInput.GetComponent<InputField>().text, out denary);
        if (parsed)
        {
            //if denary answer is correct do this
            if (PracticeGameMechanics.IsDenaryAnswerCorrect(denary))
            {
                PracticeGameMechanics.GenerateQuestion();
                PracticeGameMechanics.score += 10;
                StartCoroutine(ShowCorrectText());
                OnNewQuestion();
            }
        }
        // if the text field contains letters, remove them
        else
        {
            denaryInput.GetComponent<InputField>().text = RemoveNonNumbers(denaryInput.GetComponent<InputField>().text);
        }
    }
    public void OnNewQuestion()
    {
        string questionType = PracticeGameMechanics.currentQuestion.Type.ToLower();
        scoreText.GetComponent<Text>().text = "Score: " + PracticeGameMechanics.score.ToString();
        denaryInput.GetComponentInChildren<Text>().text = "";
        for(int i = 0; i < PracticeGameMechanics.bits; i++)
        {
            bits[i].transform.GetChild(0).GetComponentInChildren<Text>().text = "0";
            bits[i].GetComponent<Image>().color = red;
        }
        denaryInput.GetComponent<InputField>().text = "";
        if (questionType.Equals("binary"))
        {
            questionText.GetComponent<Text>().text = "What is... \n" + PracticeGameMechanics.currentQuestion.BinaryValue + " in denary?";
            for (int i = 0; i < PracticeGameMechanics.bits; i++)
            {
                bits[i].SetActive(false);
            }
            denaryInput.SetActive(true);
            denaryInput.GetComponent<InputField>().Select();
        }
        else
        {
            questionText.GetComponent<Text>().text = "What is... \n" + PracticeGameMechanics.currentQuestion.DenaryValue + " in binary?";
            for(int i = 0; i < PracticeGameMechanics.bits; i++)
            {
                bits[i].SetActive(true);
            }
            denaryInput.SetActive(false);
        }
    }
    public string BitsValue()
    {
        string bitsValue = "";
        for (int i = 0; i < PracticeGameMechanics.bits; i++)
        {
            bitsValue += bits[i].GetComponentInChildren<Text>().text;
        }
        bitsValue = BinaryConverter.ReverseString(bitsValue);
        if (bitsValue[0] == '0')
        {
            if (bitsValue.IndexOf("1") != -1)
            {
                bitsValue = bitsValue.Substring(bitsValue.IndexOf("1"));
            }
        }
        return bitsValue;
    }
    public string RemoveNonNumbers(string text)
    {
        //removes all characters that arent numbers from the string
        return new string(text.Where(character => char.IsDigit(character)).ToArray());
    }
    public IEnumerator ShowCorrectText()
    {
        correctText.SetActive(true);
        yield return new WaitForSeconds(2);
        correctText.SetActive(false);
    }
    public IEnumerator Timer()
    {
        int timer = 60;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            timerText.text = timer.ToString();
        }
        PracticeOverMechanics.difficulty = DifficultyConverter.ToDifficulty(PracticeGameMechanics.bits);
        SceneManager.LoadScene("PracticeOverScreen");
    }
}
