using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgentScript : MonoBehaviour
{
	public GameObject MaDestination;
	private NavMeshAgent navAgent;

	void Start()
    {
		navAgent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
		navAgent.SetDestination(MaDestination.transform.position); //la destination doit être un Vector3 
		//print(navAgent.velocity.magnitude);  //imprime la vitesse de déplacement de l’agent
		//navAgent.enabled = false;                    //désactive le fonctionnement de NavMeshAgent (le composant)
		/*
		if (Input.GetMouseButtonDown(0))
		{
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit infosCollision;

			if (Physics.Raycast(camRay.origin, camRay.direction,out infosCollision, 5000f))
			{
				navAgent.SetDestination(infosCollision.point);
			}
		}*/
	}
}
