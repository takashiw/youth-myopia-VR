using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

	public string text = "Spelling";
	public bool isActive = false;

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = this.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
