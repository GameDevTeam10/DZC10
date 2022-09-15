using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout {

    // The rooms belonging to this layout
    private List<Room> rooms; 

    // Layout generator: 
    public Layout(int numOfRooms)
    {
        List<Room> generatedRooms = new List<Room>();
        Room firstRoom = new Room(this, 0, 0);
        List<(int, int)> addedCoords = new List<(int, int)>();
        //private (int,int) tuppledZeroZeroCoord = (0,0)
        //addedCoords.add(tuppledZeroZeroCoord);

        for (int i = 1; i < numOfRooms; i++) {
            // We map the following numbers: 
            // 0: move north
            // 1: move east
            // 2: move south
            // 3: move west

            int nextStep = Random.Range(0,4);
        }

        this.rooms = generatedRooms;
    }

    // This is a test comment
   
}


