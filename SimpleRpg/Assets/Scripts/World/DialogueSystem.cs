using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject DialoguePanel;
    public string npcName;
    [HideInInspector]
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    // Use this for initialization
    void Awake () {
        continueButton = DialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = DialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = DialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { continueDialouge(); });

        DialoguePanel.SetActive(false);

        //Singleton
		if(Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
	}

    public void addNewDialogue(string [] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        createDialogue();
    }
    public void createDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        DialoguePanel.SetActive(true);
    }
    public void continueDialouge() {
        if(dialogueIndex < dialogueLines.Count-1) {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        } else {
            DialoguePanel.SetActive(false);
        }
    }
}
