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
        // only 1 STM should only ever exist!
        if (FindObjectsOfType<SceneTransitionManager>().Length > 1) {
            Destroy(this);
        }
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
            Debug.Log(this.layout);
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
        
    // Updates all required info and moves to the next scene, except for Room!
    public void goToScene(int scene) {
        currentSceneId = scene;
        SceneManager.LoadScene(scene);
    }

    public void goToNextRoom(Room room, RoomDoor.DoorLocation newLoc){
        this.currentRoom = room;
        this.goToScene(room.getSceneID());
        updatePlayerPosition(newLoc);
    }

    // this function should put the player in the correct position and trigger the 'spawnedPlayer' boolean of that door
    private void updatePlayerPosition(RoomDoor.DoorLocation location) {
        
        RoomDoor[] doors = (RoomDoor[])FindObjectsOfType(typeof(RoomDoor));

        //Find correct door
        RoomDoor correctDoor = null;
        foreach (RoomDoor door in doors) {
            if (door.getRoomLocation() == location) {
                correctDoor = door;
            }
        }

        if (correctDoor is null) {
            Debug.LogError("New room does NOT have a correct corresponding door");
        }

        this.player.transform.position = correctDoor.transform.position;
        correctDoor.tempDeactivePortal();
    }

    public Room getCurrentRoom() {
        return this.currentRoom;
    }
}
