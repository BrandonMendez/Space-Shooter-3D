using UnityEngine;
using System.Collections;

public class EnemyFormation2 : MonoBehaviour {

    public float width;
    public float height;
    public float movementSpeed;

    int waveDeadScore = 2000;
    bool shouldSpawn = false;

    Score score;

    public Transform target;
    public GameObject powerUp;

    // Use this for initialization
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfAllDead();
    }

    void Move()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
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
