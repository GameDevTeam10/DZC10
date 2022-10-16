using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WalkToState : State {

    public WalkToState(Enemy enemy) : base(enemy) { }

    public override void stateStart()
    {
        Debug.Log("Walk To" + enemy.player);
        enemy.aiDest.target = enemy.player.transform;
    }

    public override void stateUpdate()
    {
        
        if (this.enemy.detector.PlayerInAttackRange) {
            this.enemy.updateStateMachine(new AttackState(this.enemy));
        }
    }

    public override void stateEnd()
    {

    }
}
