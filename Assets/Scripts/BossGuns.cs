using UnityEngine;
using System.Collections;

public class BossGuns : MonoBehaviour {

    public GameObject bullet;
    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shoot", 40, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Shoot()
    {
        GameObject bullets = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }
}
