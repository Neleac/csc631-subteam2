using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject topDownCamera;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (mainCamera.activeSelf) {
                topDownCamera.SetActive(true);
                mainCamera.SetActive(false);
            } else {
                mainCamera.SetActive(true);
                topDownCamera.SetActive(false);
            }
        }
    }
}
