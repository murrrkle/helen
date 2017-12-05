using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {
    int counter;
    public GameObject floorPrefab;
    private List<GameObject> floors;
    private float speed;
	// Use this for initialization
	void Start () {
        counter = 0;
        floors = new List<GameObject>();
        speed = 10;

        GameObject floor1 = Instantiate(floorPrefab);
        GameObject floor2 = Instantiate(floorPrefab);
        GameObject floor3 = Instantiate(floorPrefab);
        GameObject floor4 = Instantiate(floorPrefab);
        GameObject floor5 = Instantiate(floorPrefab);
        floor1.transform.position = new Vector3(-14, -3, 2f);
        floor2.transform.position = new Vector3(-7, -3, 2f);
        floor3.transform.position = new Vector3(0.7f, -3, 2f);
        floor4.transform.position = new Vector3(8.4f, -3, 2f);
        floor5.transform.position = new Vector3(16.1f, -3, 2f);
        floors.Add(floor1);
        floors.Add(floor2);
        floors.Add(floor3);
        floors.Add(floor4);
        floors.Add(floor5);

    }
	
	// Update is called once per frame
	void Update () {
        counter += 1;
        if (counter % speed == 0)
        lock(floors)
            {
            foreach (GameObject f in floors)
                {
                    f.transform.position -= new Vector3(0.1f, 0, 0);

                    if (f.transform.position.x < -17.83f)
                    {
                        floors.Remove(f);
                        GameObject.Destroy(f);
                        GameObject g = Instantiate(floorPrefab);
                        g.transform.position = new Vector3(16.1f, -3, 2f);
                        floors.Add(g);
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
