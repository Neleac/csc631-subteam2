using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToMouse : MonoBehaviour
{

    public Camera cam;
    public float maxLength;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxLength)) 
            {
                RotateToMouseDirection(gameObject, hit.point);
            } else
            {
                var pos = rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
        else
        {
            Debug.Log("No Camera");
        }
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        rotation.x = 0;
        rotation.z = 0;
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion getRotation ()
    {
        return rotation;
    }
}
