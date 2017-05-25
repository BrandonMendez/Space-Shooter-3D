using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    private Text health;
    private int healthBar = 15;

	// Use this for initialization
	void Start () {
        health = GetComponent<Text>();
        health.text = healthBar.ToString();
       // gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SubtractHealth(int life)
    {
        healthBar -= life;
        health.text = healthBar.ToString();
    }

    public int GetHealth()
    {
        return healthBar;
    }

    public void SetActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
