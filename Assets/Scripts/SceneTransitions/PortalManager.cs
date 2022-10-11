using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {
    
    void Start() {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("OnCollisionEnter2D");
    }

}
