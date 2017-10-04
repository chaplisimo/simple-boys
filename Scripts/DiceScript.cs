using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceScript : MonoBehaviour {

	public bool isPlayed = false;
	public int number;
	public string owner;
	public GameObject canvas;
	public GameObject[] dicesCanvasPrefab;
	
	public DiceSheet diceSheet;
	
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
		UpdateCanvas();
	}
	
	public void ResetDice(){
		number = 0;
		isPlayed = false;
		owner = "";
		Debug.Log("Dice resetted");
	}
	
	void UpdateCanvas(){
		 switch(number){
			 case 1 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[0],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);
				 break;
			 }
			 case 2 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[1],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);
				 break;
			 }
			 case 3 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[0],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);
				 break;
			 }
			 case 4 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[3],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);  
				 break;                          
			 }                                   
			 case 5 : {                          
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[4],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);  
				 break;                          
			 }                                   
			 case 6 : {                          
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[5],canvas.transform);
				 diceCanvas.transform.SetParent(canvas.transform);
				 break;
			 }
		 }
	 }
}
