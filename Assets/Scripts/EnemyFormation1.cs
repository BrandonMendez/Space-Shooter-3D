using UnityEngine;
using System.Collections;

public class EnemyFormation1 : MonoBehaviour {

    public float width;
    public float height;
    public float movementSpeed;

    bool shouldSpawn = false;
    int waveDeadScore = 1000;

    Score score;

    public GameObject powerUp;

    private int moveCount = 0;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckIfAllDead();
    }

    void Move()
    {
        if (moveCount == 0) //moving from start to right
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            if(transform.position.x <= -247)
            {
                transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
                if (transform.position.z >= 7760)
                {
                    moveCount = 1;
                }
            }
        }
        if(moveCount == 1) //moving from right to left
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            if(transform.position.x >= 210)
            {
                transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
                if (transform.position.z >= 7795)
                {
                    moveCount = 2;
                }
            }
        }
        if(moveCount == 2) //moving from left to right
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            if (transform.position.x <= -247)
            {
                transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
                if (transform.position.z >= 7795)
                {
                    moveCount = 3;
                }
            }
        }
        if(moveCount == 3) //moving from right to left and stopping at the center
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
             if(transform.position.x >= 0.0f)
             {
                 moveCount = 4; //put it out of scope
             }
        }
    }

    void CheckIfAllDead()
    {
        foreach(Transform childPosition in transform)
        {
            if(childPosition.childCount > 0)
            {
                shouldSpawn = true;
                return;
            }
        }
        if(shouldSpawn == true)
        {
            SpawnPowerUp();
            score.AddScore(waveDeadScore);
            shouldSpawn = false;
            Destroy(gameObject);
        }
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(0, 150, transform.position.z);
        GameObject power = Instantiate(powerUp, spawnPosition, Quaternion.identity) as GameObject;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
