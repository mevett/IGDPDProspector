﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;      // This will be used later in the project 
using UnityEngine.UI;                   // This will be used later in the project   

public class Prospector : MonoBehaviour {     
	static public Prospector    S;       

	[Header("Set in Inspector")]     
	public TextAsset            deckXML;        

	[Header("Set Dynamically")]     
	public Deck                    deck;       

	void Awake() {         
		S = this; // Set up a Singleton for Prospector     
	}       

	void Start () {         
		deck = GetComponent<Deck>(); // Get the Deck         
		deck.InitDeck(deckXML.text); // Pass DeckXML to it    
	} 
}