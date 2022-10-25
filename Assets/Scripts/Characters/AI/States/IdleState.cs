using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public IdleState(Enemy enemy) : base(enemy) { }

    public override void stateStart()
    {
        Debug.Log("Start");
    }

    public override void stateUpdate()
    {
        Debug.Log(this.enemy.detector.PlayerDetected);
        if (this.enemy.detector.PlayerDetected)
        {
            this.enemy.updateStateMachine(new WalkToState(this.enemy));
        }
    }

    public override void stateEnd()
    {
        Debug.Log("end");
    }
}
