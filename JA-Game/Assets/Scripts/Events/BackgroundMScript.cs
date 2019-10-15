using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("musicOn");
        GetComponent<Events>().GoMenu();
    }

}
