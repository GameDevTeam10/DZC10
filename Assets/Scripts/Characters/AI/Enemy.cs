using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


// This abstract class defines the stateMachine used by enemies.
public class Enemy : Character {

    [SerializeField] private string enemyName;

    [SerializeField] private float sightDistance;
    [SerializeField] private float attackRange;
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;

    [SerializeField] private State currentState;
    private State previousState = null;

    public GameObject player;
    public Detection detector;

    public AIDestinationSetter aiDest;

    void Start() {
        // Update generic character initialisation
        base.Start();

        // Enemy specific initialisation:
        initialiseEnemy();
        initialiseDetector();

        // Find the player object
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        // Update generic character update
        base.Update();

        // Enemy specific update:
        updateEnemy();
    }

    private void initialiseEnemy() {
        aiDest = this.GetComponent<AIDestinationSetter>();
        // Check if state is set 
        this.currentState = null;
        this.previousState = null;
        this.currentState = new IdleState(this);
        this.currentState.stateStart();
    }

    private void initialiseDetector() {
        detector = this.GetComponent<Detection>();
        detector.AttackRange = this.attackRange;
        detector.detectorSize = this.sightDistance;
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

    public void attack() {
        if (detector.PlayerInAttackRange) {
            StartCoroutine(Attacking);
        }
    }

    IEnumerator Attacking() {
        player. -= damage;
        yield return new WaitForSeconds(cooldown);
    }
}