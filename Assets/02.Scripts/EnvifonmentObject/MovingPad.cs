using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPad : MonoBehaviour
{
    public Transform padTransform;
    public float PadSpeed;


    private void FixedUpdate()
    {
        if (padTransform == null)
        {
            padTransform = transform;
        }
        Vector3 newPosition = padTransform.position;
        newPosition.x += Mathf.Sin(Time.time) * PadSpeed;
        padTransform.position = newPosition;
    }

}
