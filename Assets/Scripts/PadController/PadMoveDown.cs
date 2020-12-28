using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// @author : Martin Christian Solihin
/// 
/// </summary>

public class PadMoveDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    [SerializeField] private GameObject player;
    private Rigidbody rb;

    public void InitializePlayer() {
        player = GameObject.Find("Player(Clone)");
        rb = player.GetComponent<Rigidbody>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("DOWN SELECTED");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("DOWN DISSELECTED");
    }
}
