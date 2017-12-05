using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public ulong ID;
    public BodyGameObject body;
    private Light pointlight;

    private Vector3 lastPos;

	// Use this for initialization
	void Start () {
        pointlight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 spineBasePos = body.GetJoint(Windows.Kinect.JointType.SpineBase).transform.position;
        lastPos = new Vector3(spineBasePos.x, spineBasePos.y-3, 0.1f);
        this.transform.position = lastPos;

    }

    internal void Destroy()
    {
        GameObject.Destroy(pointlight.gameObject);
    }
}
