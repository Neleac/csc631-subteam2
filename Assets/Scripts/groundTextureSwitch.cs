using UnityEngine;
using System.Collections;

public class groundTextureSwitch : MonoBehaviour
{
    public GameObject ground;
    public Material[] materials;
    public int currentMaterial;

    public void TextureSwitch()
    {
        currentMaterial++;
        currentMaterial %= materials.Length;
        ground.GetComponent<MeshRenderer>().material = materials[currentMaterial];

    }
}
