using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed;
    int shootingMethod;

    public GameObject loseMenu;
    public GameObject explossionParticleSystem;
    public AudioClip explossionSound;
    public AudioClip powerUp;
    Gun playerGun;

	// Use this for initialization
	void Start () {
        playerGun = GameObject.Find("Player").GetComponentInChildren<Gun>();
        shootingMethod = playerGun.GetShootingMethod();
    }
	
	// Update is called once per frame
	void Update () {
        MoveShip();
        ClampToCamera();
    }

    void MoveShip()
    {
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
    }

    void ClampToCamera()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(transform.position.y, 19f, 158f);
        clampedPosition.x = Mathf.Clamp(transform.position.x, -22f, 28f);
        transform.position = clampedPosition;
    }

    void Die()
    {
        loseMenu.SetActive(true);
        GameObject explode = Instantiate(explossionParticleSystem, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(explossionSound, transform.position);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<EnemyBullet>())
        {
            Destroy(collider.gameObject);
            shootingMethod = playerGun.GetShootingMethod();
            if(shootingMethod == 1)
            {
                Die();
            }
            else
            {
                AudioSource.PlayClipAtPoint(explossionSound, transform.position);
                playerGun.SetShootingMethod(1);
            } 
        }

        if (obj.GetComponent<PowerUp>())
        {
            AudioSource.PlayClipAtPoint(powerUp, transform.position);
            playerGun.SetShootingMethod(2);
            Destroy(collider.gameObject);
        }

        if (obj.GetComponent<MovingGround>())
        {
            Die();
        }
    }
}
