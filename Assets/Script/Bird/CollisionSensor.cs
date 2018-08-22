using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisonSensorEventHandler();

public class CollisionSensor : MonoBehaviour {
	
	public event CollisonSensorEventHandler OnCollision;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		NotifyCollisionSensed();
		
	}
	
	private void NotifyCollisionSensed()
	{

		if (OnCollision !=null)
		{
			OnCollision();
		}
	}
}
