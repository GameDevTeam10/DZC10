using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This class is responsible for all transitions between scenes. Because of this, it can never be destroyed and it is saved between
 * scene transitions. 
 *
 * This object relies on the existance of the player, which will also not be destroyed ever. 
 */
public class SceneTransitionManager : MonoBehaviour {


    private Layout layout;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        
    }

    public Room getFirstRoom() {
        if (layout == null) {
            Debug.LogError("Layout referenced before assignement! Hoe durf je, schavuit!");
        }
        return layout.getStartRoom();
    }

    public void initialiseLayout(int numRooms) {
        if (this.layout == null) {
            this.layout = new Layout(numRooms);
        }
    }

    public void overwriteLayout(int numRooms) {
        if (this.layout != null) {
            this.layout = new Layout(numRooms);
        }
    }
        

}
