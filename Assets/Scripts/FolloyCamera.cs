using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloyCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2F;
    // private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(0, 5, -6);
    void Update()
    {
        /*Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);*/
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothTime);
    }
}


