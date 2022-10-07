using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {

    [SerializeField] [Range(1, 30)] private int numberOfRooms = 10;
    [SerializeField] [Range(1, 10)] private float radius = 1;

    [HideInInspector] //STM should be a singleton (not by design, but usage)
    public SceneTransitionManager stm;

    public void Start() {
        stm = (SceneTransitionManager) Object.FindObjectOfType(typeof(SceneTransitionManager));

        if (stm == null)
        {
            Debug.LogError("Teleporter relies on the existance of the SceneTransitionManager");
        }
    }

    private void FixedUpdate() {
        // Get all objects that are close enough
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        // Check if an object has the player tag
        foreach(Collider2D hit in hits){
            if (hit.gameObject.tag.Equals("Player")) {
                onPlayerHit();
            }
        }

    }

    // Editor info:
    void OnDrawGizmosSelected() {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // This method may be overwritten to move to different positions;
    virtual public void onPlayerHit(){
        this.stm.initialiseLayout(this.numberOfRooms);
        this.stm.goToScene(stm.getFirstRoom().getSceneID());
    }
}
