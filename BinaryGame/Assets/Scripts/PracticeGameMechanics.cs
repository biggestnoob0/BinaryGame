using Assets.Scripts;
using Assets.Scripts.BinaryDenary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class PracticeGameMechanics
{
    /// <summary>
    /// how many bits are being used in the difficulty
    /// </summary>
    public static int bits;
    /// <summary>
    /// carry out GenerateQuestion() before using this variable
    /// the current question that is being asked
    /// </summary>
    public static Question currentQuestion;
    public static List<Question> questionHistory = new List<Question>();
    public static int score = 0;
    public static void GenerateQuestion()
    {
        // sets current question to random question
        currentQuestion = QuestionGenerator.GenerateQuestion();
        if (questionHistory.Count >= 2)
        {
            while (currentQuestion == questionHistory[questionHistory.Count - 2])
            {
                currentQuestion = QuestionGenerator.GenerateQuestion();
            }
        }
        questionHistory.Add(currentQuestion);
    }
    public static bool IsBinaryAnswerCorrect(string binary)
    {
        //compares question value with binary value
        if(binary.Equals(currentQuestion.BinaryValue))
        {
            return true;
        }
        // returns false if first statement is not met
        return false;
    }
    public static bool IsDenaryAnswerCorrect(int denary)
    {
        //same as above but for denary
        if(denary == currentQuestion.DenaryValue)
        {
            return true;
        }
        return false;
    }
    public static void RestartGame()
    {
        //restarts some variables
        currentQuestion = null;
        questionHistory.Clear();
        score = 0;
    }
}
