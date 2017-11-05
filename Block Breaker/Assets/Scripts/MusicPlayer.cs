using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer s_instance = null;

    private void Awake()
    {
        if (null != s_instance)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing.");
        }
        else
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
