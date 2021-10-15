using UnityEngine;

public class TowerRadius : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _tower.ScanForTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _tower.Target)
        {
            _tower.TargetLost();
        }
    }
}
