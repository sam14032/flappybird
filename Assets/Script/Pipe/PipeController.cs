using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

    [SerializeField]
    int minY =-1, maxY =1;
    [Header("Piece")]
    [SerializeField]
    public GameObject pipeUp, pipeDown;
    [Header("Distance")]
    [SerializeField]
    int maxDistance =3, minDistance =1;

    private PipePassedEventChannel pipePassedEventChannel;
    private void Awake()
    {
        RandomizePipes();
        pipePassedEventChannel = GameObject.FindWithTag("GameController").
            GetComponent<PipePassedEventChannel>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void RandomizePipes()
    {
        RandomizePipePosition();
        RandomizePipeHeights();
    }
    private void RandomizePipeHeights()
    {
        var height = Random.Range(minY, maxY);
        transform.root.Translate(Vector3.up * height);
    }

    public void RandomizePipePosition()
    {
        var distance = Random.Range(minDistance, maxDistance)/2f;

        var halfPipeHeight = pipeDown.GetComponent<SpriteRenderer>().size.y/2f;

        var newPositionPipe = Vector3.up * halfPipeHeight + Vector3.up * distance;
        pipeUp.transform.localPosition = newPositionPipe;
        pipeDown.transform.localPosition = -newPositionPipe;

    }
    
    public void NotifyPipePassed()
    {
        pipePassedEventChannel.Publish();
    }
}
