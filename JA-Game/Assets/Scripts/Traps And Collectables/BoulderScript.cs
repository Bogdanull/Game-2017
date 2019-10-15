using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    public float fallingSpeed, rotateSpeed, Height;
    public GameObject AlertSign;
    GameObject Sign;

    void Start()
    {
        Sign = Instantiate(AlertSign, new Vector3(transform.position.x, Height + GameObject.Find("Main Camera").GetComponent<Camera>().transform.position.y, -5), Quaternion.identity);
        if (GameObject.Find("Character").GetComponent<Controller>().slowTime)
            fallingSpeed = fallingSpeed / 2;
    }

    void Update()
    {
        transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime, 0);
        var a = transform.rotation.eulerAngles;
        if (a.z == -180) a.z = 0;
        a.z += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(a);
        if (Sign!=null && transform.position.y <= Sign.transform.position.y)
            Destroy(Sign);
        if (Sign!=null) Sign.transform.position = new Vector3(transform.position.x, Height + GameObject.Find("Main Camera").GetComponent<Camera>().transform.position.y, -5);
    }

}