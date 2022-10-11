using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This class is responsible for all transitions between scenes. Because of this, it can never be destroyed and it is saved between
 * scene transitions. 
 *
 * This object relies on the existance of the player, which will also not be destroyed ever. 
 */
public class SceneTransitionManager : MonoBehaviour {


    [SerializeField] [Range(1, 30)] private int numberOfRooms = 10;

    private Layout layout;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        layout = new Layout(numberOfRooms);
    }

    void Update() {
        
    }

    public Room getFirstRoom() {
        return layout.getStartRoom();
    }
}
