using UnityEngine;
using System.Collections.Generic;

public class ScoreZone : MonoBehaviour{
  
  public DiceCard card;
  public List<DiceScript> dices;
  
  void Start(){
    Reset();
  }
  
  void Reset(){
   card = new DiceCard(Random.Range(2,6)); 
   foreach(DiceScript dice in dices){
     dice.Die();
     //Destroy(dice.gameObject);
   }
   dices.Clear(): 
  }
  
  void OnTriggerEnter(Collider other){
    if(other.EqualsTag("Dice")){
      DiceScript diceScript = other.gameObject.GetComponent<DiceScript>();
      if(IsMissingDice(diceScript)){
        dices.Add(diceScript);
        if(RemainingNumbers().Count == 0){
          gameController.ScorePlayer(diceScript.owner, card.score);
          Reset();
          
        };
      }
    }
  }
  
  bool IsMissingDice(diceScript){
    List<int> numbersLeft = RemainingNumbers();
    //Ahora reviso si el dado sirve o no
    return numbersLeft.Contains(diceScript.number);
  }
                       
  List<int> RemainingNumbers(){
    List<int> numbersLeft = new List<int>(card.numbers);
    foreach(Dice dice in dices){
      //Primero elimino de la lista los que ya estan conseguidos
      if(dice.owner == diceScript.owner && numbersLeft.Contains(dice.number)){
        numbersLeft.Remove(dice.number);
      }
    }
    return numbersLeft;
  }
}

public class DiceCard {
  public int[] numbers;
  public int score;
  
  public DiceCard(int qty){
    number = new int[qty];
    for(int i=0; i<qty; i++){
      number[i] = Random.Range(1,6);
    }
    score = 5 * qty;
  }
}
