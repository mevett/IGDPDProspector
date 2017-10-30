﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;      // This will be used later in the project 
using UnityEngine.UI;                   // This will be used later in the project   

public class Prospector : MonoBehaviour {     
	static public Prospector    S;       

	[Header("Set in Inspector")]     
	public TextAsset            deckXML;  
	public TextAsset            layoutXML; 

	[Header("Set Dynamically")]     
	public Deck                 deck; 
	public Layout				layout;
	public List<CardProspector> drawPile;

	void Awake() {         
		S = this; // Set up a Singleton for Prospector     
	}       

	void Start () {         
		deck = GetComponent<Deck>(); // Get the Deck         
		deck.InitDeck(deckXML.text); // Pass DeckXML to it  
		Deck.Shuffle(ref deck.cards); // This shuffles the deck by reference // a 

//		Card c; 
//		for (int cNum=0; cNum < deck.cards.Count; cNum++) {                    // b 
//			c = deck.cards[cNum]; 
//			c.transform.localPosition = new Vector3( (cNum%13)*3, cNum/13*4, 0 ); 
//		} 
		layout = GetComponent<Layout>();  // Get the Layout component
		layout.ReadLayout(layoutXML.text); // Pass LayoutXML to the new component for parsing

		drawPile = ConvertListCardsToListCardProspectors(deck.cards);
	} 

	List<CardProspector> ConvertListCardsToListCardProspectors(List<Card> lCD) { 
		List<CardProspector> lCP = new List<CardProspector>(); 
		CardProspector tCP; 
		foreach( Card tCD in lCD ) { 
			tCP = tCD as CardProspector;                   // a 
			lCP.Add( tCP ); 
		} 
		return( lCP ); 
	} 

}