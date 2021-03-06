using Assets.Scripts;
using Assets.Scripts.Database;
using Assets.Scripts.Encryption;
using Assets.Scripts.Files;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginForm : MonoBehaviour
{
    InputField usernameField;
    InputField passwordField;
    // Start is called before the first frame update
    async void Start()
    {
        usernameField = GameObject.Find("Username").GetComponent<InputField>();
        passwordField = GameObject.Find("Password").GetComponent<InputField>();
        if (!Globals.loginFormOpenedBefore)
        {
            Thread dbConnectionThread = new Thread(new ThreadStart(Connection.Connect));
            dbConnectionThread.Start();
            await new Task(() => { StartCoroutine(Connect()); });
            List<string> userFile = FileIO.ReadTextFile(FileNames.loginDetails, FileNames.dir, Globals.KeyAccountDetails);
            if (userFile != null)
            {
                string document = ReadWriteDatabase.FindDocumentByElement(DBCollections.userCollection, "username", userFile[0]);
                if (!document.Equals(""))
                {
                    if (JSONValueFinder.findValue(document, "password").Equals(userFile[1]))
                    {
                        Globals.currentUsersUsername = StringEncryption.EncryptStringWithoutConversion(Globals.KeyAccountDetails, userFile[0].Substring(0, userFile[0].IndexOf(",")));
                        SceneManager.LoadScene("StartMenu");
                    }
                }
            }
        }
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
        if (!usernameField.text.Equals(string.Empty) && !passwordField.text.Equals(string.Empty))
        {

            string document = ReadWriteDatabase.FindDocumentByElement(DBCollections.userCollection, "username", usernameField.text);
            if (document != string.Empty)
            {
                string pw = StringEncryption.DecryptStringWithoutConversion(Globals.KeyAccountDetails, JSONValueFinder.findValue(document, "password"));
                if (pw.Equals(passwordField.text))
                {
                    Globals.currentUsersUsername = usernameField.text;
                    FileIO.WriteLines(new string[] { usernameField.text, passwordField.text }, FileNames.loginDetails, FileNames.dir);
                    SceneManager.LoadScene("StartMenu");
                }
            }
        }

    }

    public void SignUpClicked()
    {
        SceneManager.LoadScene("SignUpForm");
    }
    public IEnumerator Connect()
    {
        yield return new Task(Connection.Connect);
    }
}
