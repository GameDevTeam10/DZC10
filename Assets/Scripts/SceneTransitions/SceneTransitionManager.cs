using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


/* This class is responsible for all transitions between scenes. Because of this, it can never be destroyed and it is saved between
 * scene transitions. 
 *
 * This object relies on the existance of the player, which will also not be destroyed ever. 
 */
public class SceneTransitionManager : MonoBehaviour {


    private GameObject player;
    private Layout layout;

    // The ARRAY_OF_ROOM_IDS stores an array of all the ids of scenes that are part of the corresponding rooms
    private static int[] ARRAY_OF_ROOM_IDS = { 1 };
    // The HUB_ID stores the id of the hub scene
    private static int HUB_ID = 0;

    private int currentSceneId = 0;
    private Room currentRoom;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindWithTag("Player");
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
            currentRoom = this.layout.getStartRoom();
        }
    }

    public void overwriteLayout(int numRooms) {
        if (this.layout != null) {
            this.layout = new Layout(numRooms);
            currentRoom = this.layout.getStartRoom();
        }
    }

    public static int getRandomRoomScene() {
        return ARRAY_OF_ROOM_IDS[Random.Range(0, ARRAY_OF_ROOM_IDS.Length)];
    }

    public static int getHubID() {
        return HUB_ID;
    }
        
    // Updates all required info and moves to the next scene
    public void goToScene(int scene) {
        currentSceneId = scene;
        SceneManager.LoadScene(scene);
        updatePlayerPosition();
    }

    private void updatePlayerPosition() {
        Debug.Log("Updating of player position must still be implemented");
    }

    public Room getCurrentRoom() {
        return this.currentRoom;
    }
}
