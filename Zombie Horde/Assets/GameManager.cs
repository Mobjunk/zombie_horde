using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public List<Item> itemDefinition = new List<Item>();

    public void Awake()
    {
        instance = this;
    }
}
