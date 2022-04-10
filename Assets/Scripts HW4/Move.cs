using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.forward * 0.05f;
        }
        else if (Input.GetKey("a"))
        {
            transform.position -= Vector3.right * 0.05f;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= Vector3.forward * 0.05f;
        }
        else if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * 0.05f;
        }
    }
}
