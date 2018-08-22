using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    [SerializeField] private KeyCode spaceKey = KeyCode.Space;
    private CollisionSensor collisionSensor;
    private BirdPhysics birdPhysics;

    private BirdDeathEventChannel birdDeathEventChannel;
    private GameController gameController;
    private void Awake()
    {
        var root = transform.root;
        collisionSensor = root.GetComponentInChildren<CollisionSensor>();
        birdPhysics = root.GetComponentInChildren<BirdPhysics>();
        birdDeathEventChannel = GameObject.FindWithTag(Tags.GameController)
            .GetComponent<BirdDeathEventChannel>();
        gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
        
    }

    // Use this for initialization
    void Start ()
    {
    }
    
    private void OnEnable()
    {
        collisionSensor.OnCollision += Die;
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (gameController.IsGameStarted)
        {
            GetInput();
        }
        else if (transform.root.position.y < -0.5)
        {
            Fly();
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(spaceKey))
        {
            birdPhysics.Flap();
        }
    }

    private void Fly()
    {
        birdPhysics.Flap();
    }
    private void OnDisable()
    {
        collisionSensor.OnCollision -= Die;
    }
    
    private void Die()
    {
        Hide();
        NotifyBirdDeath();
    }
    
    private void Hide()
    {
        transform.root.gameObject.SetActive(false);
    }
    
    private void NotifyBirdDeath()
    {
        birdDeathEventChannel.Publish();
    }
}
