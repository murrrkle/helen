using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public ulong ID;
    public BodyGameObject body;
    private Light pointlight;

    private Vector3 lastPos;
    private Vector3 lastFirePos;

    private bool hasFire;
    private PlayerFire fire; 
    public PlayerFire playerFirePrefab;

	// Use this for initialization
	void Start () {
        pointlight = GetComponent<Light>();
        fire = null;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 spineBasePos = body.GetJoint(Windows.Kinect.JointType.SpineBase).transform.position;
        lastPos = new Vector3(spineBasePos.x, spineBasePos.y-3, 0.1f);
        this.transform.position = lastPos;

        if (fire != null)
        {
            Vector3 firePos = body.GetJoint(Windows.Kinect.JointType.HandRight).transform.position;

            fire.transform.Translate(new Vector3((firePos.x-lastFirePos.x)*3, (firePos.y - lastFirePos.y) * 3,0));
            //fire.transform.position = new Vector3(firePos.x, firePos.y, 0.1f);

            lastFirePos = firePos;

            
        }

    }

    internal void Destroy()
    {
        GameObject.Destroy(fire);
        GameObject.Destroy(pointlight.gameObject);
    }

    public bool SpawnFire()
    {
        if (!hasFire)
        {
            fire = Instantiate(playerFirePrefab);
            fire.player = this;
            hasFire = true;
            return true;
        }
        return false;
    }

    public void FireAdded()
    {
        //GameObject f = GameObject.FindGameObjectWithTag("flame-ripple");
        //f.transform.position = fire.transform.position;
        //f.GetComponent<ParticleSystem>().Emit(1);
        hasFire = false;
        GameObject.Destroy(fire.gameObject);
        fire = null;
        lastFirePos = new Vector3(0, 0, 0);
    }
}
