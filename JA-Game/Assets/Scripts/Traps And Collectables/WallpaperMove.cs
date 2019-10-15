using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WallpaperMove : MonoBehaviour {
    public float height = 1280, speed = 300;
    public Sprite a, b, c;
    public int background;
    private void Start()
    {
        background = PlayerPrefs.GetInt("Background");
        Time.timeScale = 1;
        foreach (Transform child in transform)
        {
            if (PlayerPrefs.GetInt("Background") == 1)
                child.GetComponent<Image>().sprite = a;
            if (PlayerPrefs.GetInt("Background") == 2)
                child.GetComponent<Image>().sprite = b;
            if (PlayerPrefs.GetInt("Background") == 3)
                child.GetComponent<Image>().sprite = c;
        }
    }

    void Update() {
        foreach (Transform child in transform)
        {
            child.GetComponent<RectTransform>().localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            if (child.GetComponent<RectTransform>().localPosition.y < -2 * height) child.GetComponent<RectTransform>().localPosition += new Vector3(0, 4 * height, 0);
        }
    }
    public void A()
    {
        if (background != 1)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeToA());
        }
        background = 1;
        PlayerPrefs.SetInt("Background", 1);
    }
    public void B() { 
        if (background != 2){
        StopAllCoroutines();
        StartCoroutine(ChangeToB());
        }
        background = 2;
        PlayerPrefs.SetInt("Background", 2);

    }
    public void C()
    {
        if (background != 3)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeToC());
        }
        background = 3;
        PlayerPrefs.SetInt("Background", 3);
    }
    public IEnumerator ChangeToA()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, 1 - time);
            }
            yield return new WaitForEndOfFrame();
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<Image>().sprite = a;
        }
        time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, time);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator ChangeToB()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, 1 - time);
            }
            yield return new WaitForEndOfFrame();
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<Image>().sprite = b;
        }
        time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, time);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator ChangeToC()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, 1 - time);
            }
            yield return new WaitForEndOfFrame();
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<Image>().sprite = c;
        }
        time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Vector4(1, 1, 1, time);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
