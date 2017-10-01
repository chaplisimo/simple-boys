using UnityEngine;
using System.Collections.Generic;

public class ScoreZone : MonoBehaviour{
  
  public int score;
  public DiceCard card;
  public List<Dice> dices
  
  void OnTriggerEnter(Collider other){
    if(other.EqualsTag("Dice')){
      int diceNumber = other.gameObject.GetComponent<DiceScript>().number;
      if(card.Contains(diceNumber)){
        
      }
    }
  }
}

public class DiceCard {
  public int[] number;
  public int score;
  
  public DiceCard(int qty){
    number = new int[qty];
    for(int i=0; i<qty; i++){
      number[i] = Random.Range(1,6);
    }
    score = 5 * qty;
  }
}
