using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventChannelEventHandler();

public abstract class EventChannel : MonoBehaviour
{
	public event EventChannelEventHandler OnEventPublished;
    
	public void Publish()
	{
		if (OnEventPublished != null) OnEventPublished();
	}
}

