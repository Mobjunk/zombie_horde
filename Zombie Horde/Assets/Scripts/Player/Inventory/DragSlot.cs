using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject parent;
    [SerializeField] private bool allowDrag = true;
    
    private void Start()
    {
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
            GameManager.playerObject.GetComponent<Player>().inventory.Swap(fromSlot, toSlot);
        }
    }
}
