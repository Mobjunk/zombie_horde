using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure", menuName = "New Structure")]
public class BuildingObject : ScriptableObject
{
    public float structureHealth;

    public void SetUp(EnemyAttack ea)
    {
        ea.structureHealth = structureHealth;
    }
}
