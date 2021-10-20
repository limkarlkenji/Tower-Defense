using System;
using UnityEngine;

public class BuilderView : BaseView<BuilderModel, BuilderController>
{
    [Header("References")]
    [SerializeField] private UIView ui;
    [SerializeField] private AudioView sound;
    [SerializeField] private PlayerView player;

    [SerializeField] private Transform towerParent;

    public void TowerTileClicked(GameObject clicked, TowerTile tt, ObjectPool pool)
    {
        if(tt == null) { return; }
        if(tt.Tower != null)
        {

        }
        else
        {
            ui.DisplayTowerList(Model.towers, (tower) => { Build(tower, tt, pool); });
        }
    }

    public void Build(TowerData tower, TowerTile towerBase, ObjectPool pool)
    {
        if(player.HasEnoughCoins(tower.cost))
        {
            Controller.Build(tower, towerBase, towerParent, pool, 
                (newTower) => { 
                    player.SpendCoins(tower.cost);
                    sound.TowerBuild(newTower.AudioSource);
                });
        }
        else
        {
            Debug.Log("Not enough");
        }
    }
}
