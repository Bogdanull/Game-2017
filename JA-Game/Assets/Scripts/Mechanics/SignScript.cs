using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour {
    public float increase;
    public float time;
	void Update () {
        time += Time.deltaTime;
        float x = 1 + increase * Mathf.Sin(time * Mathf.PI);
        transform.localScale = new Vector3 (x, x, 1);
    }
}
