 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawndoor : MonoBehaviour {
    bool actived = false;
    public Transform WhereTospwan;
    public GameObject doorer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == "Player" && !actived)
        {
            actived = true;
            Instantiate(doorer, WhereTospwan.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
