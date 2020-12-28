using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 
/// @author : Martin Christian Solihin
/// 
/// </summary>

public class LevelGenerator : MonoBehaviour
{
  public GameObject player, enemy, wallType1, wallType2, wallType3, wallType4, wallType5, wallType6, wallType7, wallType8, wallType9, wallType10;
  private List<GameObject> listType; 
  private GameObject wallSocket, enemySocket;
  public NavMeshSurface surface;
  public GameManager gameManager;
  public int NumberOfEnemy, NumberOfCake;
  private bool isPlayerSpawned;
  private float width = 100, height = 100, dividedBy;

  private void Awake() {
    wallSocket = GameObject.Find("Walls");
    enemySocket = GameObject.Find("Enemies");
    
    // input all availabe wall types for then later be called in LevelGenerator method
    listType = new List<GameObject>();
    listType.Add(wallType1);
    listType.Add(wallType2);
    listType.Add(wallType3);
    listType.Add(wallType4);
    listType.Add(wallType5);
    listType.Add(wallType6);
    listType.Add(wallType7);
    listType.Add(wallType8);
    listType.Add(wallType9);
    listType.Add(wallType10);
  }

    /// <summary>
    /// 
    /// After choose the difficulty, the GameManager will call one out of three Methods below, then generate the level, player and enemy
    /// 
    /// </summary>

  public void difficultyOne() {
    dividedBy = 2;
    NumberOfEnemy = 1;

    GenerateLevel();
    surface.BuildNavMesh();
  }

    public void difficultyTwo() {
    dividedBy = 1.33f;
    NumberOfEnemy = 3;

    GenerateLevel();
    surface.BuildNavMesh();
  }

    public void difficultyThree() {
    dividedBy = 1;
    NumberOfEnemy = 5;

    GenerateLevel();
    surface.BuildNavMesh();
  }

  public void GenerateLevel() {
    float maxHeight = height / dividedBy;
    float maxWidth = width / dividedBy;
    
    /// <summary>
    /// 
    /// level generator
    /// 
    /// </summary>
    
    // loop through the board area and initiate wall by a random number
    for (float x = 12.5f; x <= maxWidth; x += 25) {
      for (float y = 12.5f; y <= maxHeight; y += 25) {
        // generate a random number between 0 and 1
        float randomFloat = Random.value;
        int randomInt = (int) (randomFloat * 10);

        // to count the number of cake in each unique generated maze
        if (randomInt == 0 || randomInt == 1 || randomInt == 6 || randomInt == 8) {
          NumberOfCake += 16;
        } else if (randomInt == 2 || randomInt == 5 || randomInt == 7 || randomInt == 9) {
          NumberOfCake += 15;
        } else if (randomInt == 3) {
          NumberOfCake += 19;
        } else if (randomInt == 4) {
          NumberOfCake += 17;
        }

        Vector3 pos = new Vector3(x - width / 2f, 0, y - height / 2f);
        Instantiate(listType[randomInt], pos, Quaternion.identity, wallSocket.transform);
      }
    }

    /// <summary>
    /// 
    /// Player and enemy generator
    /// 
    /// </summary>

    // loop to generate player and enemy on random position
    for (float x = 17.5f; x <= maxWidth; x += 25) {
      for (float y = 2.5f; y <= maxHeight; y += 25) {
        Vector3 pos = new Vector3(x - width / 2f, 0, y - height / 2f);
        float randomFloat = Random.value;

        if (y == 2.5f && !isPlayerSpawned) { // GENERATE PLAYER
          if (randomFloat >= 0.7f) {
            Instantiate(player, pos, Quaternion.identity, transform.parent);
            isPlayerSpawned = true;
          }

          // if on the last respawn area the player still not spawn, force spawn on last spawn area
          if (!isPlayerSpawned) {
            if (dividedBy == 2 && x == 42.5f && y == 2.5f) {
              Instantiate(player, pos, Quaternion.identity, transform.parent);
            } else if (dividedBy == 1.33f && x == 67.5f && y == 2.5f) {
              Instantiate(player, pos, Quaternion.identity, transform.parent);
            } else if (dividedBy == 1 && x == 92.5f && y == 2.5f) {
              Instantiate(player, pos, Quaternion.identity, transform.parent);
            }
          }
          
        } else if (y >= 27.5f) { // GENERATE ENEMY
          if (NumberOfEnemy != 0) { 
            if (randomFloat >= 0.7f) {
              Instantiate(enemy, pos, Quaternion.Euler(0, 180, 0), enemySocket.transform);
              NumberOfEnemy--;
            }

            // if on the last respawn area the number of enemy, that should be spawn not enough, force spawn on last spawn area
            if (dividedBy == 2 && x == 42.5f && y == 27.5f) {
              for (int i = 0; i < NumberOfEnemy; i++) {
                Instantiate(enemy, pos, Quaternion.Euler(0, 180, 0), enemySocket.transform);
              }
            } else if (dividedBy == 1.33f && x == 67.5f && y == 52.5f) {
              for (int i = 0; i < NumberOfEnemy; i++) {
                Instantiate(enemy, pos, Quaternion.Euler(0, 180, 0), enemySocket.transform);
              }
            } else if (dividedBy == 1 && x == 92.5f && y == 77.5f) {
              for (int i = 0; i < NumberOfEnemy; i++) {
                Instantiate(enemy, pos, Quaternion.Euler(0, 180, 0), enemySocket.transform);
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// 
    /// Initialize value in Game Manager
    /// 
    /// </summary>
    
    gameManager.SetPlayer();
    gameManager.SetNumberCake(NumberOfCake);
  }
}
