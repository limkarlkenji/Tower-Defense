using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class LevelController : BaseController<LevelModel>
{
    public IEnumerator cSpawnWave(int count, int wave, Map currentMap, Action onSpawnComplete, Action<float> OnEnemyKill)
    {
        EnemyData enemyData = Model.waveSet.waves[wave].enemy;

        int i = 0;
        while (i < count)
        {
            i++;
            GameObject enemy = GameObject.Instantiate(enemyData.prefab, currentMap.enemyParent);
            enemy.transform.position = currentMap.spawnPosition.position;

            Enemy e = enemy.GetComponent<Enemy>();

            e.SetProperties(enemyData);
            e.Move(currentMap.path);
            e.OnKill += () => { OnEnemyKill?.Invoke(e.goldReward); };

            yield return new WaitForSeconds(Model.spawnRate);
        }
        onSpawnComplete?.Invoke();
    }

    public IEnumerator cWaitForWaveComplete(Transform enemyParent, Action onWaveComplete)
    {
        while(enemyParent.childCount > 0)
        {
            yield return null;
        }
        onWaveComplete?.Invoke();
    }

    public IEnumerator cWaitForNextWave(float interval, Action onWaitComplete)
    {
        yield return new WaitForSeconds(interval);
        onWaitComplete?.Invoke();
    }
}
