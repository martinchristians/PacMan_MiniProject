using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// @author : Martin Christian Solihin
/// 
/// </summary>

public class PadMoveUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float movespeed = 20, rotationSpeed = 20;
    [SerializeField] private GameObject player;
    private Rigidbody rb;
    private Vector3 velocity;

    public void InitializePlayer() {
        player = GameObject.Find("Player(Clone)");
        rb = player.GetComponent<Rigidbody>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("UP SELECTED");
        //rb.velocity = new Vector3(velocity.normalized.x * movespeed * Time.deltaTime, rb.velocity.y, velocity.normalized.z * movespeed * Time.deltaTime);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UP DISSELECTED");
        //rb.velocity = Vector3.zero;
    }
}
