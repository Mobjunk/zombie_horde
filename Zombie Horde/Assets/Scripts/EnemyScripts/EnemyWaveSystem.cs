using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    public DayNightCycle dnc;

    // Start is called before the first frame update
    void Start()
    {
        dnc.GetComponent<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
