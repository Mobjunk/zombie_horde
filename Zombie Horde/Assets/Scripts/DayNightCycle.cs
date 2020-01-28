using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class DayNightCycle : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] [Range(0,24)]private float timeOfDay = 7;
    [SerializeField] private int daysPassed = 0;
    [SerializeField] [Range(0.05f, 240)] private float dayNightCycleMin = 2;
    [SerializeField] [Range(0, 24)] private float startNight = 20;
    [SerializeField] [Range(0, 24)] private float endNight = 6;
    [Space]
    [Header("Color")]
    [SerializeField] private AnimationCurve darknessTime;
    [SerializeField] private AnimationCurve redColorTime;
    [SerializeField] private AnimationCurve greenColorTime;
    [SerializeField] private AnimationCurve blueColorTime;
    [Space]
    [Header("Shadows")]
    [SerializeField] private AnimationCurve shadowsXPosition;
    [SerializeField] private AnimationCurve shadowsOpacity;
    [Space]
    [Header("References")]
    [SerializeField] private Image darknessImage;
    [SerializeField] private Transform shadowsTilemap;
    [SerializeField] private Tilemap shadowImage;

    // Update is called once per frame
    void Update()
    {
        ChangeTimeOfDay();
        ChangeColorsDarknessShadows();
    }

    private void ChangeTimeOfDay()
    {
        // Changes the time of day.
        if (timeOfDay >= 24)
        {
            timeOfDay = 0;
            daysPassed++;
        }
        else
        {
            timeOfDay += 24 / dayNightCycleMin / 60 * Time.deltaTime;
        }
    }

    private void ChangeColorsDarknessShadows()
    {
        // changes the color and opacity of a canvas panel to make it look darker or a different color.
        darknessImage.color = new Color(redColorTime.Evaluate(timeOfDay), greenColorTime.Evaluate(timeOfDay), blueColorTime.Evaluate(timeOfDay), darknessTime.Evaluate(timeOfDay));
        // Changes the X position of the tile map with shadows so it look like time passes
        shadowsTilemap.position = new Vector3(shadowsXPosition.Evaluate(timeOfDay), 0, 0);
        // changes the opicaty of the shadows so you don't have shadows in the night.
        shadowImage.color = new Color(0, 0, 0, shadowsOpacity.Evaluate(timeOfDay));
    }

    public bool IsNight()
    {
        if (timeOfDay < endNight || timeOfDay > startNight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
