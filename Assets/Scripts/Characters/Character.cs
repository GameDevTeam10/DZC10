using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] public float damage;
    [SerializeField] public float maxHealth = 1;

    // Start is called before the first frame update
    public void Start()
    {
        this.health = maxHealth;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public virtual void updateHealth(float amount)
    {
        health -= amount;
        death();
    }

    public virtual void death()
    {
        if (health <= 0)
        {
            Debug.Log(health);
            Debug.Log("Going to destroy:" + this.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
