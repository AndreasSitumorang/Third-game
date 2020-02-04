using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour {

    bool grounded = false;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;
    public float jumpHeight;

	public float maxSpeed;
	Rigidbody2D myRB;
	Animator myanimation;
	bool facingRight;
    /// <summary>
    /// 
    /// </summary>
    public Transform gunTip;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextfirerate = 0f;






	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myanimation = GetComponent <Animator> ();
		facingRight = true;


	}


    // Update is called once per frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump")> 0)
        {
            grounded = false;
            myanimation.SetBool("CheckGround", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        if (Input.GetAxisRaw("Fire1") > 0) fireRoket();    

    }


    void FixedUpdate () {
       
		float move = Input.GetAxis("Horizontal");
		myanimation.SetFloat("speed", Mathf.Abs(move)); 
		myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
        myanimation.SetBool("CheckGround", grounded);
        myanimation.SetFloat("VerticalSpeed", myRB.velocity.y);


		if (move <0 &&  !facingRight){
			flip();
		}
		else if (move >0 && facingRight){
			flip();
		}
	}

	void flip(){

		facingRight = !facingRight;
		Vector3 thescale = transform.localScale;
		thescale.x *= -1;
		transform.localScale = thescale ;


	}

    void fireRoket()
    {
        if(Time.time > nextfirerate)
        {
            nextfirerate = Time.time + firerate;
            if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
     }
 }
