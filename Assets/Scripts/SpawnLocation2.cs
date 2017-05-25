using UnityEngine;
using System.Collections;

public class SpawnLocation2 : MonoBehaviour {

    public GameObject enemyFormation2;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemyFormation", 12f, 23f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemyFormation()
    {
        GameObject enemyFormation = Instantiate(enemyFormation2, transform.position, Quaternion.identity) as GameObject;
    }
}
