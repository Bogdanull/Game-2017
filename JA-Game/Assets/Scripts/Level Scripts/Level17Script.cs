using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level17Script : MonoBehaviour
{
    // JETPACK  X=0  Y=28
    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false, tenth = false, eleventh = false, twelveth = false, thirteenth = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddPipe(-1, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(0, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(1, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(2, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(3, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(4, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(5, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(6, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(7, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(8, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(9, "left");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(15, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(15.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(16.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(17.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(17.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(19, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(19.7f, regular);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(15, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(15.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(16.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(17.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(17.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(19, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(19.7f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddPlatform(22);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(47, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(47.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(48.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(50.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(51, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(51.7f, regular);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(47, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(47.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(48.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(50.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(51, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(51.7f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(56, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 57);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 56;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 61, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 61, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 61, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!ninth && time >= 0.3f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(16, 0, 0);
            ninth = true;
        }
        if (!eighth && time >= 0.5f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(17.5f, 0, 0);
            eighth = true;
        }
        if (!seventh && time >= 0.7f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(19, 0, 0);
            seventh = true;
        }
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 29)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 40);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 40);
                time = 0;
                first = true;
            }
            if (first && !second && time >= 0.3f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.9f, 41);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 41);
                second = true;
            }
            if (first && !third && time >= 0.6f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 2.2f, 42);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1, 42);
                third = true;
            }
            if (first && !fourth && time >= 0.9f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.9f, 43);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 43);
                fourth = true;
            }
            if (first && !fifth && time >= 1.2f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 44);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 44);
                fifth = true;
            }
            if (first && !tenth && time >= 1.5f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 45);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.9f, 45);
                tenth = true;
            }
            if (first && !eleventh && time >= 1.8f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1, 46);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 2.2f, 46);
                eleventh = true;
            }
            if (first && !twelveth && time >= 2.1f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 47);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.9f, 47);
                twelveth = true;
            }
            if (first && !thirteenth && time >= 2.4f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 48);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 48);
                thirteenth = true;
            }
        }
    }
}
