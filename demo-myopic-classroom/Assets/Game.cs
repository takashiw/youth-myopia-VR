using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject wordObject;
	string[] spellingWords = new string[]{ "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
	List<GameObject> spellingWordObjects = new List<GameObject> ();
	float paddingLeft = 0.6f;
	float paddingBottom = 0.4f;
	float startX = -0.9f;
	float startY = 0.8f;
	int columnAmount = 4;

	private IEnumerator coroutine;

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
			spellingWordObjects.Add (newWord);
		}

		StartCoroutine (startLesson ());
	}
	
	// Update is called once per frame
	void Update () {
		var cam = Camera.main.GetComponent<LineOfSight> ();
//		Debug.Log(cam.getCurrentSight().text);
//		Debug.Log(cam.getCurrentSight().isActive);

		if (cam.getCurrentSight () != null && cam.getCurrentSight ().isActive) {
			Debug.Log(cam.getCurrentSight().text);
		}
	}

	IEnumerator startLesson(){
		foreach (var wordObject in spellingWordObjects) {
			wordObject.GetComponent<Word> ().isActive = true;
			Debug.Log ("ACTIVE " + wordObject.GetComponent<Word> ().text);
			yield return new WaitForSeconds(5);
			wordObject.GetComponent<Word> ().isActive = false;
		}
	}

	IEnumerator Wait(float duration){
		yield return new WaitForSeconds(duration);
	}
}
