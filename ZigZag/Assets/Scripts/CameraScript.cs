using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate() //used for camera updates
    {
        transform.position = target.position + offset;
    }
}
