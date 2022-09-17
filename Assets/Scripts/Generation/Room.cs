using System.Collections;
using System.Collections.Generic;

public class Room
{

    // A room represents 1 block in our layout. A room is 1 scene. 
    // When the player enters a room, unity will load in a new scene and place the player accordingly.  

    // The layout this room belongs to
    private Layout layout;

    // The rooms have an X and Y coord, using these we will be able to generate the layouts 
    private int XCord;
    private int YCord;

    public Room(Layout layout, int XCord, int YCord) {
        this.layout = layout;
        this.XCord = XCord;
        this.YCord = YCord;
    }

    public int getX() {
        return this.XCord;
    }

    public int getY() {
        return this.YCord;
    }


}
