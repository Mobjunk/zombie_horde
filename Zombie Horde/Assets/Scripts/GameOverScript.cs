using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;
    [SerializeField] private Text gameoverText;
    [SerializeField] private DayNightCycle dayNightCycle;
    [SerializeField] private GameObject[] ObjectsToDisable;

    public void OpenGameoverMenu()
    {
        gameoverMenu.SetActive(true);
        foreach (var item in ObjectsToDisable)
        {
            item.SetActive(false);
        }

        if (dayNightCycle.daysPassed == 1)
        {
            gameoverText.text = "You died after " + dayNightCycle.daysPassed + " day.";
        }
        else
        {
            gameoverText.text = "You died after " + dayNightCycle.daysPassed + " days.";
        }
    }
}
