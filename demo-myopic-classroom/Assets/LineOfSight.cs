using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

	private RaycastHit vision;
	public float rayLength;
	public bool isGrabbed;
	private Rigidbody grabbedObject;
	private GameObject collidedObject;
	private Word currentSight = null;

	// Use this for initialization
	void Start () {
		rayLength = 4.0f;
		isGrabbed  = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength)) {
			if(vision.collider.tag == "Interactive"){
//				collidedObject = vision.collider.GetComponent<Word>();
				currentSight = vision.collider.GetComponent<Word>();
//				Debug.Log(vision.collider.GetComponent<Word>().text);
			}
		} else {
			currentSight = null;
		}
//		Debug.Log(currentSight);
	}

	public Word getCurrentSight(){
		return currentSight;
	}
}
