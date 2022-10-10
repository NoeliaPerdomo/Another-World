using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    int currentCamera;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCamera++;
            if (currentCamera < cameras.Length)
            {
                cameras[currentCamera - 1].gameObject.SetActive(false);
                cameras[currentCamera].gameObject.SetActive(true);
            }
            else
            {
                cameras[currentCamera - 1].gameObject.SetActive(false);
                currentCamera = 0;
                cameras[currentCamera].gameObject.SetActive(true);
            }
        }
    }
}
