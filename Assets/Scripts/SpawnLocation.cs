using UnityEngine;
using System.Collections;

public class SpawnLocation : MonoBehaviour {

    public GameObject enemyFormation;

    private float height1 = 145;
    private float height2 = 150;
    private int heightCounter = 1;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemyFormation", 1f, 17f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemyFormation()
    {
        GameObject formation;
        if(heightCounter == 1)
        {
            Vector3 startPosition = new Vector3(transform.position.x, height1, transform.position.z);
            formation = Instantiate(enemyFormation, startPosition, Quaternion.identity) as GameObject;
            heightCounter = 2;
        }
        else if(heightCounter == 2)
        {
            Vector3 startPosition = new Vector3(transform.position.x, height2, transform.position.z);
            formation = Instantiate(enemyFormation, startPosition, Quaternion.identity) as GameObject;
            heightCounter = 1;
        }
    }
}
