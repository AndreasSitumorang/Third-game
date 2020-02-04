using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrartGame : MonoBehaviour {

    public float restartTime;
    bool restart = false;
    float resetTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(restart && resetTime <= Time.time)
        {
            //Application.LoadLevel(Application.loadedLevel);
            Application.LoadLevel(Application.loadedLevel); 
        }
	}

    public void restartTheGame()
    {
        restart = true;
        resetTime = Time.time + restartTime;

    }
}
