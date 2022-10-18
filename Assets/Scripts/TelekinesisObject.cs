using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisObject : MonoBehaviour {
   
    void Start() {
        
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.collider.gameObject.tag);

        switch (col.collider.gameObject.tag)
        {
            case "Enemy":
                Character enemyChar = col.collider.gameObject.GetComponent<Character>();
                enemyChar.takeDamage(10);
                break;
            default:
                break;
        }
    }
}
