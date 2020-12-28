using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// @author : Martin Christian Solihin
/// 
/// </summary>

public class PadRotateRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    [SerializeField] private GameObject player;
    private Rigidbody rb;

    public void InitializePlayer() {
        player = GameObject.Find("Player(Clone)");
        rb = player.GetComponent<Rigidbody>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("RIGHT SELECTED");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("RIGHT DISSELECTED");
    }
}
