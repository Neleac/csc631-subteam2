using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cube;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = cube.position + offset;
    }
}
