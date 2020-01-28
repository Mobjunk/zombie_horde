using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject[] inventoryHotbar;
    private Player player;

    private void Awake()
    {
        player = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        UpdateHotbar();
    }

    void UpdateHotbar()
    {
        player.inventory.UpdateUI(inventoryHotbar);
        /*for (int i = 0; i < inventoryHotbar.Length; i++)
        {
            for (var index = 0; index < 9; index++)
            {
                var slot = inventoryHotbar[i].transform.GetChild(index);
                var slotImage = slot.GetComponent<Image>();
                if(index == player.inventorySlot) slotImage.color = new Color(1, 1, 1, 1);
                else slotImage.color = new Color(1, 1, 1, 0.588f);
                var canvas = slot.GetChild(0);
                var image = canvas.GetChild(0);
                var text = image.GetChild(0);

                var itemSprite = image.GetComponent<Image>();
                var itemAmount = text.GetComponent<Text>();

                var item = player.inventory.items[index];
            
                if (item == null || item.item == null) canvas.gameObject.SetActive(false);
                else
                {
                    canvas.gameObject.SetActive(true);
                    itemSprite.sprite = item.item.uiSprite;
                    itemAmount.text = $"{item.amount}";
                }
            }
        }*/
    }
}
