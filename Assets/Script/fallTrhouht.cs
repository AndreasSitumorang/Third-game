using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrhouht : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Water"), LayerMask.NameToLayer("Water"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
