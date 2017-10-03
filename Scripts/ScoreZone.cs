using UnityEngine;
using System.Collections.Generic;

public class ScoreZone : MonoBehaviour{
  
  [SerializeField]
  public DiceCard card;
  public List<DiceScript> dices;
  
  public GameObject[] dicesUI;
  public GameObject[] dicesCanvasPrefab;
  
  GameController gameController;
  
  void Start(){
	gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    ResetZone();
  }
  
  void ResetZone(){
   card = new DiceCard(Random.Range(2,6)); 
   UpdateCanvas();
   foreach(DiceScript dice in dices){
     //dice.Die();
     Destroy(dice.gameObject);
   }
   dices.Clear();
  }
  
  void OnTriggerEnter(Collider other){
    if(other.CompareTag("Dice")){
      DiceScript diceScript = other.gameObject.GetComponent<DiceScript>();
      if(IsMissingDice(diceScript) && diceScript.isPlayed){
        dices.Add(diceScript);
        if(RemainingNumbers(diceScript).Count == 0){
          gameController.ScorePlayer(diceScript.owner, card.score);
          ResetZone();
          
        }
      }
    }
  }
  
  bool IsMissingDice(DiceScript diceScript){
    List<int> numbersLeft = RemainingNumbers(diceScript);
    //Ahora reviso si el dado sirve o no
    return numbersLeft.Contains(diceScript.number);
  }
                       
  List<int> RemainingNumbers(DiceScript diceScript){
    List<int> numbersLeft = new List<int>(card.numbers);
    foreach(DiceScript dice in dices){
      //Primero elimino de la lista los que ya estan conseguidos
      if(dice.owner == diceScript.owner && numbersLeft.Contains(dice.number)){
        numbersLeft.Remove(dice.number);
      }
    }
    return numbersLeft;
  }
  
  void UpdateCanvas(){
	  for(int i=0;i<card.numbers.Length;i++){
		  int number = card.numbers[i];
		 switch(number){
			 case 1 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[0],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
			 case 2 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[1],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
			 case 3 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[0],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
			 case 4 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[3],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
			 case 5 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[4],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
			 case 6 : {
				 GameObject diceCanvas = Instantiate(dicesCanvasPrefab[5],dicesUI[i].transform);
				 diceCanvas.transform.SetParent(dicesUI[i].transform);
				 break;
			 }
		 }
	  }
  }
	
	  [System.Serializable]
	  public class DiceCard{
		  [SerializeField]
		  public int[] numbers;
		  [SerializeField]
		  public int score;
		  
		  public DiceCard(int qty){
			numbers = new int[qty];
			for(int i=0; i<qty; i++){
			  numbers[i] = Random.Range(1,6);
			}
			score = 5 * qty;
		  }
		}
}
