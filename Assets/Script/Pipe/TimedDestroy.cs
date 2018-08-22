using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    [SerializeField]
    private float destroyDelayInSeconds = 10f;

    private void OnEnable()
    {
        StartCoroutine(DestroyRoot());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DestroyRoot()
    {
        yield return new WaitForSeconds(destroyDelayInSeconds);
        Destroy(transform.root.gameObject);
    }
}
