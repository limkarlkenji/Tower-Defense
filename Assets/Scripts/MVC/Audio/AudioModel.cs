using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Model/Audio")]
public class AudioModel : BaseModel
{
    [Header("BGM")]
    public AudioClip mainMenuBGM;
    public AudioClip gameBGM;

    [Header("Game")]
    public AudioClip playerLoseLife;
    public AudioClip goldSpend;
    public AudioClip towerBuild;
    public AudioClip towerFire;
    public AudioClip towerSell;
    public AudioClip enemyKill;

    [Header("UI")]
    public AudioClip buttonClick;
}
