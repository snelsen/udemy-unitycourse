using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max = 1000;
    int min = 1;
    int guess = 500;

    // Use this for initialization
    void Start ()
    {
        StartGame();
 	}
	
    void StartGame()
    {
        max = 1000;
        guess = 500;
        print("=========================");
        print("Welcome to Number Wizard!");
        print("Pick a number between " + min + " and " + max + ".");
        // Account for integer rounding.
        max += 1;
        print("Is the number higher or lower than " + guess + "?");
        print("<up> = higher, <down> = lower, <Enter> = equal");
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess + "?");
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("<up> Pressed!");
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("<down> Pressed!");
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
	}
}
