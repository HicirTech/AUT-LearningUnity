using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hacker : MonoBehaviour {
    enum Screen {
        MainMenu,
        Passowrd,
        Win
    }
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
        if(input == "menu"||input == "Menu")
        {
            this.displayMenu();
        }
        else if(this.currentScreen==Screen.MainMenu)
        {
            this.inMainMenu(input);
        }
        else if(this.currentScreen==Screen.Passowrd)
        {

        }
    }
    private void inMainMenu(String input)
    {
        try
        {
            this.level=int.Parse(input);
            gamerStart();
        }catch(System.FormatException)
        {
            Terminal.WriteLine("you are not inputing number");
            Terminal.WriteLine("Please input again");
        }
    }
    private void gamerStart()
    {
        this.currentScreen=Screen.Passowrd;
        Terminal.WriteLine("Current Location : [" +this.currentScreen+"]");
        Terminal.WriteLine("you have choosen level: " + this.level);
        Terminal.WriteLine("Please enter you password");
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