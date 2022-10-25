using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Character
{

    [SerializeField] private string hub;
    private SceneTransitionManager sceneManager;
    [SerializeField] public bool isInvinceble;
    [SerializeField] public float invincebilityTime;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        sceneManager = FindObjectOfType<SceneTransitionManager>();
    }

    public override void death()
    {
        if (this.health <= 0)
        {
            // this.gameObject.destroy();
            sceneManager.goToScene(SceneTransitionManager.getHubID());
        }
    }

    public override void updateHealth(float amount)
    {
        health -= amount;
        death();
        StartCoroutine(invincebility());
    }

    IEnumerator invincebility()
    {
        isInvinceble = true;
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(invincebilityTime);
        isInvinceble = false;
    }
}
