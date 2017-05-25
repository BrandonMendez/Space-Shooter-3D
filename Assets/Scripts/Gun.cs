using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    //public float bulletSpeed;
    int shootingMethod = 1;

    public GameObject bullet;
    public AudioClip bulletSound;

    private float instantiationTimer = 0.09f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot(shootingMethod);
        }
    }

    public int GetShootingMethod()
    {
        return shootingMethod;
    }

    public void SetShootingMethod(int method)
    {
        shootingMethod = method;
    }

    void Shoot(int method)
    {
        instantiationTimer -= Time.deltaTime;
        if (shootingMethod == 1)
        {
            if (instantiationTimer <= 0)
            {
                GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                instantiationTimer = 0.5f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
        if (shootingMethod == 2)
        {
            if (instantiationTimer <= 0)
            {
                float xRight = transform.position.x + 1f;
                float xleft = transform.position.x - 1f;
                Vector3 rightBullet = new Vector3(xRight, transform.position.y, transform.position.z);
                Vector3 leftBullet = new Vector3(xleft, transform.position.y, transform.position.z);
                GameObject laser1 = Instantiate(bullet, rightBullet, Quaternion.identity) as GameObject;
                GameObject laser2 = Instantiate(bullet, leftBullet, Quaternion.identity) as GameObject;
                instantiationTimer = 0.5f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
    }
}
