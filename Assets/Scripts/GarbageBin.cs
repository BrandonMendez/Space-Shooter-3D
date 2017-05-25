using UnityEngine;
using System.Collections;

public class GarbageBin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if(obj.GetComponent<PlayerBullet>() || obj.GetComponent<EnemyBullet>() || obj.GetComponent<PowerUp>())
        {
            Destroy(collider.gameObject);
        }
    }
}
