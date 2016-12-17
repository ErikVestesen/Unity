using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted; 
    // move to object and interact with object.
    public virtual void MoveToInteraction(NavMeshAgent playerAgent) {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2f;
        playerAgent.destination = this.transform.position;
    }

    void Update()
    {
        if(playerAgent != null && !playerAgent.pathPending) {
            if(playerAgent.remainingDistance <= playerAgent.stoppingDistance && !hasInteracted)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }

}
