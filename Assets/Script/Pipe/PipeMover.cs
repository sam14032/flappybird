using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour {

    [SerializeField]
    private float speed = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.root.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
