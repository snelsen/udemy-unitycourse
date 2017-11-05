using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Brick.s_breakableCount = 0;
        Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        // If last brick destroyed, then load the next level.
        if (Brick.s_breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        Brick.s_breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
