using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMove : MonoBehaviour {

	void Update () {
        if (GameObject.Find("Character") != null)
        this.transform.position = new Vector3(this.transform.position.x, GameObject.Find("Character").transform.position.y, this.transform.position.z);
	}
}
