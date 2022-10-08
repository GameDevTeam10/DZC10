using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Character {
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
