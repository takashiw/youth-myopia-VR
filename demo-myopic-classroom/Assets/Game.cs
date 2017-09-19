using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject wordObject;
	string[] spellingWords = new string[]{ "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
	float paddingLeft = 0.4f;
	float paddingBottom = 0.2f;
	float startX = -0.7f;
	float startY = 0.4f;
	int columnAmount = 4;

	// Use this for initialization
	void Start () {
		int column = 0;
		for (int i = 0; i < this.spellingWords.Length; i++) {
			if(i%this.columnAmount == 0){
				column++;
			}
			GameObject newWord = (GameObject)Instantiate (wordObject);
			newWord.transform.position = new Vector3 (startX + i%columnAmount * paddingLeft, startY + column * -paddingBottom, 0);
			newWord.GetComponent<Word> ().text = this.spellingWords [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
