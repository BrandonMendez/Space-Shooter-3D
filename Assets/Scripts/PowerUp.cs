using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
