using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInit : MonoBehaviour {
	void Start () {
        if (PlayerPrefs.GetInt("SFXon") == 0)
            GetComponent<AudioSource>().volume = 0;
    }

}
