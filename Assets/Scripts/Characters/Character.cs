using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float health;
    public float maxHealt;

    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealt;
    }

    // Update is called once per frame
    public void Update()
    {
        death();
    }

    private void death() {
        if (health <= 0) {
            Destroy(this);
        }
    }

}
