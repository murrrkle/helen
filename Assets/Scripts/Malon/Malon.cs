using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malon : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	public void Walk()
    {
        anim.Play("malon-walk");
    }
    public void Totter()
    {
        anim.Play("malon-totter");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
