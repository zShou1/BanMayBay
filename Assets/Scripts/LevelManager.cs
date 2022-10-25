using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelTable levelTable;

    private int currentEnemyDestroy;

    private void Start()
    {
        StartCoroutine(CreateLevel());
    }

    public IEnumerator CreateLevel()
    {
        for (int i = 0; i < levelTable.waveList.Count; i++)
        {
            currentEnemyDestroy = 0;
            LevelTable.Wave wave = levelTable.waveList[i];
            for (int j = 0; j < wave.orbitList.Count; j++)
            {
                StartCoroutine(SpawnEnemyOrbit(wave.orbitList[j]));
            }

            yield return new WaitUntil(() => (currentEnemyDestroy == wave.TotalEnemy));
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
