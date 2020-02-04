using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;

    public bool drop;
    public GameObject theDrop;

    public AudioClip deathKnell;

    // Use this for initialization
    void Start() {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth; 

    }

    // Update is called once per frame
    void Update() {

    }


    public void AddDamage(float damage){

        enemySlider.gameObject.SetActive(true);

        currentHealth -= damage;
        enemySlider.value = currentHealth;


        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        AudioSource.PlayClipAtPoint(deathKnell, transform.position); 
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drop) Instantiate(theDrop, transform.position, transform.rotation);
    }

}
