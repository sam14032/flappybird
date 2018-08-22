using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour
{
	private SpriteRenderer[] backgroundIMG;
	private SpriteRenderer[] foregroundIMG;
	private int maxGameWidth;
	private float halfIMGsize;
	private void Awake()
	{
		backgroundIMG = GameObject.Find("Back").GetComponentsInChildren<SpriteRenderer>();
		foregroundIMG = GameObject.Find("Front").GetComponentsInChildren<SpriteRenderer>();
		maxGameWidth = Camera.main.pixelWidth;
		halfIMGsize = backgroundIMG[0].size.x / 2;
	}

	// Use this for initialization
	void Start () {
		DisplayIMG();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void DisplayIMG()
	{
		for (int i = 0; i < backgroundIMG.Length; ++i)
		{
			backgroundIMG[i].transform.position = new Vector3(maxGameWidth - i * 2 * halfIMGsize,
				backgroundIMG[i].transform.position.y,
				backgroundIMG[i].transform.position.z);
			
			foregroundIMG[i].transform.position = new Vector3(maxGameWidth - i * 2 * halfIMGsize,
				foregroundIMG[i].transform.position.y,
				foregroundIMG[i].transform.position.z);
		}
	}
	
}
