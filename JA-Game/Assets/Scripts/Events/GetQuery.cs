using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuery : MonoBehaviour {
	void Start () {
		GameObject.Find("FB Holder").GetComponent<FBholder>().QueryScores();
    } 
}
