using UnityEngine;
using UnityEngine.UI;

public class TowerDetailsUI : MonoBehaviour
{
    [SerializeField] private Text _damage;
    [SerializeField] private Text _fireRate;

    public void SetProperties(float damage, float fireRate)
    {
        _damage.text = damage.ToString();
        _fireRate.text = fireRate.ToString();
    }
}
