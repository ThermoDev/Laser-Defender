using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public int score = 0;
	private Text texty;
	
	void Start(){
		texty = (Text)GetComponent<Text>();
	}
	
	public void Score(int points) {
		this.score += points;
		texty.text = "Score: " + score;
	}
	
	public void Reset() {
		score = 0;
		texty.text = "Score: " + score;
	}
}
