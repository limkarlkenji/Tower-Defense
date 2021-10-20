using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioView : BaseView<AudioModel, AudioController>
{
    //[SerializeField] private AudioSource _as;

    public void TowerBuild(AudioSource audioSource)
    {
        audioSource.clip = Model.towerBuild;
        audioSource.Play();
    }

    public void TowerSell()
    {

    }

    public void TowerFire()
    {

    }

    public void EnemyKill()
    {

    }
}
