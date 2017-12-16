﻿using UnityEngine;

public class Hacker : MonoBehaviour {

    //game confuguration data
    const string menuhint = "You may type menu at any time";
    string[] level1Passwords = { "car", "plane", "boat", "scooter", "bicycle", "race" };
    string[] level2Passwords = { "uniform", "handcuffs", "handgun", "prisoner", "arrest", "holster" };
    string[] level3Passwords = { "tachycardia", "bradycardia", "cholelithiasis", "pneumonia", "bronchitis", "gallstones", "constipation" };
    //game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("---------------------------------");
        Terminal.WriteLine("Press 1 for the vehicle store");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the Super Rich Medicine Institution");
        Terminal.WriteLine("---------------------------------");
        Terminal.WriteLine("Enter your selection: ");
    }

    void Update()
    {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);

    }

    void OnUserInput(string input)
    {
        if (input == "menu")// we can always go to direct menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("You are compromissed Mr. Bond");
        }
        else if (input == "13")
        {
            Terminal.WriteLine("You are not messing with a devil, please choose a valid level");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuhint);
        }
    }

    void AskForPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuhint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a car...");
                Terminal.WriteLine(@"
 
     _____
 ___/__|__\_
 |_@______@_|   
"
                );
                Terminal.WriteLine("Play again for a greater chalenge");
                break;
            case 2:
                Terminal.WriteLine("You are FREE...");
                Terminal.WriteLine(@"
 __
/0 \________
\__/-='  = '
"
                );
                break;
            case 3:
                Terminal.WriteLine("You will live...");
                Terminal.WriteLine(@"
       _________________
______/_________________|___|
      \_|_|_|_|_|_|_|_|_|   |

"
                );
                Terminal.WriteLine("Play again for a greater chalenge");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        }
        
    }
}
