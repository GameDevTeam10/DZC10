using System.Collections;
using System.Collections.Generic;

// The State abstract class defines a state, for polymorphism usages in the StateMachine (which is a concrete implementation)
[System.Serializable]
public abstract class State {
    // A state should know which enemy (statemachine) it is a part of, for update purposes
    public Enemy enemy; 

    // Constructor: 
    public State(Enemy enemy){
        this.enemy = enemy;
    }

    // function for the state to update it self! 
    public void goToNextState(State nextState) {
        this.enemy.updateStateMachine(nextState);
    }

    // StateMachine should call this on state change!
    abstract public void stateStart();

    // StateMachine should call this every single frame!
    abstract public void stateUpdate();

    // StateMachine should call this on termination
    abstract public void stateEnd();
}
