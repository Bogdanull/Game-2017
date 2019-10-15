using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawScript : MonoBehaviour {
    public float rotationSpeed, movingSpeed, speed, rotation;
    public bool moving, right, left;
    public float ScreenWidth, leftSide, rightSide;
	// Use this for initialization
	void Awake () {
        if (GameObject.Find("Character").GetComponent<Controller>().slowTime)
            movingSpeed = movingSpeed / 2;
        ScreenWidth = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        leftSide = -ScreenWidth;
        rightSide = ScreenWidth;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        if (moving)
        {
            float mid = (rightSide + leftSide) / 2;
            speed = movingSpeed * 1 / 3;
            speed +=  (1 - Mathf.Abs(transform.position.x - mid) / (rightSide-mid)) * movingSpeed * 2 / 3;
            rotation = rotationSpeed * 1 / 4 +
                (1 - Mathf.Abs(transform.position.x - mid) / (rightSide - mid)) * rotationSpeed * 3 / 4;
            if (left)
                if (leftSide < transform.position.x - movingSpeed * Time.deltaTime)
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                else
                {
                    left = false;
                    right = true;
                }
            else
            if (rightSide > transform.position.x + movingSpeed * Time.deltaTime)
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            else
            {
                left = true;
                right = false;
            }
        }
    }
}
