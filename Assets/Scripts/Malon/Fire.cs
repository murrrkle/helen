using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Small()
    {
        anim.Play("fire_small");
    }

    public void Med()
    {
        anim.Play("fire_med");
    }

    public void Large()
    {
        anim.Play("fire_lg");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
