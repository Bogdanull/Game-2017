using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour {
    GameObject text;
    public GameObject x;
    float time = 0;
	void Awake () {
        text = GameObject.Find("Loading");
        DontDestroyOnLoad(gameObject);
        x = GameObject.Find("Loading Image");
        int backgroundToSpawn = PlayerPrefs.GetInt("Background");
        if (backgroundToSpawn == 1)
        {
            x.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Wallpaper");
        }
        if (backgroundToSpawn == 2)
        {
            x.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/TransWallpaper");
        }
        if (backgroundToSpawn == 3)
        {
            x.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/SecondWallpaper");
        }
        
	}
    private void OnLevelWasLoaded(int level)
    {
        DestroyImmediate(gameObject);
    }
}
