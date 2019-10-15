using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class optionManager : MonoBehaviour {
    /*
    Options: 
    Sound: On/Off 
    Delete Data Button;
    */
    public Text a, b;
    public Image Music, SFX;
    public Sprite musicOn, musicOff, SFXon, SFXoff;

    public void Update()
    {
        if(PlayerPrefs.GetInt("Particles") == 1) a.text = "Particles: on";
        else a.text = "Particles: off";
        if (PlayerPrefs.GetInt("vibrationsOn") == 1) b.text = "Vibrations: on";
        else b.text = "Vibrations: off";
        if (PlayerPrefs.GetInt("musicOn") == 1) Music.sprite = musicOn;
        else Music.sprite = musicOff;
        if (PlayerPrefs.GetInt("SFXon") == 1) SFX.sprite = SFXon;
        else SFX.sprite = SFXoff;
    }

    public void deleteData(){
        PlayerPrefs.SetFloat("Highscore", 0);
        PlayerPrefs.SetInt("Finished", 0);
        PlayerPrefs.SetInt("TutorialCompleted", 0);
        PlayerPrefs.SetInt("Logged", 0);
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt("Finished", 21);
    }

    public void ChangeMusic()
    {
        if (PlayerPrefs.GetInt("musicOn") == 0)
        {
            PlayerPrefs.SetInt("musicOn", 1);
            if(GameObject.Find("Background Music")!=null) GameObject.Find("Background Music").GetComponent<AudioSource>().volume = 1;
            Music.sprite = musicOn;
        }
        else
        {
            PlayerPrefs.SetInt("musicOn", 0);
            if (GameObject.Find("Background Music") != null) GameObject.Find("Background Music").GetComponent<AudioSource>().volume = 0;
            Music.sprite = musicOff;
        }
    }

    public void ChangeVibration()
    {
        if (PlayerPrefs.GetInt("vibrationsOn") == 0)
        {
            PlayerPrefs.SetInt("vibrationsOn", 1);
            a.text = "Vibrations: on";
        }
        else
        {
            PlayerPrefs.SetInt("vibrationsOn", 0);
            a.text = "Vibrations: off";
        }
    }
    public void ChangeParticles()
    {
        if (PlayerPrefs.GetInt("Particles") == 0)
        {
            PlayerPrefs.SetInt("Particles", 1);
            b.text = "Particles: on";
        }
        else
        {
            PlayerPrefs.SetInt("Particles", 0);
            b.text = "Particles: off";
        }
    }

    public void ChangeSFX()
    {
        if (PlayerPrefs.GetInt("SFXon") == 0)
        {
            PlayerPrefs.SetInt("SFXon", 1);
            SFX.sprite = SFXon;
        }
        else
        {
            PlayerPrefs.SetInt("SFXon", 0);
            SFX.sprite = SFXoff;
        }
    }


    public void goToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
