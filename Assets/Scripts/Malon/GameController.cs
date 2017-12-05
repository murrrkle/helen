using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public FloorSpawner fs;
    public BgmController bc;
    public PlayerController pc;
    public CandleSpawner cs;

    GameObject malon;
    GameObject matchFire;
    Light matchLight;


    ParticleSystem malonParticles;

    private int counter;
    private int matchStrength;

    private int current;


    private const int MIN = 0;
    private const int HALF = 1;
    private const int MAX = 2;

    // Use this for initialization
    void Start () {
        counter = 0;
        matchStrength = 0;
        current = MIN;
        malon = GameObject.FindGameObjectWithTag("malon");
        malonParticles = GameObject.FindGameObjectWithTag("malon-particle").GetComponent<ParticleSystem>();
        malonParticles.Stop();
        matchFire = GameObject.FindGameObjectWithTag("match-fire");
        matchLight = GameObject.FindGameObjectWithTag("match-light").GetComponent<Light>();
    }
	public void MatchPlusTen()
    {
        matchStrength += 15;
        if (matchStrength >= 100)
            matchStrength = 100;
    }
	// Update is called once per frame
	void Update () {
        counter += 1;

        if (counter % 120 == 0)
        {
            if (matchStrength > 0)
                matchStrength -= 1;

            Debug.Log(matchStrength);
        }

        if (counter % 500 == 0)
        {
            pc.SpawnFire();
        }

        if ((matchStrength < 30) && (current != MIN))
        {
            Debug.Log("Small");
            bc.PlayMin();
            fs.MinSpeed();
            cs.MinSpeed();
            malon.SendMessage("Totter");
            matchFire.SendMessage("Small");
            matchLight.range = 5;
            matchLight.intensity = 1;
            malonParticles.Stop();
            current = MIN;
        }
        else if ((matchStrength >= 30 && matchStrength < 70) && (current != HALF))
        {
            Debug.Log("Med");
            bc.PlayHalf();
            fs.HalfSpeed();
            cs.HalfSpeed();
            malon.SendMessage("Walk");
            matchFire.SendMessage("Med");
            matchLight.range = 10;
            matchLight.intensity = 1f;
            malonParticles.Stop();
            current = HALF;
        }

        else if ((matchStrength >= 70 && matchStrength <= 100) && (current != MAX))
        {
            Debug.Log("Lg");
            bc.PlayMax();
            fs.MaxSpeed();
            cs.MaxSpeed();
            malon.SendMessage("Walk");
            matchFire.SendMessage("Large");
            matchLight.range = 15;
            matchLight.intensity = 2;
            malonParticles.Play();
            current = MAX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            MatchPlusTen();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            matchStrength -= 10;
            if (matchStrength < 0)
                matchStrength = 0;
        }
    }
}
