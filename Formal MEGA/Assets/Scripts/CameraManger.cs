using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    public PlayerControls controls;

    [SerializeField] private GameObject[] cameraList;
    public int cameraIndex = 0;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controls = new PlayerControls();
        nextCamera();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        controls.PlayerMap.CameraSwtich.performed += ctx => nextCamera();
    }

    private void nextCamera()
    {
        cameraIndex++;
        if(cameraIndex == cameraList.Length) {
            cameraIndex = 0;
        }
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].SetActive(false);
        }
        cameraList[cameraIndex].SetActive(true); 
    }
    private void OnEnable()
    {
        controls.PlayerMap.Enable();
    }
    private void OnDisable()
    {
        controls.PlayerMap.Disable();
    }
}
