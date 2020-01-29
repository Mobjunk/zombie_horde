using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    [SerializeField] private DayNightCycle dnc;
    [SerializeField] private EnemySpawner es;
    [SerializeField] private float timer = 0;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private bool hasSpawned = false;
    

    // Start is called before the first frame update
    void Start()
    {
        dnc.GetComponent<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dnc.IsNight())
        {
            if(hasSpawned == false){
                if (isSpawning == false)
                {
                    StartCoroutine(SpawningEnemies());
                    isSpawning = true;
                }
            }
        }
        if (!dnc.IsNight())
        {
            hasSpawned = false;
        }
    }

    IEnumerator SpawningEnemies()
    {
        yield return new WaitForSeconds(2);
        es.EnemySpawning();
        es.days++;
        hasSpawned = true;
        isSpawning = false;
        
    }
}
