using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    private Vector2 _offset;
    private float _cameraZOffset;

    private void Start()
    {
        _offset = new Vector2(0, 0);
        _cameraZOffset = this.transform.position.z;
    }
    private void FixedUpdate()
    {
        var desiredPosition = (Vector2)target.position + _offset;
        
        //Adds jitter, but it's currently desirable
        Vector3 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = _cameraZOffset;
        transform.position = smoothedPosition;
    }
}