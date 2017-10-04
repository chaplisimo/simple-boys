using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceGenerator : MonoBehaviour {

	[SerializeField]
	public DiceSheet[] diceScripts;
	
	public GameObject dicePrefab;
	public Transform spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			GameObject aDice = Instantiate(dicePrefab,spawn);
			int random = Random.Range(0,diceScripts.Length-1);
			DiceSheet aScript = diceScripts[random];
			aDice.GetComponent<DiceScript>().diceSheet = aScript;
		}
	}
}
