using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    int max = 1000;
    int min = 1;
    int guess = 0;

    public int maxGuessesAllowed = 5;
    int guessesLeft = 0;

    public Text text;

    void Start ()
    {
        StartGame();
 	}
	
    void StartGame()
    {
        max = 1000;
        guessesLeft = maxGuessesAllowed;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(max, min+1);
        text.text = guess.ToString();
        if (--guessesLeft == 0)
        {
            Application.LoadLevel("Win");
        }
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }
    
}
