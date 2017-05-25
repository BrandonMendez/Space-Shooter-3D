using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<Player>())
        {
            Destroy(collider.gameObject);
        }
    }
}
