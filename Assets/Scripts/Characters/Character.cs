using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float health = 1;
    public float maxHealth;

    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    private void death() {
        if (health <= 0) {
            Debug.Log(health);
            Debug.Log("Going to destroy:" + this.gameObject.name);
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int amount) {
        this.health -= amount;
        death();
    }

}
