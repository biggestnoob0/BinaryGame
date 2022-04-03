using Assets.Scripts;
using Assets.Scripts.Database;
using Assets.Scripts.Encryption;
using Assets.Scripts.Files;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginForm : MonoBehaviour
{
    InputField usernameField;
    InputField passwordField;
    // Start is called before the first frame update
    void Start()
    {
        Connection.Connect();
        List<string> userFile = FileIO.ReadTextFile(FileNames.loginDetails, FileNames.dir, Globals.KeyAccountDetails);
        if(userFile != null)
        {
            
            Globals.currentUsersUsername = StringEncryption.EncryptStringWithoutConversion(Globals.KeyAccountDetails, userFile[0].Substring(0, userFile[0].IndexOf(",")));
            SceneManager.LoadScene("StartMenu");
        }
        usernameField = GameObject.Find("Username").GetComponent<InputField>();
        passwordField = GameObject.Find("Password").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInputFieldEndEdit(InputField textbox)
    {
        string text = textbox.text;
        string newText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (StringEncryption.LetterPlacements.Contains(text[i].ToString()))
            {
                newText += text[i];
            }
        }
        textbox.text = newText;
    }
    public void LoginClicked()
    {

    }

    public void SignUpClicked()
    {
        SceneManager.LoadScene("SignUpForm");
    }
}
