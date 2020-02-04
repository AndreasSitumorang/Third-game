using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemage : MonoBehaviour {
    public float damage;
    public float demageRate;
    public float pushBackforce;
    float nextDemage;


	// Use this for initialization
	void Start () {
        nextDemage = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



     void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && nextDemage < Time.time)
        {
            PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDemage = Time.time + demageRate;
            pushBack(collision.transform);

        }
    }
    /*void OnTriggerStay2D(Collider2D other)
   {
       if (other.tag == "Player" && nextDemage < Time.deltaTime)
       {
           PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
           //PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
           thePlayerHealth.addDamage(damage);
           nextDemage = Time.deltaTime + demageRate;
           pushBack(other.transform);

       }
   }

   void OnTriggerStay2D(Collider2D other)
   {

   }*/

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackforce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

}
