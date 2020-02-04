using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float fullHealth;
    float currentHealth;
    Playercontroler controlMovement;
    public GameObject deathFX;
    // Use this for initialization
    public Slider healthSlider;
    public Image demageScreen;
    bool demaged = false;
    Color demageColor = new Color(0f,0f,0f,0.5f);
    float smothColor = 5f;
    /// <summary>
    /// ////////////////
    /// </summary>
    public AudioClip playerHurtes;
    AudioSource playerAS;
    public Text gameOverScreen;
    public Text gameWinner;
    public AudioClip playerDeathSound;

    public RestrartGame theManagerGame;

    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<Playercontroler>();

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        demaged = false;

        playerAS = GetComponent<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {
        if (demaged)
        {
            demageScreen.color = demageColor;
        }
        else
        {
            demageScreen.color = Color.Lerp(demageScreen.color, Color.clear, smothColor * Time.deltaTime); 
        }
        demaged = false;
	}

    public void addDamage(float damage)
    {if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        //playerAS.clip = playerHurtes;
        //playerAS.Play();
        playerAS.PlayOneShot(playerHurtes);


        demaged = true;

        if( currentHealth <= 0)
        {
            makeDead();
        }
    }
    

     public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth; 

    }
    public void makeDead()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        Instantiate(deathFX,transform.position, transform.rotation);
        Destroy(gameObject);
        demageScreen.color = demageColor;
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theManagerGame.restartTheGame();

    }
     public void winGame()
    {
        Destroy(gameObject);
        theManagerGame.restartTheGame();
        Animator winnerAnimator = gameWinner.GetComponent<Animator>();
        winnerAnimator.SetTrigger("gameOver");
    }

}
