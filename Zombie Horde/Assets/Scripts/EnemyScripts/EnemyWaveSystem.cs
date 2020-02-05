using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public EnemyObject enemyObject;
        public float chance = 0;
        public int spawnAfterDays = 0;
    }

    [SerializeField] private DayNightCycle dayNightCycle;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private float timer = 0;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private bool hasSpawned = false;
    [SerializeField] private EnemySpawnData[] enemySpawnDatas;

    [SerializeField] private int startingAmount = 2;
    [SerializeField] private int zombiesPerDay = 2;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle.GetComponent<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dayNightCycle.IsNight())
        {
            if(hasSpawned == false){
                if (isSpawning == false)
                {
                    Debug.Log("start wave");
                    isSpawning = true;
                    StartCoroutine(SpawningEnemies());
                }
            }
        }
        if (!dayNightCycle.IsNight())
        {
            hasSpawned = false;
        }
    }

    // IEnumerator for spawning the enemies, will wait 2 seconds and call the fuction EnemySpawning() 
    IEnumerator SpawningEnemies()
    {
        hasSpawned = true;
        for (int i = 0; i < startingAmount + zombiesPerDay * dayNightCycle.daysPassed; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(dayNightCycle.dayNightCycleMin * (1f / 24f * ((24 - dayNightCycle.startNight) + dayNightCycle.endNight)) * 60f / (startingAmount + zombiesPerDay * dayNightCycle.daysPassed));
        }
        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        float change = Random.Range(0, 1000);
        float currentChange = 0;

        foreach (var enemySpawnData in enemySpawnDatas)
        {
            if (dayNightCycle.daysPassed >= enemySpawnData.spawnAfterDays)
            {
                if (change < enemySpawnData.chance * 10 + currentChange)
                {
                    enemySpawner.EnemySpawning(enemySpawnData.enemyObject, dayNightCycle);
                    return;
                }
                else
                {
                    currentChange += enemySpawnData.chance * 10;
                }
            }
        }

        enemySpawner.EnemySpawning(enemySpawnDatas[0].enemyObject, dayNightCycle);
    }
}
