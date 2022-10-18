using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spikes : PortalManager {

    [SerializeField] [Range(1, 10)] private int damagePerHit;
    public override void onPlayerHit() {
        GameObject playerObject = this.getPlayer();
        Character player = playerObject.GetComponent<Character>();

        player.takeDamage(damagePerHit);

        this.tempDeactivePortal();
    }

}
