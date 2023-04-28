using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyPatrol : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }


        if(Vector2.Distance(transform.position, currentPoint.position)< 1f && currentPoint == PointB.transform)
        {
            flip();
            currentPoint = PointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
        }


        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 3.5)
        {
            SceneManager.LoadScene("GameOverScreen");
        }




    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }


}
