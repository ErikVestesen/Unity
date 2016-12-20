using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class WorldInteractions : NetworkBehaviour {
    NavMeshAgent playerAgent;

	// Use this for initialization
	void Start () {
        playerAgent = GetComponent<NavMeshAgent>();
	}
	    
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        // GetMouseButtonDown(0) == venstre klik
        // !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject) Holder musen over f.eks. inventory ting
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            GetInteraction();
        }	
	}

    void GetInteraction() {
        //laver en Ray fra camera ud fra musens position
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay,out interactionInfo, Mathf.Infinity)) {
            GameObject interactedObject = interactionInfo.collider.gameObject; //Det objekt interactionRay rammer, hvis den rammer noget.
            if (interactedObject.tag == "Interactable Object") {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            } else {
                //pathfinding
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
