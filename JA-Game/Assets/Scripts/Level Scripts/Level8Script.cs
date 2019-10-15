using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false, fourth = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(2, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + 0.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + (0.7f) * 2, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + (0.7f) * 3, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + (0.7f) * 4, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + (0.7f) * 5, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2 + (0.7f) * 6, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(2 + (0.7f) * 7, regular);
        Main.GetComponent<mapCreatorLevel1>().AddPipe(8, "left");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(18, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + 0.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + (0.7f) * 2, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + (0.7f) * 3, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + (0.7f) * 4, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + (0.7f) * 5, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18 + (0.7f) * 6, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(18 + (0.7f) * 7, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddPipe(24, "right");

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(36, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(36, "right");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(41, false);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-1.6f, 42);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 41;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 46, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 46, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 46, 0));

    }

    void Update()
    {
        if (Character != null) { 

        if (!first && Character.transform.position.y >= 7)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 18);
            first = true;
        }
        if (!second && Character.transform.position.y >= 11)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 22);
            second = true;
        }
        if (!third && Character.transform.position.y >= 23)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 34);
            third = true;
        }
        if (!fourth && Character.transform.position.y >= 27)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 38);
            fourth = true;
        }
    }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
