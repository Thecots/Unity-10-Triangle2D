using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform cañon;
    public GameObject bullet;
    public GameObject particle;
    public Shake shake;
    public GameManager gameManager;

    private Vector2 input;
    public float speed;

    public float timer, waitingTime;
    public int playerLives = 3;
    public GameObject livesObj;

    void Start()
    {
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey("space") && timer <= 0)
        {
            Instantiate(bullet, cañon.transform.position, Quaternion.Euler(0,0,0));
            Instantiate(particle, cañon.transform.position, Quaternion.Euler(0, 0, 0));

            timer = waitingTime;
        }

        timer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            shake.start = true;
            playerLives--;
            Destroy(livesObj.transform.GetChild(playerLives).gameObject);
            Destroy(col.gameObject);

            if (playerLives == 0)
            {
                gameManager.Lose();
                //Destroy(gameObject);
                return;
            }

        }


    }
}

