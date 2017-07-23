using UnityEngine;
using System.Collections;
using System;

public class MoveScript : MonoBehaviour
{
    public float speed;

    private Coroutine currCoroutine = null;

    private IEnumerator MoveToPoint(Vector3 point, Action onArriveCallback)
    {
        while(transform.position != point)
        {
            Vector3 dirV = point - transform.position;
            float deltaSpeed = speed * Time.deltaTime;
            if (dirV.sqrMagnitude > deltaSpeed * deltaSpeed)
            {
                transform.Translate(dirV.normalized * deltaSpeed);
            }
            else
            {
                transform.position = point;
            }
            yield return null;
        }
        currCoroutine = null;
        if(onArriveCallback != null)
            onArriveCallback();
    }

    public void StartMove(Vector3 point, Action onArriveCallback = null)
    {
        if (currCoroutine != null)
            StopCoroutine(currCoroutine);
        currCoroutine = StartCoroutine(MoveToPoint(point, onArriveCallback));
    }

    public void StopMove()
    {
        if (currCoroutine != null)
        {
            StopCoroutine(currCoroutine);
            currCoroutine = null;
        }
    }
}
