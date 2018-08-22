using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveWorld : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private float speed = 0.003f;
	private SpriteRenderer backgroundIMG;
	private GameObject[] worldObjectList;
	private float maxGameWidth;
	private float imgSize;
	private Camera cam;
	private float width;
	private int numberOfPrefab;
	private float height;
	float highestYPosition;
	
	private void Awake()
	{
		backgroundIMG = GameObject.Find("Background").GetComponent<SpriteRenderer>();
		cam = Camera.main;
		height = cam.orthographicSize * 2f;
		width = height * cam.aspect;
		maxGameWidth = width;
		transform.position = Vector3.right*-maxGameWidth/2f;
		imgSize = backgroundIMG.size.x;
		numberOfPrefab = (int)(maxGameWidth / imgSize)+3;
		worldObjectList = new GameObject[numberOfPrefab];
		CreatePrefab();
		PositionObject();
		highestYPosition = worldObjectList[numberOfPrefab - 1].transform.position.x;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckIfCamSizeChanged())
		{
			transform.position = Vector3.right*-maxGameWidth/2f;
			CreatePrefab();
			PositionObject();
		}
		MovePrefab();
	}

	private void ChangeNumberOfPrefab()
	{
		imgSize = backgroundIMG.size.x;
		numberOfPrefab = (int)(maxGameWidth / imgSize)+3;
	}
	private void CreatePrefab()
	{
		if (worldObjectList[0] != null)
		{
			DeleteOldPrefab();
			ChangeNumberOfPrefab();
			worldObjectList = new GameObject[numberOfPrefab];
		}
		for (int i = 0; i < numberOfPrefab; ++i)
		{
			worldObjectList[i] = Instantiate(prefab, transform.position, Quaternion.identity);
		}
	}

	private void PositionObject()
	{
		for (int i = 0; i < numberOfPrefab; ++i)
		{
			worldObjectList[i].transform.position = transform.position + new Vector3(0.9f * i * imgSize,0,0);
		}
	}

	bool CheckIfCamSizeChanged()
	{
		cam = Camera.main;
		height = cam.orthographicSize * 2f;
		float currentCamSize = height * cam.aspect;
		if (currentCamSize != width)
		{
			width = currentCamSize;
			maxGameWidth = width;
			return true;
		}
		return false;
	}

	void DeleteOldPrefab()
	{
		for (int i = 0; i < numberOfPrefab; ++i)
		{
			worldObjectList[i].SetActive(false);
		}
	}
	private void MovePrefab()
	{
		for (int i = 0; i < numberOfPrefab; ++i)
		{
			worldObjectList[i].transform.position = worldObjectList[i].transform.position - new Vector3(speed,0,0)*Time.deltaTime;
		}
		MovePrefabBack();
	}

	void MovePrefabBack()
	{
		for (int i = 0; i < numberOfPrefab; ++i)
		{
			if (worldObjectList[i].transform.position.x + imgSize / 2 < -(maxGameWidth / 2 -0.5))
			{
				worldObjectList[i].transform.position =
					new Vector3(highestYPosition,
						transform.position.y,
						transform.position.z);
				highestYPosition = worldObjectList[i].transform.position.x;
			}
		}
	}
	
}
