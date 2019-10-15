using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour {
    public GameObject character, handPivot, hook;
    public Vector2 Target;
    public float angleInDegrees;

    public void Rotate(Touch x) {
        Target = new Vector2(x.position.x,
                             x.position.y);
        Target = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Target.x, Target.y, 0));
        float deltaX = Target.x - transform.position.x;
        float deltaY = Target.y - transform.position.y;
        angleInDegrees = Mathf.Atan2(deltaX, deltaY) * 180 / Mathf.PI;
        Vector3 Rotation = transform.eulerAngles;
        Rotation.z = 90 - angleInDegrees;
        handPivot.transform.eulerAngles = Rotation;
        if (angleInDegrees < 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }
}
