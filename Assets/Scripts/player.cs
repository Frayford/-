using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class player : MonoBehaviour {

    private float x_force = 600;
    private float y_force=500;
    private float timer = 2f;
    private float timereset;
    private int s = 0;
    private Vector3 birth=new Vector3(0,0.5f,0);
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 velocity;
    private GameObject camera;
    private GameObject die;
    private GameObject win;
    private bool isjump = false;
    private bool isdie = false;
    private bool iswin = false;

    private Transform offcx;
    private Transform offpx;
	// Use this for initialization
    //初始化Player
    public void initgame()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        velocity = rb.velocity;
        camera = GameObject.Find("Camera");
        die = GameObject.Find("Die");
        win = GameObject.Find("Win");
        die.SetActive(false);
        win.SetActive(false);
        timereset = timer;
    }
	void Start () {
        initgame();
	}
	// Update is called once per frame
	void Update () {

        //失去控制
        if (!isdie&&!iswin)
        {
            //控制旋转
            if (s % 2 == 0)
            {
                move_0();
            }
            else
            {
                move_1();
            }
            if (Input.GetMouseButtonDown(0) && isjump)
            {
                s++;
                rotation(s);
            }
        }
        else
        {
            //关闭text，返回出生位置
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                timer = timereset;
                if (isdie)
                {
                    die.SetActive(false);
                    isdie = false;
                }
                else
                {
                    win.SetActive(false);
                    iswin = false;
                }
                transform.position = birth;
                
            }
        }
	}
    public void OnCollisionEnter2D(Collision2D collsion)
    {
        //print(collsion.gameObject.tag);
        if (collsion.gameObject.tag == "Plane")
        {
            //float offcx = Mathf.Abs(collsion.gameObject.transform.localPosition.x - collsion.transform.localScale.x / 2);
            //float offpx = Mathf.Abs(transform.localPosition.x + transform.localScale.x / 2);
            //float distance = Mathf.Abs(transform.localPosition.x - collsion.transform.localPosition.x);
            //print("1");
            //print(offcx);
            //print("2");
            //print(offpx);
            //print("3");
            //print(offcx - offpx);
            //print("4");
            //print(distance);
            //if (offcx - offpx <= distance)
            //{
            //    isjump = false;
            //}
            //else
            //{
            //    isjump = true;
            //}

            isjump = true;
        }
        //anim.SetBool("IsPlane", isjump);
        if(collsion.gameObject.tag=="Enemy")
        {
            die.SetActive(true);
            isdie = true;
        }
        if(collsion.gameObject.tag=="Win")
        {
            win.SetActive(true);
            iswin = true;
        }
    }
    public void OnCollisionStay2D(Collision2D collsion)
    {
       // print(collsion.gameObject.tag);
        if (collsion.gameObject.tag == "Plane")
        {
            isjump = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            isjump = false;
        }
        //anim.SetBool("IsPlane", isjump);
       
    }

    public void rotation(int s)
    {
        //上面
        if (s % 2 ==0)
        {
           camera.transform.Rotate(new Vector3(0, 0, 180));
            transform.Rotate(new Vector3(0, 0, 180));
            transform.position += new Vector3(0, 7.6f, 0);
            rb.gravityScale = 100;
        }
        else//下面
        {
            
            camera.transform.Rotate(new Vector3(0, 0, 180));
            transform.Rotate(new Vector3(0, 0, 180));
            transform.position -= new Vector3(0, 7.6f, 0);
            rb.gravityScale = -100;
        }
    }
    //public void rotation1()
    //{

    //    camera.transform.Rotate(new Vector3(0, 0, 180));
    //    transform.Rotate(new Vector3(0, 0, 180));
    //    transform.position += new Vector3(0, 7.6f, 0);
    //    rb.gravityScale = 10;
    //    is_1 = false;
    //    is_0 = true;
    //}
    public  void move_0()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0.05f)
        {
            rb.AddForce(Vector2.right * x_force);
        }
        else if (h < -0.05f)
        {
            rb.AddForce(-Vector2.right * x_force);
        }
 
        anim.SetFloat("Horizontal", Mathf.Abs(h));
        //jump
        print(isjump);
        if (isjump && Input.GetKeyDown("space"))
        {
           // print("1");
            velocity.y = y_force;
            rb.velocity = velocity;
        }
        
    }
    public void move_1()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0.05f)
        {
            rb.AddForce(-Vector2.right * x_force);
        }
        else if (h < -0.05f)
        {
            rb.AddForce(Vector2.right * x_force);
        }
        
        anim.SetFloat("Horizontal", Mathf.Abs(h));
        //jump
        //print(isjump);
        if (isjump && Input.GetKeyDown("space"))
        {
            print("1");
            velocity.y = -y_force;
            rb.velocity = velocity;
        }
        
    }

}
