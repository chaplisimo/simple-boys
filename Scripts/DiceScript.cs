using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceScript : MonoBehaviour {

	public bool isPlayed = false;
	public int number;
		
	Rigidbody rb;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void PlayDice(){
		number = Random.Range(1,6);
		isPlayed = true;
		Debug.Log("Dice thrown: "+ number);
	}
	
	public void ResetDice(){
		number = 0;
		isPlayed = false;
		Debug.Log("Dice resetted");
	}
}
