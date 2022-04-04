using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts.Database;
using UnityEngine.SceneManagement;
using Assets.Scripts.Files;
using Assets.Scripts.Encryption;
using Assets.Scripts;
using System.Diagnostics;

public class SignUpForm : MonoBehaviour
{
    InputField usernameField;
    InputField passwordField;
    Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        usernameField = GameObject.Find("Username").GetComponent<InputField>();
        passwordField = GameObject.Find("Password").GetComponent<InputField>();
        errorText = GameObject.Find("ErrorText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnInputFieldEndEdit(InputField textbox)
    {
        string text = textbox.text;
        string newText = "";
        for(int i = 0; i < text.Length; i++)
        {
            if(StringEncryption.LetterPlacements.Contains(text[i].ToString()))
            {
                newText += text[i];
            }
        }
        textbox.text = newText;
    }
    public void SignUpClicked()
    {
        if (usernameField.text != string.Empty && passwordField.text != string.Empty)
        {
            bool allowed = true;
            for (int i = 0; i < usernameField.text.Length; i++)
            {
                if (!char.IsLetterOrDigit(usernameField.text[i]))
                {
                    allowed = false;
                    StartCoroutine(ErrorMsg("Non letter or digit detected in username"));
                }
            }
            if (usernameField.text.IndexOf(":") != -1 || usernameField.text.IndexOf(",") != -1)
            {
                allowed = false;
                StartCoroutine(ErrorMsg("Colon or comma detected in password"));
            }
            if (allowed)
            {
                string[] input = { "{ 'username' : '" + usernameField.text + "'}",
                    "{ 'password' : '" + StringEncryption.EncryptStringWithoutConversion(Globals.KeyAccountDetails, passwordField.text) + "'}" };
                bool available = true;
                var collection = ReadWriteDatabase.ReadCollection("User");
                List<string> listOfNames = JSONValueFinder.findValues(collection, "username");
                for (int i = 0; i < listOfNames.Count; i++)
                {
                    if (listOfNames[i].Equals(usernameField.text))
                    {
                        available = false;
                        StartCoroutine(ErrorMsg("Name already taken"));
                    }
                }
                if (available && FileIO.ReadTextFile(FileNames.loginTimesCheck, FileNames.dir, Globals.KeyAccountDetails) == null ||
                    available && FileIO.ReadTextFile(FileNames.loginTimesCheck, FileNames.dir, Globals.KeyAccountDetails).Count <= 5)
                {
                    ReadWriteDatabase.AddToCollection("User", input);
                    FileIO.ReplaceFile(FileNames.loginDetails, FileNames.dir);
                    FileIO.WriteLine(usernameField.text + "," + passwordField.text,
                        FileNames.loginDetails, FileNames.dir, Globals.KeyAccountDetails);
                    FileIO.WriteLine("0", FileNames.loginTimesCheck, FileNames.dir, Globals.KeyAccountDetails);
                    SceneManager.LoadScene("StartMenu");
                }
                else
                {
                    StartCoroutine(ErrorMsg("You have already made 5 accounts, limit reached"));
                }
            }
        }
    }
    public IEnumerator ErrorMsg(string text)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = text;
        yield return new WaitForSeconds(3);
        errorText.gameObject.SetActive(false);
    }
    public void BackBtnPressed()
    {
        SceneManager.LoadScene("LoginForm");
    }
}
