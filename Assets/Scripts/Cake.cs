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
            if (gameObject.tag == "BigCake") {
                player.AddScore(5);
                player.MinusCake();
                Destroy(gameObject);
            } else {
                player.AddScore(1);
                player.MinusCake();
                Destroy(gameObject);
            }
        }
    }
}
