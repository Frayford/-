using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float speed = 50f;
    private float timer = 5;
    private float timereset;
    private float looaAtdistance=12;
    private Rigidbody2D rb;
 
     //Use this for initialization
	void Start () {
        initGame();
	}
    public void initGame()
    {
        timereset = timer;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
	void Update () 
    {
       
        timer -= Time.deltaTime;
        if(timer<=0)
        { 
            timer=Random.Range(1,20);
            timer=timereset;
            transform.localScale = new Vector3(-transform.localScale.y, 0.6402f, 0.6402f);
            speed = -speed;
        }
        rb.AddForce(new Vector2(speed, 0));
	}
    public void OnCollisionEnter2D(Collision2D collsion)
    {
        if (collsion.gameObject.tag == "Plane")
        {
            transform.localScale = new Vector3(-transform.localScale.y, 0.6402f, 0.6402f);
        }

    }
}
