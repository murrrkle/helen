using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public List<BodyGameObject> bodies = new List<BodyGameObject>();
    public List<Player> players = new List<Player>();

    public Player playerPrefab;

    void Start()
    {

    }


    //wait for KinectManager to completely update first
    void LateUpdate()
    {
        //TODO Your code here
        if (bodies.Count > 0)
        {
            foreach (BodyGameObject g in bodies)
            {
                GameObject spinebase = bodies[0].GetJoint(Windows.Kinect.JointType.SpineBase);
                
            }
            //some bodies, send orientation update
            //GameObject thumbRight = bodies[0].GetJoint(Windows.Kinect.JointType.ThumbRight);
            //GameObject handRight = bodies[0].GetJoint(Windows.Kinect.JointType.HandRight);
            //GameObject handTipRight = bodies[0].GetJoint(Windows.Kinect.JointType.HandTipRight);

            //float wristRotation = KinectCVUtilities.VerticalWristRotation(
            //    handTipRight.transform.localPosition,
            //    handRight.transform.localPosition,
            //    thumbRight.transform.localPosition
            //    );

            //update the rotation
            //this.transform.rotation = Quaternion.Euler(0, wristRotation, 0);

        }
    }




    void Kinect_BodyFound(object args)
    {
        BodyGameObject bodyFound = (BodyGameObject)args;
        bodies.Add(bodyFound);
        Debug.Log("Body found: " + bodyFound.ID);
        Player p = Instantiate(playerPrefab);
        players.Add(p);
        p.ID = bodyFound.ID;
        p.body = bodyFound;
    }

    void Kinect_BodyLost(object args)
    {
        ulong bodyDeletedId = (ulong)args;
        Debug.Log("Body lost: " + bodyDeletedId);
        lock (bodies)
        {
            foreach (BodyGameObject bg in bodies)
            {
                if (bg.ID == bodyDeletedId)
                {
                    bodies.Remove(bg);
                    lock (players)
                    {
                        foreach (Player p in players)
                        {
                            if (p.ID == bodyDeletedId)
                            {
                                p.Destroy();
                                players.Remove(p);
                                return;
                            }
                        }
                    }
                    return;
                }
            }
        }
    }
}
