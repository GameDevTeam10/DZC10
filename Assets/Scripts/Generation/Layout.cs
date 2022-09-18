using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout {

    // The rooms belonging to this layout
    private List<Room> rooms;
    private Room startRoom;


    // Layout generator: 
    public Layout(int numOfRooms) {

        List<Room> generatedRooms = new List<Room>();
        Room firstRoom = new Room(this, 0, 0);
        this.startRoom = firstRoom;
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
        updateNeighbours(this.rooms);
    }

    public List<Room> getRooms() {
        return this.rooms;
    }

    public Room getStartRoom(){
        return this.startRoom;
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
    private void updateAvailableSpots(List<intVector2> addedCoords, List<intVector2> availableCoords, intVector2 currentPick) {
        addedCoords.Add(currentPick);
        availableCoords.Remove(currentPick);
        intVector2 northNeighbour = currentPick.moveNorth();
        intVector2 eastNeighbour = currentPick.moveEast();
        intVector2 southNeighbour = currentPick.moveSouth();
        intVector2 westNeighbour = currentPick.moveWest();

        if (!(availableCoords.Contains(northNeighbour) || addedCoords.Contains(northNeighbour))) {
            availableCoords.Add(northNeighbour);
        }
        if (!(availableCoords.Contains(eastNeighbour) || addedCoords.Contains(eastNeighbour))) {
            availableCoords.Add(eastNeighbour);
        }
        if (!(availableCoords.Contains(southNeighbour) || addedCoords.Contains(southNeighbour))) {
            availableCoords.Add(southNeighbour);
        }
        if (!(availableCoords.Contains(westNeighbour) || addedCoords.Contains(westNeighbour))) {
            availableCoords.Add(westNeighbour);
        }

    }

    // This function needs to set the neighbours of the rooms 
    private void updateNeighbours(List<Room> rooms) {
        foreach(Room room in rooms) {
            // Check if its neighbours exist
            Layout layout = room.getLayout();
            int xCord = room.getX();
            int yCord = room.getY();
            // NOTE: these rooms are only there to check if the room exists in the rooms parameter. These are not the actual room objects in the rooms of the current layout!
            Room northRoom = new Room(layout, xCord, yCord + 1);
            Room eastRoom = new Room(layout, xCord + 1, yCord);
            Room southRoom = new Room(layout, xCord, yCord - 1);
            Room westRoom = new Room(layout, xCord - 1, yCord);

            Room[] neighbourRooms = { northRoom, eastRoom, southRoom, westRoom };
            foreach(Room neighbour in neighbourRooms) {
                if (roomExists(rooms, neighbour)) {
                    room.addNeighbour(this.getNeighbourOutOfList(neighbour.getX(), neighbour.getY(), rooms));
                } 
            }
        }
    }

    // This function finds the correct instance out of a list.
    private Room getNeighbourOutOfList(int xCord, int yCord, List<Room> rooms) {
        foreach(Room room in rooms){
            if (room.getX() == xCord && room.getY() == yCord) {
                return room;
            }
        }
        Debug.LogError("Room not found! Returning null");
        return null;
    }

    private bool roomExists(List<Room> rooms, Room room){
        foreach (Room possibleRoom in rooms) {
            if (room == possibleRoom){
                return true;
            }
        }
        return false;
    }
}

