using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Model/Camera")]
public class CameraModel : BaseModel
{
    public float panSpeed;
    public Vector2 horizontalEdgeScroll;
    public Vector2 verticalEdgeScroll;
}
