using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public FloorSpawner fs;
    public BgmController bc;
    public PlayerController pc;

    GameObject malon;
    GameObject matchFire;
    Light matchLight;

    ParticleSystem malonParticles;

    // Use this for initialization
    void Start () {
        malon = GameObject.FindGameObjectWithTag("malon");
        malonParticles = GameObject.FindGameObjectWithTag("malon-particle").GetComponent<ParticleSystem>();
        malonParticles.Stop();
        matchFire = GameObject.FindGameObjectWithTag("match-fire");
        matchLight = GameObject.FindGameObjectWithTag("match-light").GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            bc.PlayMin();
            fs.MinSpeed();
            malon.SendMessage("Totter");
            matchFire.SendMessage("Small");
            matchLight.range = 5;
            matchLight.intensity = 1;
            malonParticles.Stop();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            bc.PlayHalf();
            fs.HalfSpeed();
            malon.SendMessage("Walk");
            matchFire.SendMessage("Med");
            matchLight.range = 10;
            matchLight.intensity = 1f;
            malonParticles.Stop();
        }

        else if (Input.GetButtonDown("Fire3"))
        {
            bc.PlayMax();
            fs.MaxSpeed();
            malon.SendMessage("Walk");
            matchFire.SendMessage("Large");
            matchLight.range = 15;
            matchLight.intensity = 2;
            malonParticles.Play();
        }
    }
}
