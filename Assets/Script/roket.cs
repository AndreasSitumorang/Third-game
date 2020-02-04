using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roket : MonoBehaviour {
    public float weaponDamage;
    Projectile myPc;

    public GameObject explotionEffect;

    // Use this for initialization
    void Awake () {
        myPc = GetComponentInParent<Projectile>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            myPc.RemoveForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }
        }
    }

     void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            myPc.RemoveForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.AddDamage(weaponDamage);
            }
        }
        

    }

}
