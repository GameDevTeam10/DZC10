using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TelekinesisController))]
[RequireComponent(typeof(PlayerData))]
public class PlayerController : MonoBehaviour {
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    float inputHorizontal;
    float inputVertical;


    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator; 
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";
    const string PLAYER_WALK_UP = "Player_Walk_Up";

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Set the layers that a player can collide with:
        movementFilter.SetLayerMask(LayerMask.GetMask("Obstacles"));
    }

    void Update() {
        //Input
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (movementInput != Vector2.zero) {
            animator.enabled = true;
            if (inputHorizontal > 0) {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (inputHorizontal < 0) {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (inputVertical > 0) {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0) {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }

            bool success = TryMove(movementInput);

            if (!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
            }

            if (!success) {
                success = TryMove(new Vector2(0, movementInput.y));
            }
            
        }
        else {
            animator.enabled = false;
            //ChangeAnimationState(PLAYER_IDLE);
        }
    }

    private bool TryMove(Vector2 direction) {
            int count = rb.Cast(
                 direction,
                 movementFilter,
                 castCollisions,
                 moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else {
                return false;
            }
       
    }
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void ChangeAnimationState(string newState) {
        //Stop animation from interupting itself
        if (currentState == newState) return;

        //Play new animation
        animator.Play(newState);

        //Update current state
        currentState = newState;
    }
}
