﻿/* Singleton object - to reference from other objects */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	public static DialogueSystem Instance { get; set; }
	public GameObject dialoguePanel;
	public string npcName;

	public List<string>dialogueLines = new List<string>();

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	// Use this for initialization
	void Awake () {
		// Manage dialogue panel components via script
		continueButton 	= dialoguePanel.transform.FindChild ("Continue").GetComponent<Button> ();
		dialogueText 	= dialoguePanel.transform.FindChild ("Text").GetComponent<Text> ();
		nameText 		= dialoguePanel.transform.FindChild ("Name").GetChild(0).GetComponent<Text>();

		continueButton.onClick.AddListener (delegate {
			ContinueDialogue();
		});

		dialoguePanel.SetActive (false);

		if (Instance !=null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	
	public void AddNewDialogue(string[] lines, string npcName)
	{
		dialogueLines = new List<string>(lines.Length);
		dialogueLines.AddRange(lines);

		this.npcName = npcName;

		Debug.Log(dialogueLines.Count);
		Debug.Log (npcName);
		CreateDialogue ();
	}

	public void CreateDialogue()
	{
		dialogueText.text 	= dialogueLines [dialogueIndex];
		nameText.text 		= npcName;
		dialoguePanel.SetActive (true);
	}
	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count - 1) {
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];

		} else {
			// time to close the panel
			dialoguePanel.SetActive(false);
		}
	}

}
