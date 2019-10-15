using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject following;
    public float ScreenHeight, followup, speed;
    public float position, lastposition, maximPos;
    public bool start = false, maxExist;
    Camera camera;
    void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ScreenHeight = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        lastposition = 0;
    }

    void Update()
    {
        if (start == false && Input.touchCount > 0) start = true;
        if (start && (!maxExist || maximPos > transform.position.y) && following !=null)
        {
            this.transform.position += new Vector3(0, Time.deltaTime * speed, 0);
            lastposition += Time.deltaTime * speed;
            if (lastposition < following.transform.position.y + followup)
            {
                this.transform.position = new Vector3(this.transform.position.x, following.transform.position.y + followup, -10);
                lastposition = following.transform.position.y + followup ;
            }
        }
    }
}
