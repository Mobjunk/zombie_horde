using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameObject playerObject;
    
    public List<Item> itemDefinition = new List<Item>();

    public void Awake()
    {
        instance = this;
        playerObject = GameObject.Find("Player");
    }
}
