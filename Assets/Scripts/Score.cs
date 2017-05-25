using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    private int score = 0;
    private Text ScoreKeeper;

	// Use this for initialization
	void Start () {
        ScoreKeeper = GetComponent<Text>();
        ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ResetScore()
    {
        score = 0;
        ScoreKeeper.text = score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        ScoreKeeper.text = score.ToString();
    }
}
