using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

    [SerializeField]
    public GameObject prefab;


    private void OnEnable()
    {
        StartCoroutine(SpawnPrefabsRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnPrefabsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefab, transform.position + Vector3.right*5, Quaternion.identity);
    }
}
