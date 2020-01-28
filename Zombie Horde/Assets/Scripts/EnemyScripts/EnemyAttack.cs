using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAttack : MonoBehaviour
{
    BuildingSystem buildingSystem;
    // Start is called before the first frame update
    void Start()
    {
        buildingSystem = FindObjectOfType<BuildingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        buildingSystem.DestroyStructure(collision.GetContact(0).point);
    }
}
