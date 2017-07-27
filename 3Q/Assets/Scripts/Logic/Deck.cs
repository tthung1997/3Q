using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

	public List<ScriptableObject> cards = new List<ScriptableObject>();

    void Awake()
    {
        cards.Shuffle();
    }
	
}
