using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author : Martin Christian Solihin
/// </summary>

public class PlayerController_Click : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject movementMark;
    private GameObject mark;

    private void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // check whether ray hit something
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Ground") {
                Destroy(mark);

                mark = Instantiate(movementMark, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Quaternion.LookRotation(hit.normal), transform.parent) as GameObject;
                agent.SetDestination(hit.point);
            }
        }

        if(agent.remainingDistance <= 0.01f) {
            Destroy(mark);
        }
    }
}
