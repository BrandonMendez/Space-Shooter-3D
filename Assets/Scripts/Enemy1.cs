using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

    public float fallSpeed;
    public float rotateSpeed;

    int enemy1Score = 100;
    int enemy2Score = 200;

    public GameObject explossion;
    public AudioClip explodeSound;

    Score score;

    private bool dead = false;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckDead();
	}

    void CheckDead()
    {
        if (dead == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.World);
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    void Die()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(explodeSound, transform.position);
        Destroy(gameObject);
        if(gameObject.tag == "Enemy1")
        {
            score.AddScore(enemy1Score);
        }
        if(gameObject.tag == "Enemy2")
        {
            score.AddScore(enemy2Score);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<PlayerBullet>())
        {
            Destroy(collider.gameObject);
            dead = true;
        }
        if (obj.GetComponent<MovingGround>())
        {
            Die();
        }
    }
}
