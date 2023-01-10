using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptPerso : MonoBehaviour
{
    private Vector3 destination;
    private Animator persoAnim;
    private NavMeshAgent navAgent;

    void Start()
    {
        destination = transform.position;
        persoAnim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit infosCollision;
            Physics.Raycast(camRay.origin, camRay.direction, out infosCollision, 5000);
            if (infosCollision.collider != null) navAgent.SetDestination(infosCollision.point);

        }
    }
}
