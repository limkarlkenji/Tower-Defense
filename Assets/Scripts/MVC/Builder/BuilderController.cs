using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : BaseController<BuilderModel>
{
    public Tower Build(TowerData tower, TowerTile towerBase, Transform towerParent, ObjectPool pool, Action<Tower> OnBuildComplete)
    {
        GameObject g = GameObject.Instantiate(tower.prefab, towerParent);
        g.transform.position = new Vector3(towerBase.transform.position.x, 1, towerBase.transform.position.z);

        Tower t = g.GetComponent<Tower>();
        t.SetProperties(tower, towerBase, pool);

        OnBuildComplete?.Invoke(t);
        return t;

    }
}
