using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BirdCollisionSensorEventHandler();
public class BirdSensor : MonoBehaviour
{

	public event BirdCollisionSensorEventHandler onCollision;

	private PipeController pipeController;

	private void Awake()
	{
		pipeController = transform.root.GetComponentInChildren<PipeController>();
		onCollision += pipeController.NotifyPipePassed;
	}

	private void OnDestroy()
	{
		onCollision -= pipeController.NotifyPipePassed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			NotifyBirdSensed();
		}
	}
    
	private void NotifyBirdSensed()
	{
		if (onCollision != null)
		{
			onCollision();
		}
	}
	
}
