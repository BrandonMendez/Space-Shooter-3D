using UnityEngine;
using System.Collections;

public class RightWing : MonoBehaviour {

    float fallSpeed = 15f;
    float rotateSpeed = 30f;
    int hitCounter = 0;
    bool isDead = false;

    public GameObject explossion;
    public AudioClip explodeSound;
    public AudioClip hit;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public bool IsDead()
    {
        return isDead;
    }

    public void SetDeadStauts(bool status)
    {
        isDead = status;
    }

    private void Die()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(explodeSound, transform.position);
        isDead = true;
        Destroy(gameObject);

    }

    void OnTriggerEnter (Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<PlayerBullet>())
        {
            Destroy(collider.gameObject);
            AudioSource.PlayClipAtPoint(hit, transform.position);

            hitCounter += 1;
            if(hitCounter >= 5)
            {
                Die();
                hitCounter = 0;
            }
        }
    }
}
