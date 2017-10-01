using UnityEngine;

public class GameController : MonoBehaviour {
  
  public ScoreZone[] zones;
  public List<Player> players;
  
  public Start(){
    //initialize players
  }
  
  public void ScorePlayer(string name, int score){
    Player player = players.Find(x => x.name == name);
    player.score += score;
    UpdateScore():
  }
  
  void UpdateScore(){
    string score = "Score Table\n";
    foreach(Player player in players){
      score += player.name + "\t" + player.score;
    }
    Debug.Log(score);
  }
  
  public class Player {
    public string player;
    public int score;
  
    public Player(string name){
      this.player = name;
      this.score = 0;
    }
  }
}
