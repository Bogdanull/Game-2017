using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {
    GameObject Point;
	// Use this for initialization
	void Start () {
        Point = GameObject.Find("LowestPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if(Point.transform.position.y > this.transform.position.y)
            foreach(Transform a in transform)
            {
                a.GetComponent<Collider2D>().isTrigger = false;
            }
        else
            foreach (Transform a in transform)
            {
                a.GetComponent<Collider2D>().isTrigger = true;
            }
    }
}
