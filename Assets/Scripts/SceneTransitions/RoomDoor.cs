using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : PortalManager {

    enum DoorLocation { north, east, south, west }

    [SerializeField] private DoorLocation doorLocation = DoorLocation.north;

    override public void onPlayerHit() {
        //Move to different location
    }

}
