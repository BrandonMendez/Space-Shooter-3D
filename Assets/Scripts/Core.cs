using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

    public int health;

    public GameObject winMenu;
    public GameObject explossion;
    public AudioClip explossionSound;

    private Health healthBar;
    

	// Use this for initialization
	void Start () {
        healthBar = GameObject.Find("BossHealth").GetComponent<Health>();
        healthBar.SetActiveFalse();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void Die()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(explossionSound, transform.position);
        winMenu.SetActive(true);
        Destroy(gameObject);
    }

    void OnTriggerEnter (Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<PlayerBullet>())
        {
            Destroy(collider.gameObject);
            health -= 1;
            healthBar.SubtractHealth(1);
            if(health <= 0)
            {
                Die();
            }
        }
    }
}
