using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Debug.Log(gameObject.transform);
        currentPoint = pointA.transform;
        //anim.SetBool("isRunning", true);
    }
    // Update is called once per frame
    void Update()
    {
        enemy.transform.position = gameObject.transform.position;
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint  == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == pointB.transform)
        {
            //Debug.Log("Point touched 1");
            transform.localScale = new Vector2(1,1);
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
           // Debug.Log("Point touched 2");
            transform.localScale = new Vector2(-1, 1);
            currentPoint= pointB.transform;
        }
    }
    //this function shows us circural indicator to see the position of the points
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 1f);
        Gizmos.DrawLine(pointA.transform.position,pointA.transform.position);
    }
}
