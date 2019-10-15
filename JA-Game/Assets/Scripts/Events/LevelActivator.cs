using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelActivator : MonoBehaviour {
    public Button first, second, third, fourth, fifth, sixth, seventh, eigth, ninth;
    public Button a, b, c, d, e, f;
    public Button a1, b1, c1, d1, e1, f1;
    public GameObject set1, set2, set3;
    void Start () {
        int x = PlayerPrefs.GetInt("Finished");
        if (0 <= x)
        {
            first.interactable = true;
        }
        if (1 <= x)
        {
            second.interactable = true;
        }
        if (2 <= x)
        {
            third.interactable = true;
        }
        if (3 <= x)
        {
            fourth.interactable = true;
        }
        if (4 <= x)
        {
            fifth.interactable = true;
        }
        if (5 <= x)
        {
            sixth.interactable = true;
        }
        if (6 <= x)
        {
            seventh.interactable = true;
        }
        if (7 <= x)
        {
            eigth.interactable = true;
        }
        if (8 <= x)
        {
            ninth.interactable = true;
        }
        if (9 <= x)
        {
            a.interactable = true;
        }
        if (10 <= x)
        {
            b.interactable = true;
        }
        if (11 <= x)
        {
            c.interactable = true;
        }
        if (12 <= x)
        {
            d.interactable = true;
        }
        if (13 <= x)
        {
            e.interactable = true;
        }
        if (14 <= x)
        {
            f.interactable = true;
        }
        if (15 <= x)
        {
            a1.interactable = true;
        }
        if (16 <= x)
        {
            b1.interactable = true;
        }
        if (17 <= x)
        {
            c1.interactable = true;
        }
        if (18 <= x)
        {
            d1.interactable = true;
        }
        if (19 <= x)
        {
            e1.interactable = true;
        }
        if (20 <= x)
        {
            f1.interactable = true;
        }
        if (PlayerPrefs.GetInt("Background") == 1) Set1();
        if (PlayerPrefs.GetInt("Background") == 2) Set2();
        if (PlayerPrefs.GetInt("Background") == 3) Set3();
    }
    public void Set1()
    {
        set1.SetActive(true);
        set2.SetActive(false);
        set3.SetActive(false);
    }
    public void Set2()
    {
        set2.SetActive(true);
        set1.SetActive(false);
        set3.SetActive(false);
    }
    public void Set3()
    {
        set3.SetActive(true);
        set2.SetActive(false);
        set1.SetActive(false);
    }
}
