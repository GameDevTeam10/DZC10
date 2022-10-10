using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisController : MonoBehaviour {

    [SerializeField] [Range(0, 10)] private float mouseRadius = 0.8f;
    [SerializeField] [Range(1, 10)] private float strength = 2f;
    [SerializeField] [Range(0, 1)] private float minimalThrowLength = 0.1f;

    private TelekinesisObject telObject = null;
    private Vector2 lastPos = Vector2.zero;

    void Start() {
        
    }

    void Update() {
        //Look for element
        if (Input.GetMouseButtonDown(0) && telObject is null) {
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos3D.x, mousePos3D.y);

            //Find if there is an object we can drag!
            Collider2D[] hits = Physics2D.OverlapCircleAll(mousePos3D, mouseRadius);

            // Check if an object has the player tag
           
            foreach (Collider2D hit in hits){
                //try to find component
                telObject = hit.gameObject.GetComponent<TelekinesisObject>();
                if (!(telObject is null)) {
                    lastPos = new Vector2(hit.transform.position.x, hit.transform.position.y);
                    break;
                }
            }
        }
        //SHOOT
        else if (Input.GetMouseButtonUp(0)) {
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 newPos = new Vector2(mousePos3D.x, mousePos3D.y);
            Vector2 direction = (newPos - lastPos);
            
            //Check if initial throw was strong enough
            if (direction.magnitude < minimalThrowLength){
                Debug.Log("Too slow!");

                lastPos = Vector2.zero;
                telObject = null; //Reset mechanic
                return;
            }

            direction = direction.normalized;
            Vector2 poweredDirection = strength * Time.deltaTime * 100000 * direction;

            Rigidbody2D rigidBody2D = telObject.GetComponent<Rigidbody2D>();
            //Set rigidbody initial power to zero
            rigidBody2D.velocity = Vector2.zero;
            rigidBody2D.angularVelocity = 0f;

            rigidBody2D.AddForce(poweredDirection);

            lastPos = Vector2.zero;
            telObject = null; //Reset mechanic
        }

        //Update movement
        if(telObject is not null) {
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos3D.x, mousePos3D.y);
            telObject.transform.position = new Vector3(mousePos2D.x, mousePos2D.y, telObject.transform.position.z);

            lastPos = mousePos2D;
        }
    }

   
}
