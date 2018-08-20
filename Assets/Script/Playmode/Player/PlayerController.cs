using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    TranslateMover translateMover;
    [SerializeField]
    private KeyCode upKey = KeyCode.W;
    [SerializeField]
    private KeyCode leftKey = KeyCode.A;
    [SerializeField]
    private KeyCode downKey = KeyCode.S;
    [SerializeField]
    private KeyCode rightKey = KeyCode.D;

    // Use this for initialization
    void Start ()
    {
        translateMover = GetComponent<TranslateMover>();

    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void GetInput()
    {

        if (Input.GetKeyDown(upKey))
        {
            translateMover.Move(Vector3.up);
        }
        if (Input.GetKeyDown(leftKey))
        {
            translateMover.Move(Vector3.left);
        }
        if (Input.GetKeyDown(downKey))
        {
            translateMover.Move(Vector3.down);
        }
        if (Input.GetKeyDown(rightKey))
        {
            translateMover.Move(Vector3.right);
        }
    }
    
}
