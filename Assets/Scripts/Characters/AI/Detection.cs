using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public bool PlayerDetected {get; private set;}
    public bool PlayerInAttackRange {get; private set;}

    [Header("OverlapcircleSight")]
    [SerializeField]
    public float detectorSize = 4.0f;
    public Vector2 offset = Vector2.zero;

    [SerializeField] public float delay = 0.05f;

    public LayerMask detectorLayerMask;
    public LayerMask objectLayer;

    [Header("OverlapcircleAttack")]
    [SerializeField]
    public float AttackRange = 1.0f;
    public Vector2 offsetAttack = Vector2.zero;

    [Header("Gizmos")]
    public Color gizmoNotActivatedColor = Color.green;
    public Color gizmoActivatedColor = Color.red;
    public bool showGizmos = true;

    private GameObject target;
    private GameObject attackTarget;
    private Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        detectorLayerMask = LayerMask.GetMask("Player");
        objectLayer = LayerMask.GetMask("Obstacles");
        StartCoroutine(DetectionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Target {
        get => target;
        private set {
            target = value;
            PlayerDetected  = target != null;
        }
    }

    public GameObject AttackTarget {
        get => attackTarget;
        private set {
            attackTarget = value;
            PlayerInAttackRange  = attackTarget != null;
        }
    }

    //Using this we do not detect every frame, like in Update(), but instead check every delay interval
    IEnumerator DetectionCoroutine() {
        yield return new WaitForSeconds(delay);
        Detect();
        
        if (PlayerDetected) {
            attackDetect();
        }

        StartCoroutine(DetectionCoroutine());
    }

    public void Detect() {
        Collider2D collider = Physics2D.OverlapCircle((Vector2)this.transform.position + offset, detectorSize, detectorLayerMask);
        Target = null;

        if (collider is not null) {
          // if(doRaycast(collider.gameObject)) {
                Target = collider.gameObject;
          //  }
        }
    }
    
    public void attackDetect() {
        Collider2D collider = Physics2D.OverlapCircle((Vector2)this.transform.position + offset, AttackRange, detectorLayerMask);

        if (collider is not null) {
            AttackTarget = collider.gameObject;
            
        } else {
            AttackTarget = null;
        }
    }

    private bool doRaycast(GameObject target) {
        Vector3 direction = (this.transform.position - target.transform.position).normalized;
        Vector2 direction2d = new Vector2(direction.x, direction.y);
        RaycastHit2D detectedObjects = Physics2D.Raycast(this.transform.position, direction2d, Vector2.Distance(this.transform.position, target.transform.position), objectLayer);
        return detectedObjects.collider is not null;
    }

    public void OnDrawGizmos(){
        if (showGizmos && this.transform is not null) {
            Gizmos.color = gizmoNotActivatedColor;
            
            if (PlayerDetected) {
                Gizmos.color = gizmoActivatedColor;
            }
            Gizmos.DrawWireSphere((Vector2)this.transform.position + offset, detectorSize);           
        }
    }

}
