using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout {

    // The rooms belonging to this layout
    private List<Room> rooms; 

    // Layout generator: 
    public Layout(int numOfRooms) {
        Debug.Log(2);
        List<Room> generatedRooms = new List<Room>();
        Room firstRoom = new Room(this, 0, 0);
        List<intVector2> addedCoords = new List<intVector2>();
        intVector2 zeroPoint = new intVector2(0,0);
        addedCoords.Add(zeroPoint);
        
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

    public List<Room> getRooms() {
        return rooms;
    }

   
}

struct intVector2 {
    private int x;
    private int y;

    public intVector2(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public void setPosition(int newX, int newY) {
        this.x = newX;
        this.y = newY;
    }
}


