using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour {

    private float alpha = 1;
    private float va = 0.02f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Color current = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color(current.r, current.g, current.b, alpha);
        alpha -= va;
        alpha = (alpha < 0) ? 0: alpha;
    }
}
