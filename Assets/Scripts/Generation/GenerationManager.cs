using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour {

    [SerializeField] [Range(1, 30)] private int numberOfRooms = 10;

    void Start() {
        Layout layout = new Layout(numberOfRooms);
        Debug.Log(layout);

        List<Room> rooms = layout.getRooms();
        foreach (Room room in rooms)
        {
            Debug.Log(room);
        }

    }

    void Update() {
        
    }
}
