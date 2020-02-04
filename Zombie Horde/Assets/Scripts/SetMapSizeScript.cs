using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetMapSizeScript : MonoBehaviour
{
    public RandomLevelGenerator.MapSizes SetMapSize()
    {
        return (RandomLevelGenerator.MapSizes)Enum.Parse(typeof(RandomLevelGenerator.MapSizes), PlayerPrefs.GetString("MapSize"));
    }
}
