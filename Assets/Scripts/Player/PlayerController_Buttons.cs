using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script is applied to all buttons that is responsible for character movement via buttons in close play mode
/// 
/// @author : Martin Christian Solihin
/// 
/// </summary>

public class PlayerController_Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject player;
    private bool isUpClicked, isLeftClicked, isRightClicked, isDownClicked;
    private float addRotation = 60, speed = 7f;

    public void Start() {
        player = GameObject.Find("Player(Clone)");
    }

    // For moving forward and backward, fixed update will be used due to physic engine (collide with walls)
    private void FixedUpdate() {
        if (isUpClicked) {
            player.transform.Translate(0, 0, speed * Time.deltaTime);
        } else if (isDownClicked) {
            player.transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

    private void Update() {
        if (isRightClicked) {
            player.transform.Rotate(0, (player.transform.rotation.y + addRotation) * Time.deltaTime, 0);
        } else if (isLeftClicked) {
            player.transform.Rotate(0, (player.transform.rotation.y - addRotation) * Time.deltaTime, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(gameObject.name == "Up") {
            isUpClicked = true;
        } else if(gameObject.name == "Down") {
            isDownClicked = true;
        } else if(gameObject.name == "Right") {
            isRightClicked = true;
        } else if(gameObject.name == "Left") {
            isLeftClicked = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        isUpClicked = false;
        isDownClicked = false; 
        isRightClicked = false;
        isLeftClicked = false;
    }
}
