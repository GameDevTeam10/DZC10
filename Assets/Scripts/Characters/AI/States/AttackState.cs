using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State {

    public AttackState(Enemy enemy) : base(enemy) { }

    public override void stateStart() {
            
    }

    public override void stateUpdate() {
      if (this.enemy.detector.PlayerDetected) {
        this.enemy.updateStateMachine(new WalkToState(this.enemy));
      }
    }

    public override void stateEnd() {

    }
}
