using UnityEngine;
using System.Collections;

public class SpawnBoss : MonoBehaviour {

    public float speed;

    bool moveUp;

    private bool summonBoss = false;

    private SpawnLocation spawner1;
    private SpawnLocation2 spawner2;
    private Health healthBar;

    // Use this for initialization
    void Start () {
        spawner1 = GameObject.Find("Spawner1").GetComponent<SpawnLocation>();
        spawner2 = GameObject.Find("Spawner2").GetComponent<SpawnLocation2>();
        healthBar = GameObject.Find("BossHealth").GetComponent<Health>();
        //healthBar.SetActiveFalse();
        StartCoroutine(SummonBoss());
    }

    // Update is called once per frame
    void Update () {
        if (summonBoss == true)
        {
            if (transform.position.y >= 160)
            {
                moveUp = false;
            }
            if (transform.position.y <= 150)
            {
                moveUp = true;
            }
            Move();
        }
	}

    private void Move()
    {
        if(transform.position.x >= 3.9f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (moveUp == true)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (moveUp == false)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
    

    IEnumerator SummonBoss()
    {
        yield return new WaitForSeconds(25);
        Destroy(spawner1.gameObject);
        Destroy(spawner2.gameObject);
        yield return new WaitForSeconds(10);
        summonBoss = true;
        healthBar.SetActiveTrue();
    }
}
