using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : BaseView<CameraModel, CameraController>
{
    [SerializeField] private Camera mainCamera;

    private Vector3 _origin;

    // Start is called before the first frame update
    void Start()
    {
        _origin = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Controller.EdgeScroll(Mouse.current.position.ReadValue(), mainCamera, _origin);
    }
}
