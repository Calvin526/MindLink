using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewUserInput : MonoBehaviour
{
    public InputField userID;
    public InputField fullName;
    public Button okButton;
    ArrayList credentials; // changed from userInfo to credentials

    void Start()
    {
        // when ok button is clicked,registerUser method is called and the data is registered to the database as arrayList
        okButton.onClick.AddListener(registerUser);
        // 
        if (File.Exists(Application.dataPath + "/userInfo.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        }
        else
        {
            credentials = new ArrayList(); 
            File.WriteAllText(Application.dataPath + "/userInfo.txt", ""); // Create an empty file
        }
    }

    void registerUser()
    {
        bool isExists = false;
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        foreach (var i in credentials) // changed from userInfo to credentials
        {
            if (i.ToString().Contains(userID.text)) // changed usernameInput.text to userID.text
            {
                isExists = true;
                break;
            }
        }
        if (isExists)
        {
            Debug.Log($"Username '{userID.text}' already exists");
        }
        else
        {
            credentials.Add(userID.text + ":" + fullName.text);
            File.WriteAllLines(Application.dataPath + "/userInfo.txt", (string[])credentials.ToArray(typeof(string)));
            Debug.Log("User Created !");
        }
    }
}
