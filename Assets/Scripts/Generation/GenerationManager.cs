using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour {

    [SerializeField] [Range(1, 30)] private int numberOfRooms = 10;

    void Start() {
        Layout layout = new Layout(10);
    }

    void Update() {
        
    }
}
