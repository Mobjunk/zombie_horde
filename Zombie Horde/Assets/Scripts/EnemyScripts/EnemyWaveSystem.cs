using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    [SerializeField] private DayNightCycle dnc;
    [SerializeField] private EnemySpawner es;
    [SerializeField] private float timer = 0;
    

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
            timer += Time.deltaTime;
            if(timer < 0.04f)
            {
                es.EnemySpawning();
                es.howManyEnemies += 1;
            }
            
        }
        
        if(!dnc.IsNight())
        {
            return;
        }
    }
}
