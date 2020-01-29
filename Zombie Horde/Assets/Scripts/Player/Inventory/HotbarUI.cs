using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private GameObject[] inventoryHotbar;
    private Player player;

    private void Awake()
    {
        player = GameManager.playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        UpdateHotbar();
    }

    void UpdateHotbar()
    {
        player.inventory.UpdateUI(inventoryHotbar);
    }
}
