using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour {

    private int current;
    private bool switching;
    private int dest;
    private const int MIN = 0;
    private const int HALF = 1;
    private const int MAX = 2;

    public float gainFactor;

    public AudioSource min;
    public AudioSource half;
    public AudioSource max;

    void Start()
    {
        switching = false;
        current = MIN;
        dest = -1;
    }

    void Update()
    {
        if (switching && dest >= MIN)
        {
            switch (dest)
            {
                case MIN:
                    if (current == MAX)
                    {
                        min.volume += gainFactor;
                        max.volume -= gainFactor;
                    } else if (current == HALF)
                    {
                        min.volume += gainFactor;
                        half.volume -= gainFactor;
                    }

                    break;
                case HALF:
                    if (current == MAX)
                    {
                        half.volume += gainFactor;
                        max.volume -= gainFactor;
                    }
                    else if (current == MIN)
                    {
                        half.volume += gainFactor;
                        min.volume -= gainFactor;
                    }
                    break;
                case MAX:
                    if (current == MIN)
                    {
                        max.volume += gainFactor;
                        min.volume -= gainFactor;
                    }
                    else if (current == HALF)
                    {
                        max.volume += gainFactor;
                        half.volume -= gainFactor;
                    }
                    break;

                default:
                    Debug.Log("Something went wrong...");
                    break;
            }

            if ((min.volume == 0 || min.volume == 1) && (half.volume == 0 || half.volume == 1) && (max.volume == 0 || max.volume == 1))
            {
                switching = false;
                if (min.volume == 1)
                    current = MIN;
                else if (half.volume == 1)
                    current = HALF;
                else if (max.volume == 1)
                    current = MAX;
                dest = -1;
            }
        }
    }

    public void PlayMin()
    {
        if (current != MIN)
        {
            switching = true;
            dest = MIN;
        }
    }

    public void PlayHalf()
    {
        if (current != HALF)
        {
            switching = true;
            dest = HALF;
        }
    }

    public void PlayMax()
    {
        if (current != MAX)
        {
            switching = true;
            dest = MAX;
        }
    }
}
