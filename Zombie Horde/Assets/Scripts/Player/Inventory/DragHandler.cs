using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //Information for dragging
    public static GameObject itemBeingDragged;

    public GameObject parent;
    public GameObject slot;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Transform startParent;
    [SerializeField] private bool enableDrag = true;

    public void Start()
    {
        parent = transform.parent.transform.parent.transform.parent.gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!enableDrag) return;
        
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.parent.GetComponent<Canvas>().overrideSorting = true;
        transform.parent.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!enableDrag) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!enableDrag) return;
        ResetDrag();
    }

    public void ResetDrag()
    {
        if (!enableDrag) return;
     
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.parent.GetComponent<Canvas>().overrideSorting = false;
        
        transform.parent.GetComponent<Canvas>().sortingOrder = 1;
        
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
    
}
