using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountSettingsOverlay : MonoBehaviour
{
    Text accountNameText;
    GameObject passwordChangerScreen;
    GameObject defaultElementsScreen;

    //password changer variables
    Text oldPassword;
    Text newPassword;

    // Start is called before the first frame update
    void Start()
    {
        passwordChangerScreen = GameObject.Find("PasswordChangerScreen");
        defaultElementsScreen = GameObject.Find("DefaultElementsScreen");
        accountNameText = GameObject.Find("Name").GetComponent<Text>();
        accountNameText.text = Globals.currentUsersUsername;
        defaultElementsScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region defuault elements
    public void ChangePasswordClicked()
    {
        defaultElementsScreen.SetActive(false);
        passwordChangerScreen.SetActive(true);
        oldPassword = GameObject.Find("OldPassword").GetComponent<Text>();
        newPassword = GameObject.Find("NewPassword").GetComponent<Text>();
    }
    #endregion
    #region password changer
    public void PasswordChangerClicked()
    {

    }
    #endregion
}
