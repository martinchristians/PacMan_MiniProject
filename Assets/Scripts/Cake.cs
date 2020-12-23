using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author : Martin Christian Solihin
/// </summary>

public class Cake : MonoBehaviour
{
    private PlayerManagement player;
    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerManagement>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player.AddScore();
            player.MinusCake();
            Destroy(gameObject);
        }
    }
}
