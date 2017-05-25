using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
    
    public GameObject bullet;
    public AudioClip shootSound;

    private float rateOfFire;
    private float bulletPerSecond = 0.3f;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        rateOfFire = Time.deltaTime * bulletPerSecond;
        if (Random.value < rateOfFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }
}
