using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author : Martin Christian Solihin
/// </summary>

public class LevelGenerator : MonoBehaviour
{
  public GameObject enemy, wallType1, wallType2, wallType3, wallType4, wallType5, wallType6, wallType7, wallType8, wallType9, wallType10;
  private List<GameObject> listType; 
  private GameObject wallSocket, enemySocket;
  public NavMeshSurface surface;
  public GameManager gameManager;
  public int NumberOfEnemy = 3, NumberOfCake;
  private float width = 100, height = 100;

  private void Awake() {
  wallSocket = GameObject.Find("Walls");
  enemySocket = GameObject.Find("Enemies");
  
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

  GenerateLevel();

  surface.BuildNavMesh();
  }

  public void GenerateLevel() {
    // loop through the board area and initiate wall by a random number
    for (float x = 12.5f; x <= width; x += 25) {
      for (float y = 12.5f; y <= height; y += 25) {
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

    gameManager.SetNumberCake(NumberOfCake);

    // loop to generate enemy on random position
    for (float x = 17.5f; x <= width; x += 25) {
      for (float y = 27.5f; y <= height; y += 25) {
        if (NumberOfEnemy != 0) { 
          // generate a random number between 0 and 1
          float randomFloat = Random.value;
          
          if (randomFloat >= 0.7f) {
            NumberOfEnemy--;

            Vector3 pos = new Vector3(x - width / 2f, 0, y - height / 2f);
            Instantiate(enemy, pos, Quaternion.identity, enemySocket.transform);
          }
        }
      }
    }
  }
}