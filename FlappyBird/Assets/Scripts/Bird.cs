using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;

    public float GravityScale;
    public float ForceJumb;
    public Spwaner spwaner;

    private float Jumb;
    private Vector3 colliderPos;

    private float limitTop = 9.44f;
    private float limitBot = -6.66f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumb = ForceJumb;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jumb -= Time.fixedDeltaTime;

        if (Jumb <= 0)
        {
            Jumb = 0;
        }

        
        checkCollision();

        Move();
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.fixedDeltaTime * GravityScale + Jumb, transform.position.z);
    }

    public void checkCollision()
    {

        //Check pipe
        if (spwaner.pipes.Count != 0)
        {
            colliderPos = spwaner.pipes[0].transform.position;

            if ((colliderPos.x - 1.25f) <= transform.position.x && transform.position.x <= (colliderPos.x + 1.25f) && (transform.position.y >= (colliderPos.y + 1) || transform.position.y <= (colliderPos.y - 2.3f)))
            {
                Time.timeScale = 0f;
                GameManager.Instance.GameOver();
            }
        }

        //Check limit
        if (transform.position.y <= limitBot || transform.position.y >= limitTop)
        {
            Time.timeScale = 0f;
            GameManager.Instance.GameOver();
        }

        if (transform.position.x > (colliderPos.x + 1.25f))
        {
            spwaner.pipes.RemoveAt(0);
            GameManager.Instance.AddScore();
        }
    }
}
