using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : BaseView<CameraModel, CameraController>
{
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.position.ReadValue().x <= 0)
        {
            mainCamera.transform.position += (Vector3.right * Model.panSpeed) * Time.deltaTime;
        }
        else if(Mouse.current.position.ReadValue().x >= Screen.width)
        {
            mainCamera.transform.position += (Vector3.left * Model.panSpeed) * Time.deltaTime;
        }

        if (Mouse.current.position.ReadValue().y <= 0)
        {
            mainCamera.transform.position += (Vector3.forward * Model.panSpeed) * Time.deltaTime;
        }
        else if (Mouse.current.position.ReadValue().y >= Screen.height)
        {
            mainCamera.transform.position += (Vector3.back * Model.panSpeed) * Time.deltaTime;
        }
    }
}
