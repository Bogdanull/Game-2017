using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {
    Color color;
    public float time = 0, timeToChange;
    bool fading;
	void Update () {
        if (!fading)
            time += Time.deltaTime;
        else if (fading) time -= Time.deltaTime;
        if (time >= timeToChange) fading = true;
        else if (time <= 0) fading = false;
        color.r = 1;
        color.g = 1;
        color.b = 1;
        color.a = time/timeToChange;
        GetComponent<SpriteRenderer>().color = color;
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            GameObject.Find("GM").GetComponent<mapCreatorLevel1>().Win();
            if (Application.loadedLevelName == "Level1")
            {
                PlayerPrefs.SetInt("Finished", Mathf.Max(1, PlayerPrefs.GetInt("Finished")));
                PlayerPrefs.SetInt("TutorialCompleted", 1);
            }
            if (Application.loadedLevelName == "Level2")
                PlayerPrefs.SetInt("Finished", Mathf.Max(2, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level3")
                PlayerPrefs.SetInt("Finished", Mathf.Max(3, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level4")
                PlayerPrefs.SetInt("Finished", Mathf.Max(4, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level5")
                PlayerPrefs.SetInt("Finished", Mathf.Max(5, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level6")
                PlayerPrefs.SetInt("Finished", Mathf.Max(6, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level7")
                PlayerPrefs.SetInt("Finished", Mathf.Max(7, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level8")
                PlayerPrefs.SetInt("Finished", Mathf.Max(8, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level9")
                PlayerPrefs.SetInt("Finished", Mathf.Max(9, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level10")
                PlayerPrefs.SetInt("Finished", Mathf.Max(10, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level11")
                PlayerPrefs.SetInt("Finished", Mathf.Max(11, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level12")
                PlayerPrefs.SetInt("Finished", Mathf.Max(12, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level13")
                PlayerPrefs.SetInt("Finished", Mathf.Max(13, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level14")
                PlayerPrefs.SetInt("Finished", Mathf.Max(14, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level15")
                PlayerPrefs.SetInt("Finished", Mathf.Max(15, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level16")
                PlayerPrefs.SetInt("Finished", Mathf.Max(16, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level17")
                PlayerPrefs.SetInt("Finished", Mathf.Max(17, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level18")
                PlayerPrefs.SetInt("Finished", Mathf.Max(18, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level19")
                PlayerPrefs.SetInt("Finished", Mathf.Max(19, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level20")
                PlayerPrefs.SetInt("Finished", Mathf.Max(20, PlayerPrefs.GetInt("Finished")));
            if (Application.loadedLevelName == "Level21")
                PlayerPrefs.SetInt("Finished", Mathf.Max(21, PlayerPrefs.GetInt("Finished")));
        }

    }
}
