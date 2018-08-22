using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPhysics : MonoBehaviour {


    private new Rigidbody2D rigidbody;
    [SerializeField]
    private float flapForce = 5;

    private void Awake()
    {
        rigidbody = transform.root.gameObject.AddComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flap()
    {
        rigidbody.velocity = Vector2.up * flapForce;
    }
}
