using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
	// Use this for initialization
    public void initGame()
    {
	   //得到transform主键
        player = GameObject.Find("Player").transform;
    }
	void Start () {
        initGame();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = player.position.x;
        pos.y = player.position.y;
        transform.position = pos;
	}
}
