using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipSystem : MonoBehaviour
{
    [System.Serializable]
    public class ToolTipData
    {
        public ToolTip toolTip;
        [HideInInspector] public bool shown = false;
    }

    [Header("Reference")]
    [SerializeField] private GameObject toolTipHolder;
    [SerializeField] private Text toolTipNameText;
    [SerializeField] private Text toolTipDescriptionText;
    [Space]
    [Header("Tooltips")]
    [SerializeField] private ToolTipData reloadGun;
    [SerializeField] private ToolTipData openInventory;
    [SerializeField] private ToolTipData openCrafting;
    [SerializeField] private ToolTipData movement;
    [Space]
    [Header("Settings")]
    [SerializeField] private float toolTipCooldownSec = 5;
    [SerializeField] private float toolTipShowTimeSec = 15;

    private float tooltipDelay = 0;
    private ToolTip currentToolTip;

    private void Start()
    {
        ShowToolTip(movement);
    }

    // Update is called once per frame
    void Update()
    {
        if (!OpenPauseMenu.pauseMenuOpen && PlayerHealth.playerAlive)
        {
            if (currentToolTip && toolTipHolder.activeSelf)
            {
                currentToolTip.ToolTipComplete(this);
            }
            if (!openInventory.shown)
            {
                openInventory.shown = openInventory.toolTip.ButtonAlreadyPressed();
            }
            if (!openCrafting.shown)
            {
                openCrafting.shown = openCrafting.toolTip.ButtonAlreadyPressed();
            }

            if (Time.time > tooltipDelay && !toolTipHolder.activeSelf)
            {
                float chance = Random.Range(0, 100);
                if (chance < 50 && !openInventory.shown)
                {
                    ShowToolTip(openInventory);
                }
                else if (chance < 100 && !openCrafting.shown)
                {
                    ShowToolTip(openCrafting);
                }
            }
        }
    }

    private void ShowToolTip(ToolTipData tooltip)
    {
        toolTipHolder.SetActive(true);
        tooltip.shown = true;
        tooltip.toolTip.LoadToolTip(toolTipNameText, toolTipDescriptionText);
        currentToolTip = tooltip.toolTip;
        StartCoroutine(HideTimer());
    }

    private IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(toolTipShowTimeSec);
        HideToolTip();
    }

    public void HideToolTip()
    {
        toolTipHolder.SetActive(false);
        tooltipDelay = Time.time + toolTipCooldownSec;
    }
}
