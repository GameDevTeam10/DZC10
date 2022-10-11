using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This abstract class defines the stateMachine used by enemies.
public abstract class Enemy : Character {

    [SerializeField] private State currentState;
    private State previousState = null;

    void Start() {
        // Update generic character initialisation
        base.Start();

        // Enemy specific initialisation:
        initialiseEnemy();     
    }

    void Update() {
        // Update generic character update
        base.Update();

        // Enemy specific update:
        updateEnemy();
    }

    private void initialiseEnemy() {
        // Check if state is set 
        this.currentState = null;
        this.previousState = null;
        this.currentState = new IdleState(this);
        this.currentState.stateStart();
    }

    private void updateEnemy() {
        // update according to the current state
        this.currentState.stateUpdate();
    }

    // This function updates the statemachine to its next state. Called by states!
    public void updateStateMachine(State newState) {
        // End current state
        this.currentState.stateEnd();
        // Set new state
        this.previousState = this.currentState;
        this.currentState = newState;
        this.currentState.stateStart();
    }
}
