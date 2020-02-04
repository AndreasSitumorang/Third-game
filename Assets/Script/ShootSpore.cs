using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpore : MonoBehaviour {
    public GameObject projectile;
    public float shootTime;
    public Transform shootForm;
    public int ChanceShoot;
    float nextShoot;
    Animator cannonAnim;


	// Use this for initialization
	void Start () {
        cannonAnim = GetComponentInChildren<Animator>();
        nextShoot = 0f;



    }
	
	// Update is called once per frame
	void Update () {
		
	}



     void OnTriggerStay2D(Collider2D other)
        { 
        if(other.tag== "Player" && nextShoot < Time.time)
        {
            nextShoot = Time.time + shootTime;
            if(Random.Range(0,10)>= ChanceShoot)
            {
                Instantiate(projectile, shootForm.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }
        }        
        }

}
