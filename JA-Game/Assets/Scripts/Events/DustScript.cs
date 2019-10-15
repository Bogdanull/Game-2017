using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : MonoBehaviour {
    float time;
    bool exploded = false;
    public GameObject meat, meat1, meat2;
	void Awake() {
        time = 0;

    }

    void Update () {
        time += Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Min(2 - time, 1));
        if (time >= 0.2f && !exploded)
        {
            exploded = true;
            GameObject x;
            x = Instantiate(meat, transform.position, Quaternion.identity);
            x.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
            x.transform.position += new Vector3(0, 0, 1);
            x = Instantiate(meat1, transform.position, Quaternion.identity);
            x.GetComponent<Rigidbody2D>().AddForce(new Vector2(80, 300));
            x.transform.position += new Vector3(0, 0, 1);
            x = Instantiate(meat2, transform.position, Quaternion.identity);
            x.GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, 300));
            x.transform.position += new Vector3(0, 0, 1);
        }
        if (time >= 2) Destroy(gameObject);    
        }
}
