using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footballProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> projectiles = new List<GameObject>();
    public rotateToMouse rotateToMouse;

    public GameObject effectToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = projectiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton (0))
        {
            SpawnFtball();
        }
    }

    void SpawnFtball()
    {
        GameObject projectile;

        if (firePoint != null)
        {
            projectile = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            
             if (rotateToMouse != null)
            {
                projectile.transform.localRotation = rotateToMouse.getRotation();
            }
            
        } else
        {
            Debug.Log("No Fire Point");
        }

    }
}
