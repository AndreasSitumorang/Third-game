using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float enemySpeed;
    Animator enemyAnimator;
    public GameObject enemygraphic;
    bool canflip = true;
   
    bool facingright = false;
    float fliptime = 5f;
    float nextFlipchance = 0f;
    // Use this for initialization
    public float chargeTime;
    float starChargetime;
    bool charging;
    Rigidbody2D enemyRB;
    void Start () {

        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFlipchance)
        {
            if (Random.Range(0, 10) >= 5) flipfacing();
            nextFlipchance = Time.time + fliptime;
        }
    }



     void OnTriggerEnter2D(Collider2D other)
    { if (other.tag == "Player"){
            if (facingright && other.transform.position.x > transform.position.x)
            {
                flipfacing();
            }
            else if (!facingright && other.transform.position.x < transform.position.x)
            {
                flipfacing();
            }
            canflip = false;
            charging = true;
            starChargetime = Time.time + chargeTime;
        }
    }


     void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player"){
            if (starChargetime < Time.time){
                if (!facingright) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                else  enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnimator.SetBool("IsCharging", charging);
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canflip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("IsCharging", charging);

        }
    }

    void flipfacing()
    {
        if (!canflip) return;
        float facingX = enemygraphic.transform.localScale.x;
        facingX *= -1f;
        enemygraphic.transform.localScale= new Vector3(facingX, enemygraphic.transform.localScale.y, enemygraphic.transform.localScale.z);
        facingright = ! facingright;

    } 
}





/*

public float enemySpeed;
Animator enemyAnimator;

public GameObject enemygraphic;
bool canflip = true;
bool facingright = false;
float fliptime = 5f;
float nextFlipchance = 0f;

public float chargeTime;
float starChargetime;
bool charging;
Rigidbody2D enemyRB;


// Use this for initialization
void Start()
{

    // enemyAnimator = GetComponentInChildren<Animator>();
    enemyAnimator = GetComponentInChildren<Animator>();
    enemyRB = GetComponent<Rigidbody2D>();

}

// Update is called once per frame
void Update()
{

    if (Time.time > nextFlipchance)
    {
        if (Random.Range(0, 10) >= 5) flipfacing();
        nextFlipchance = Time.time + fliptime;
    }
}



void OntriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        if (facingright && other.transform.position.x < transform.position.x)
        {
            flipfacing();
        }
        else if (!facingright && other.transform.position.x > transform.position.x)
        {
            flipfacing();
        }
        canflip = false;
        charging = true;
        starChargetime = Time.time + chargeTime;
    }
}


void OntriggerStay2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        if (starChargetime < Time.time)
        {
            if (!facingright) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnimator.SetBool("IsCharging", charging);
        }
    }
}

void OntriggerExit2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        canflip = true;
        charging = false;
        enemyRB.velocity = new Vector2(0, 0);
        enemyAnimator.SetBool("IsCharging", charging);
    }
}
void flipfacing()
{
    if (!canflip) return;
    float FacingX = enemygraphic.transform.localScale.x;
    FacingX *= -1f;
    enemygraphic.transform.localScale = new Vector3(FacingX, enemygraphic.transform.localScale.y, enemygraphic.transform.localScale.x);
    facingright = !facingright;

}
*/