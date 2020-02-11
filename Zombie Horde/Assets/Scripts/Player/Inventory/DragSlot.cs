using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject parent;
    [SerializeField] private bool allowDrag = true;
    private Player player;
    
    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        parent = transform.parent.gameObject;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.itemBeingDragged == null || !allowDrag) return;
        
        var image = DragHandler.itemBeingDragged.gameObject;
        var drag = image.GetComponent<DragHandler>();
        var slot = drag.slot;

        var fromSlot = int.Parse(slot.name.Replace("Slot ", "").Replace("(", "").Replace(")", ""));
        var toSlot = int.Parse(gameObject.name.Replace("Slot ", "").Replace("(", "").Replace(")", ""));

        var trans = DragHandler.itemBeingDragged.transform.parent;
        
        var canvas = trans.GetComponent<Canvas>();
        canvas.sortingOrder = 1;
        canvas.overrideSorting = false;

        if (fromSlot != toSlot)
        {
            Debug.Log($"[DEBUG] Move Items - fromSlot: {fromSlot}, toSlot: {toSlot}, start: {drag.parent.name}, release: {parent.name}");
            var itemOne = player.inventory.items[fromSlot];
            var itemTwo = player.inventory.items[toSlot];
            GameManager.playerObject.GetComponent<Player>().inventory.Swap(fromSlot, toSlot);

            if (itemOne == null || itemTwo == null) return;

            //Grabs the possible gun items
            var fromGun = player.GetGun(fromSlot);
            var toGun = player.GetGun(toSlot);
            
            //Grabs the possible tool items
            var toTool = player.GetTool(toSlot);
            var fromTool = player.GetTool(fromSlot);
            
            //Execute the tool swap (if fromTool/toTool isnt null)
            fromTool?.SetSlot(toSlot);
            toTool?.SetSlot(fromSlot);

            //Execute the gun swap (if fromGun/toGun isnt null)
            fromGun?.SetSlot(toSlot);
            toGun?.SetSlot(fromSlot);
        }
    }
}
