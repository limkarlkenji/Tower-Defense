using UnityEngine;

public class CameraController : BaseController<CameraModel>
{
    public void EdgeScroll(Vector2 mouse, Camera camera, Vector3 origin)
    {
        Vector3 newPos = camera.transform.position;

        if (mouse.x <= 0)
        {
            newPos += (Vector3.right * Model.panSpeed) * Time.deltaTime;
        }
        else if (mouse.x >= Screen.width)
        {
            newPos += (Vector3.left * Model.panSpeed) * Time.deltaTime;
        }

        if (mouse.y <= 0)
        {
            newPos += (Vector3.forward * Model.panSpeed) * Time.deltaTime;
        }
        else if (mouse.y >= Screen.height)
        {
            newPos += (Vector3.back * Model.panSpeed) * Time.deltaTime;
        }

       
        newPos.x = Mathf.Clamp(newPos.x, origin.x + Model.horizontalEdgeScroll.x, origin.x + Model.horizontalEdgeScroll.y);
        newPos.z = Mathf.Clamp(newPos.z, origin.z + Model.verticalEdgeScroll.x, origin.z + Model.verticalEdgeScroll.y);

        camera.transform.position = newPos;
    }
}
