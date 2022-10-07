using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : PortalManager {

    enum DoorLocation { north, east, south, west }
    /* 
     * Could the issue of moving the player to different doors have been solved more elegantly?
     * Yes, but who has the time, simply hardcoding a simple dict like this works wonders!
     */
    private Dictionary<DoorLocation, DoorLocation> doorTransitions = new Dictionary<DoorLocation, DoorLocation>() {
        { DoorLocation.north, DoorLocation.south },
        { DoorLocation.east, DoorLocation.west },
        { DoorLocation.south, DoorLocation.north },
        { DoorLocation.west, DoorLocation.east },
    };

    [SerializeField] private DoorLocation doorLocation = DoorLocation.north;
    // A door should only be used if it actually has a neighbour.
    [HideInInspector] private bool canBeUsed = false;

    private void Start(){
        base.Start();
        Room currentRoom = stm.getCurrentRoom();
        canBeUsed = !(getConnectedRoom(stm.getCurrentRoom()) is null);
        
        //TEMP WILL BE TAKEN OUT ONCE WE ADD GRAPHICS!!!
        if (!canBeUsed) {
            SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.black;
        }
        //END OF TEMP
    }
    override public void onPlayerHit() {
        if (canBeUsed) {
            //Move to different location
            Room currentRoom = stm.getCurrentRoom();
            Room nextRoom = getConnectedRoom(currentRoom);
            //Move to new scene
            stm.goToNextRoom(nextRoom);
        }
        else {
            Debug.Log("Neighbour does not exist!");
        }
    }

    private Room getConnectedRoom(Room currentRoom) {
        Room neighbour = null;
        switch (doorLocation){
            case DoorLocation.north:
                neighbour = currentRoom.getNorthNeighbour();
                break;
            case DoorLocation.east:
                neighbour = currentRoom.getEastNeighbour();
                break;
            case DoorLocation.south:
                neighbour = currentRoom.getSouthNeighbour();
                break;
            case DoorLocation.west:
                neighbour = currentRoom.getWestNeighbour();
                break;
        }
        return neighbour;
    }

}
