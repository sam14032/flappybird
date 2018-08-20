using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    [SerializeField]
    private float speed = 5;
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
