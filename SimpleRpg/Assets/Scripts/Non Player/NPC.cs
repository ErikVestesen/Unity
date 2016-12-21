using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public string[] dialogue;
	//[HideInInspector]
	public new string name; 

    public override void Interact()
    {
        DialogueSystem.Instance.addNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC");
    }
}
