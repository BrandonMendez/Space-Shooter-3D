using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public float bulletSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.back * Time.deltaTime * bulletSpeed;
	}
}
