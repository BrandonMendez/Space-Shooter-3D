using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    bool rightCoreStatus;
    bool leftCoreStatus;

    public AudioClip barrierBlock;

    private LeftWing lefty;
    private RightWing righty;

	// Use this for initialization
	void Start () {
        lefty = GameObject.Find("LeftWing").GetComponent<LeftWing>();
        righty = GameObject.Find("RightWing").GetComponent<RightWing>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckPowerStatus();
	}

    void CheckPowerStatus()
    {
        leftCoreStatus = lefty.IsDead();
        rightCoreStatus = righty.IsDead();

        if(leftCoreStatus == true && rightCoreStatus == true)
        {
            Destroy(gameObject);
        }
      
    }

    void OnTriggerEnter (Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<PlayerBullet>())
        {
            AudioSource.PlayClipAtPoint(barrierBlock, obj.transform.position);
            Destroy(collider.gameObject);
        }
    }
}
