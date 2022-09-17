using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout {

    // The rooms belonging to this layout
    private List<Room> rooms; 

    // Layout generator: 
    public Layout(int numOfRooms) {

        List<Room> generatedRooms = new List<Room>();
        Room firstRoom = new Room(this, 0, 0);
        generatedRooms.Add(firstRoom);
        List<intVector2> addedCoords = new List<intVector2>();
        intVector2 zeroPoint = new intVector2(0,0);
        addedCoords.Add(zeroPoint);

        List<intVector2> availableCoords = new List<intVector2>();
        availableCoords.Add(new intVector2(1, 0));
        availableCoords.Add(new intVector2(-1, 0));
        availableCoords.Add(new intVector2(0, 1));
        availableCoords.Add(new intVector2(0, -1));

        while (generatedRooms.Count < numOfRooms) {
            // Pick (randomly) an available coordinate: 
            intVector2 newLocation = availableCoords[Random.Range(0, availableCoords.Count)];
            updateAvailableSpots(addedCoords, availableCoords, newLocation);

            Room newRoom = new Room(this, newLocation.getX(), newLocation.getY());
            generatedRooms.Add(newRoom);
        }
        this.rooms = generatedRooms;
    }

    public List<Room> getRooms() {
        return rooms;
    }

    //This is needed for debuging only!
    public override string ToString(){
        string string_rooms = "Rooms:";
        foreach (Room room in this.rooms) {
            string_rooms += "(" + room.getX() + "," + room.getY() +"),";
        }
        string_rooms = string_rooms.Remove(string_rooms.Length - 1);
        return "(" + string_rooms + ")";
    }


    // This function needs to:
    //  Add currentPick to addedCoords
    //  Remove currentPick from availableCoords
    //  posibly add neighbours to availableCoords
    private void updateAvailableSpots(List<intVector2> addedCoords, List<intVector2> availableCoords, intVector2 currentPick){
        addedCoords.Add(currentPick);
        availableCoords.Remove(currentPick);
        intVector2 northNeighbour = currentPick.moveNorth();
        intVector2 eastNeighbour = currentPick.moveEast();
        intVector2 southNeighbour = currentPick.moveSouth();
        intVector2 westNeighbour = currentPick.moveWest();

        if (!(availableCoords.Contains(northNeighbour) || addedCoords.Contains(northNeighbour))) {
            availableCoords.Add(northNeighbour);
        }
        if (!(availableCoords.Contains(eastNeighbour) || addedCoords.Contains(eastNeighbour))){
            availableCoords.Add(eastNeighbour);
        }
        if (!(availableCoords.Contains(southNeighbour) || addedCoords.Contains(southNeighbour))){
            availableCoords.Add(southNeighbour);
        }
        if (!(availableCoords.Contains(westNeighbour) || addedCoords.Contains(westNeighbour))){
            availableCoords.Add(westNeighbour);
        }

    }

}

