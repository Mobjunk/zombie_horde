using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MapSizeSelector : MonoBehaviour
{
    [SerializeField] private Dropdown mapSizeDropdown;

    private void Awake()
    {
        mapSizeDropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach (var mapsize in Enum.GetValues(typeof(RandomLevelGenerator.MapSizes)))
        {
            options.Add(mapsize.ToString());
        }

        mapSizeDropdown.AddOptions(options);
        mapSizeDropdown.value = PlayerPrefs.GetInt("MapSizeDropDown");
    }

    public void SetMapSize()
    {
        PlayerPrefs.SetString("MapSize", mapSizeDropdown.options[mapSizeDropdown.value].text);
        PlayerPrefs.SetInt("MapSizeDropDown", mapSizeDropdown.value);
    }
}
