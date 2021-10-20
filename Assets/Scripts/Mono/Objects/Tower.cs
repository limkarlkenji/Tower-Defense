using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject projectileSpawn; 
    [SerializeField] private AudioSource _audioSource; 

    [Header("Properties")]
    [SerializeField] private string _towerName;
    [SerializeField] private Sprite _portrait;
    [SerializeField] private TowerTile _towerTile;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _target;
    [SerializeField] private ProjectileData _projectile;

    public string TowerName { get { return _towerName; } private set { _towerName = value; } }
    public Sprite Portrait { get { return _portrait; } private set { _portrait = value; } }
    public float FireRate { get { return _fireRate; } private set { _fireRate = value; } }
    public TowerTile TowerTile { get { return _towerTile; } private set { _towerTile = value; } }
    public GameObject Target { get { return _target; } private set { _target = value; } }
    public ProjectileData Projectile { get { return _projectile; } private set { _projectile = value; } }
    public AudioSource AudioSource { get { return _audioSource; } private set { _audioSource = value; } }

    [SerializeField] private Collider[] targetsInRange;

    private ObjectPool _pool;

    public void SetProperties(TowerData tData, TowerTile tTile, ObjectPool pool)
    {
        _pool = pool;

        TowerName = tData.towerName;
        Portrait = tData.sprite;
        FireRate = tData.fireRate;

        Projectile = tData.projectile;

        TowerTile = tTile;

        tTile.SetTower(this);
    }

    public void Sell()
    {
        _towerTile.SetTower(null);
        Destroy(gameObject);
    }

    public void TargetLost()
    {
        StopAllCoroutines();
        Target = null;
        //Debug.Log("Target Lost");
        ScanForTarget();
    }

    public void ScanForTarget()
    {
        if(Target == null)
        {
            FindTarget();
        }
    }

    public void FindTarget()
    {
        targetsInRange = Physics.OverlapSphere(transform.position, 5 * transform.localScale.x, LayerMask.GetMask("Enemy"));
        if (targetsInRange.Length != 0)
        {
            Target = GetClosest();
            StartCoroutine(cFire());
        }
    }

    private IEnumerator cFire()
    {
        while (true)
        {
            Fire(_pool.GetFromPool().GetComponent<Projectile>());
            yield return new WaitForSeconds(FireRate);
        }
       
    }

    private GameObject GetClosest()
    {
        if(targetsInRange == null) { return null; }

        Collider c = null;
        for(int i = 0; i < targetsInRange.Length; i++)
        {
            c = (c == null) ? targetsInRange[i] : (Vector3.Distance(transform.position, targetsInRange[i].transform.position) < (Vector3.Distance(transform.position, c.transform.position))) ? targetsInRange[i] : c;
        }

        return (c == null) ? null : c.gameObject;
    }

    private void Fire(Projectile p)
    {
        p.SetProperties(Projectile, projectileSpawn.transform, Target, (enemy) => {
            _pool.ReturnToPool(p.gameObject);
            if(enemy == null)
            {
                TargetLost();
            }
        });

    }
}
