using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false;
    void Start () {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddPipe(0, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(1, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(5, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(9, "left");
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(11, reversed, 4);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(14, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(20);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(29, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPipe(31, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(37, "left"); // +3...
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(37, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(38, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(50, regular, 6);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(50, reversed, 6);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(55, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 56);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 54;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 59, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 59, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 59, 0));
    }

    // Update is called once per frame
    void Update () {
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 20)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.5f, 30);
                first = true;
            }
            if (!second && Character.transform.position.y >= 22)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.5f, 32);
                second = true;
            }
            if (!third && Character.transform.position.y >= 43)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 52);
                third = true;
            }
        }
    }
}
