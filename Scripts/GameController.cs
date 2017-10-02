using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  
  public ScoreZone[] zones;
  public List<Player> players;
  public int scoreToWin = 100;
  
  public void Start(){
    //initialize players
  }
  
  public void ScorePlayer(string name, int score){
    Player player = players.Find(x => x.name == name);
    player.score += score;
    UpdateScore();
  }
  
  void UpdateScore(){
    string score = "Score Table\n";
    string winner = "";
    foreach(Player player in players){
      score += player.name + "\t" + player.score + "\n";
      winner = player.score >= scoreToWin ? player.name : winner;
    }
    if(!winner.Equals(""))
      score += "Winner " + winner + "!!";
    Debug.Log(score);
  }
  
  [System.Serializable]
  public class Player {
	[SerializeField]
    public string name;
    [SerializeField]
    public int score;
  
    public Player(string name){
      this.name = name;
      this.score = 0;
    }
  }
}
