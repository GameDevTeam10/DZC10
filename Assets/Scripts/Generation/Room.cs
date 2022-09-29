using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {

    // A room represents 1 block in our layout. A room is 1 scene. 
    // When the player enters a room, unity will load in a new scene and place the player accordingly.  

    // The layout this room belongs to
    private Layout layout;

    // The rooms have an X and Y coord, using these we will be able to generate the layouts 
    private int XCord;
    private int YCord;

    // The rooms also have neighbours. These will be set by the layout constructor
    private Room northNeighbour;
    private Room eastNeighbour;
    private Room southNeighbour;
    private Room westNeighbour;

    public Room(Layout layout, int XCord, int YCord) {
        this.layout = layout;
        this.XCord = XCord;
        this.YCord = YCord;

        //initialise neighbours as null
        this.northNeighbour = null;
        this.eastNeighbour = null;
        this.southNeighbour = null;
        this.westNeighbour = null;
    }

    public Layout getLayout(){
        return this.layout;
    }

    public int getX() {
        return this.XCord;
    }

    public int getY() {
        return this.YCord;
    }

    public List<Room> getNeighbours() {
        List<Room> neighbours = new List<Room>();
        if (!(this.northNeighbour is null)) {
            neighbours.Add(this.northNeighbour);
        }
        if (!(this.eastNeighbour is null)) {
            neighbours.Add(this.eastNeighbour);
        }
        if (!(this.southNeighbour is null)) {
            neighbours.Add(this.southNeighbour);
        }
        if (!(this.westNeighbour is null)) {
            neighbours.Add(this.westNeighbour);
        }

        return neighbours;
    }

    public void addNeighbour(Room neighbour) {
        if (neighbour.getX() == this.getX() && neighbour.getY() == this.getY() + 1) {
            this.northNeighbour = neighbour;
        } 
        else if (neighbour.getX() == this.getX() + 1 && neighbour.getY() == this.getY()) {
            this.eastNeighbour = neighbour;
        }
        else if (neighbour.getX() == this.getX() && neighbour.getY() == this.getY() - 1) {
            this.southNeighbour = neighbour;
        }
        else if (neighbour.getX() == this.getX() - 1 && neighbour.getY() == this.getY()) {
            this.westNeighbour = neighbour;
        }
        else {
            Debug.LogError("Generation error: Unable to find a correct neighbour '" + neighbour  + "' ");
        }
    }

    // These 2 functions are needed for comparison in list! 
    public static bool operator ==(Room room1, Room room2) {
        return room1.layout == room2.layout && room1.XCord == room2.XCord && room1.YCord == room2.YCord;
    }

    public static bool operator !=(Room room1, Room room2) {
        return room1.layout != room2.layout || room1.XCord != room2.XCord || room1.YCord != room2.YCord;
    }

    // For debug purposes:
    public override string ToString() {
        string representativeString = this.cordString();
        // neighbours (by cord).
        representativeString += " , neighbours: ";
        foreach(Room neighbour in this.getNeighbours()){
            representativeString += "," + neighbour.cordString();
        }
        return representativeString;
    }

    public string cordString(){
        return "Cord: (" + this.getX() + "," + this.getY() + ")";
    }
}
