using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Tilemap ground;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    void Start()
    {
        bottomLeftLimit = ground.localBounds.min;
        topRightLimit = ground.localBounds.max;
    }

 
    void LateUpdate()
    {
        //keep camera inside bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z);
    }
}
