using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }
}
