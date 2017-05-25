using UnityEngine;
using System.Collections;

public class BossMissles : MonoBehaviour {

    public GameObject bullet;
    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shoot", 40, 2);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void Shoot()
    {
        GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, transform.position);  
    }
}
