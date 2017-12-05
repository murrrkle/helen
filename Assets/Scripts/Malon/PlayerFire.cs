using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {
    GameObject gc;
    public Player player;
	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -2.1f && transform.position.x > -2.8f && transform.position.y > 1.9f && transform.position.y < 2.9f)
        {
            //Debug.Log("collision");
            gc.SendMessage("MatchPlusTen");
            player.SendMessage("FireAdded");
        }
	}
    
}
