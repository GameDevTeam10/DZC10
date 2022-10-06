using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {

    [SerializeField] [Range(1, 30)] private int numberOfRooms = 10;

    private SceneTransitionManager stm;

    void Start()
    {
        stm = (SceneTransitionManager) Object.FindObjectOfType(typeof(SceneTransitionManager));

        if (stm == null)
        {
            Debug.LogError("Teleporter relies on the existance of the SceneTransitionManager");
        }
    }

    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // Create layout for next level
        this.stm.initialiseLayout(this.numberOfRooms);
    }
}
