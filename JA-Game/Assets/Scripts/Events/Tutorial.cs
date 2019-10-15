using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    bool showed1 = false, showed2 = false, showed3=false;
    public GameObject i1, i2, i3;
    public float cooldown;
    GameObject x;
	void Start () {
        if (PlayerPrefs.GetInt("TutorialCompleted") == 1) Destroy(gameObject);
        else
        {
            Time.timeScale = 0;
            x = GameObject.Find("Game Canvas");
            x.SetActive(false);
        }
	}
	
	void Update() {
        cooldown -= Time.fixedDeltaTime;
        if (!showed1 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            showed1 = true;
            i2.SetActive(true);
            cooldown = 0.1f;
        }
        if (!showed2 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && cooldown<=0)
        {
            showed2 = true;
            i3.SetActive(true);
            cooldown = 0.1f;
        }
        if (!showed3 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && cooldown<=0)
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            x.SetActive(true);
            Destroy(gameObject);
        }
    }
}
