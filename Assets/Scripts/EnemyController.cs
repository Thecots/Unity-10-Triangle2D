using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public ParticleSystem particle;
    public GameManager gameManager;
    public int livePoints;
    public Sprite[] sprites;
    public Color[] ColorParticles;
    public GameObject bullet;


    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    void Start()
    {
        livePoints = Random.Range(1, 4);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[livePoints - 1];
    }

    void Update()
    {
        int numb = Random.Range(0, 10000);
        if (numb > 9996)
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            var main = particle.main;
            main.startColor = ColorParticles[livePoints - 1];
            Instantiate(particle, transform.position, Quaternion.Euler(0, 0, 0));
            livePoints--;
            Destroy(col.gameObject);
            if(livePoints == 0)
            {
                gameManager.AddScore();
                Destroy(gameObject, 0f);
                return;
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[livePoints - 1];
        }

    }

}
