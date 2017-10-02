using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceScript : MonoBehaviour {

	public bool isPlayed = false;
	public int number;
	public string owner;
	public GameObject canvas;
	
	Vector3 canvasOffset;
	Quaternion canvasRotation;
	GameObject mainCamera;
		
	Rigidbody rb;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
		
		canvasRotation = canvas.transform.rotation;
		canvasOffset = canvas.transform.localPosition;
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Start(){
		canvas.transform.LookAt(mainCamera.transform);
	}
	
	// Update is called once per frame
	void Update () {
		canvas.transform.position = transform.position + canvasOffset;
		canvas.transform.rotation = canvasRotation;
	}
	
	public void PlayDice(string player){
		number = Random.Range(1,6);
		isPlayed = true;
		owner = player;
		Debug.Log("Dice thrown: "+ number + " by "+ player);
	}
	
	public void ResetDice(){
		number = 0;
		isPlayed = false;
		owner = "";
		Debug.Log("Dice resetted");
	}
}
