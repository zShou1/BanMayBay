using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelTable> levelTableList;
    [SerializeField]
    private LevelTable levelTable;

    private int currentEnemyDestroy;

    public GameObject winUI;

    [SerializeField] private HealthPlayer _healthPlayer;

    private void Start()
    {
        levelTable = levelTableList[GameManager.Instance.CurrentLevel - 1];
        StartCoroutine(CreateLevel());
        PlayerPrefs.SetInt("totalWave", levelTable.waveList.Count);
    }

    public IEnumerator CreateLevel()
    {
        for (int i = 0; i < levelTable.waveList.Count; i++)
        {
            PlayerPrefs.SetInt("currentWave", i+1);
            currentEnemyDestroy = 0;
            LevelTable.Wave wave = levelTable.waveList[i];
            for (int j = 0; j < wave.orbitList.Count; j++)
            {
                StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
            }
            
            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
            yield return null;
            if (i == levelTable.waveList.Count-1)
            {
                /*GameManager.Instance.TotalScore += GameManager.Instance.CurrentScore;*/
                yield return new WaitForSeconds(2f);
                Time.timeScale = 0f;
                _healthPlayer.SetLastLevelHealth();
                winUI.SetActive(true);
            }

        }
    }

    public IEnumerator SpawnEnemyOrbit(Orbit orbit)
    {
        yield return new WaitForSeconds(orbit.timeStart);
        for (int i = 0; i < orbit.enemyNum; i++)
        {
            Transform enemy = null;
            switch (orbit.enemyType)
            {
                case EnemyType.Enemy:
                    enemy = ObjectPutter.Instance.PutObject(SpawnerType.Enemy);
                    break;
                case EnemyType.mEnemy3:
                    enemy = ObjectPutter.Instance.PutObject(SpawnerType.mEnemy3);
                    break;
                case EnemyType.MediumEnemy:
                    enemy = ObjectPutter.Instance.PutObject(SpawnerType.MediumEnemy);
                    break;
                case EnemyType.Boss:
                    enemy = ObjectPutter.Instance.PutObject(SpawnerType.Boss);
                    break;
                case EnemyType.Enemy2:
                    enemy = ObjectPutter.Instance.PutObject(SpawnerType.Enemy2);
                    break;
            }

            BaseEnemy baseEnemy = enemy.GetComponent<BaseEnemy>();
            baseEnemy.Init(orbit.mainPath, orbit.additionPath, orbit.isRotateToPath);
            baseEnemy.OnEnemyDestroy += OnEnemyDestroyInWave;
            yield return new WaitForSeconds(orbit.timeDelay);
        }
    }

    private void OnEnemyDestroyInWave()
    {
        currentEnemyDestroy++;
    }


}
