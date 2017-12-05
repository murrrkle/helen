using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    int counter;
    public GameObject medCandlePrefab;
    public GameObject lgCandlePrefab;
    private List<GameObject> candles;
    private float speed;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        candles = new List<GameObject>();
        speed = 10;

    }

    // Update is called once per frame
    void Update()
    {
        counter += 1;
        if (counter % 120 == 0)
        {
            GameObject g;
            switch ((int)UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    g = Instantiate(medCandlePrefab);
                    g.transform.position = new Vector3(11, 1, 1f);
                    break;
                case 1:
                    g = Instantiate(lgCandlePrefab);
                    g.transform.position = new Vector3(11, 1.5f, 1f);
                    break;
                default:
                    g = null;
                    break;
            }
            if (g != null)
            {
                candles.Add(g);
            }
        }

        if (counter % speed == 0)
            lock (candles)
            {
                foreach (GameObject c in candles)
                {
                    c.transform.position -= new Vector3(0.1f, 0, 0);

                    if (c.transform.position.x < -14.83f)
                    {
                        candles.Remove(c);
                        GameObject.Destroy(c);
                        return;
                    }
                    if (c.transform.position.x < -2.3f && !c.transform.GetChild(0).gameObject.activeSelf)
                    {
                        c.transform.GetChild(0).gameObject.SetActive(true);
                        return;
                    }
                }
            }
    }

    public void MinSpeed()
    {
        speed = 10;
    }

    public void HalfSpeed()
    {
        speed = 5;
    }

    public void MaxSpeed()
    {
        speed = 2;
    }
}
