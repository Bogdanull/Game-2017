using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class componentDeleter : MonoBehaviour {
    public Vector3 pos;
    public float ScreenHeight;
    GameObject camera;
	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
        if (GameObject.Find("GM").GetComponent<mapCreator>() != null)
            ScreenHeight = GameObject.Find("GM").GetComponent<mapCreator>().ScreenHeight;
        else if (GameObject.Find("GM").GetComponent<mapCreatorLevel1>() != null)
            ScreenHeight = GameObject.Find("GM").GetComponent<mapCreatorLevel1>().ScreenHeight;
        else if (GameObject.Find("GM").GetComponent<MapCreatorTutorial>() != null)
            ScreenHeight = GameObject.Find("GM").GetComponent<MapCreatorTutorial>().ScreenHeight;
        if(ScreenHeight==0) ScreenHeight = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }
	
	// Update is called once per frame
	void Update () {
        if (camera.transform.position.y-this.transform.position.y-5>ScreenHeight)
        {
            Destroy(this.gameObject);
        }
    }
}
