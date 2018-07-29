using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Hacker : MonoBehaviour {
    enum Screen {
        MainMenu,
        Passowrd,
        Win
    }
    private String[] password = {"pass1","pass2","pass3"};
    private int level;
    Screen currentScreen;
	void Start () {
        this.displayMenu();    
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void displayMenu()
    {
        this.currentScreen=Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Current Location : [" +this.currentScreen+"]");
        Terminal.WriteLine("Please select a Level");
        Terminal.WriteLine("[1] Level 1");
        Terminal.WriteLine("[2] Level 2");
        Terminal.WriteLine("[3] Level 3");
        Terminal.WriteLine("Enter a number for select");
    }
       

    private void OnUserInput(string input)
    {
        if(input.ToLower() == "menu")
        {
            this.displayMenu();
        }
        else if(this.currentScreen==Screen.MainMenu)
        {
            this.inMainMenu(input);
        }
        else if(this.currentScreen==Screen.Passowrd)
        {
            this.inPassword(input);
        }
    }

    private void inPassword(string input)
    {
        if(checkPassWord(input))
        {
            this.displayWin();
        }
        else{
            Terminal.WriteLine("Wrong password");
        }
    }

    private bool checkPassWord (string input)
    {
        return input == password[UnityEngine.Random.Range(0,password.Length)]; 
    }
    private void inMainMenu(String input)
    {
        try
        {   if(1<=int.Parse(input)&&int.Parse(input)<=3)
            {
                this.level=int.Parse(input);
                gamerStart();
            }else
            {
                Terminal.WriteLine("Do not have this level");
                Terminal.WriteLine("please input again");
            }

        }catch(System.FormatException)
        {
            Terminal.WriteLine("you are not inputing number");
            Terminal.WriteLine("Please input again");
        }
    }
    private void gamerStart()
    {
        this.currentScreen=Screen.Passowrd;
        Terminal.ClearScreen();
        Terminal.WriteLine("Current Location : [" +this.currentScreen+"]");
        Terminal.WriteLine("you have choosen level: " + this.level);
        Terminal.WriteLine("Enter you password, hit: " +("pass"+UnityEngine.Random.Range(0,password.Length)).Anagram());
    }

    private void displayWin()
    {
        this.currentScreen=Screen.Win;
        Terminal.ClearScreen();
        this.showReward();
    }
    private void showReward()
    {
        Terminal.WriteLine("Well done");
        Terminal.WriteLine("you passed level "+this.level);
        Terminal.WriteLine("Type [Menu] to go back");
    }
      private bool inputCals(string input)
    {
    
        return input=="1"?true:false;
    }
}
//----------------------
 /* if(input.Length==3&&input=="007")
       { 
           print("fuck you");
           Terminal.WriteLine("fuckyou");
       }
       else if(input ==  "menu")
       {
           this.printWellcome("Zeting");
       }
       else if(input.Length==1)
       {
            print("please input useable level");
            Terminal.WriteLine("please input useable level");
       }
       else
       {
           Terminal.WriteLine("input error");
       }*/
//-----------------------------------------