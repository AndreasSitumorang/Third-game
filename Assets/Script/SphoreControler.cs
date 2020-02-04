using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphoreControler : MonoBehaviour {
    public float sporeSpeedHeigh;
    public float sporeSpeedLow;
    Rigidbody2D sporeRB;
    public float sporeAngle;
    public float sporeTorqueAngel;

    // Use this for initialization
    void Start () {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHeigh)),ForceMode2D.Impulse);
        sporeRB.AddTorque((Random.Range(-sporeTorqueAngel, sporeTorqueAngel)));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
