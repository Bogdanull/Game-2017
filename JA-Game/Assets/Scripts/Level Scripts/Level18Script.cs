using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level18Script : MonoBehaviour
{
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

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(0, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(2, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(4, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(6, "left");

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(12, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(12, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(13.5f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(15, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(15, "right");

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(23.5f, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(23.5f, "right");

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(31, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(31, "right");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(32, "left");
        //Main.GetComponent<mapCreatorLevel1>().AddPipe(33, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(34, "left");
        //Main.GetComponent<mapCreatorLevel1>().AddPipe(35, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(36, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(37, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(37, "right");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(45, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(45.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(46.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(47.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(47.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(48.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(50.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(51.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(51.8f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(57, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(57.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(58.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(59.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(59.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(60.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(61, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(61.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(62.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(63.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(63.8f, regular);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(69, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(69.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(70.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(71.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(71.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(72.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(73, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(73.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(74.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(75.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(75.8f, reversed);


        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(82, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 83);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 82;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 87, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 87, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 87, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!ninth && time >= 0.3f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(22, 0, 0);
            Main.GetComponent<mapCreatorLevel1>().AddSaw(25, 0, 0);
            ninth = true;
        }
        if (!eighth && time >= 1.5f)
        {
            //Main.GetComponent<mapCreatorLevel1>().AddPipe(32, "right");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(33, "right");
            //Main.GetComponent<mapCreatorLevel1>().AddPipe(34, "right");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(35, "right");
            //Main.GetComponent<mapCreatorLevel1>().AddPipe(36, "right");
            eighth = true;
        }
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 43)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.4f, 65.5f);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-0.2f, 65.5f);
                first = true;
            }
            if (!second && Character.transform.position.y >= 55)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0.2f, 77.5f);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.4f, 77.5f);
                second = true;
            }
            if (!third && Character.transform.position.y >= 67)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.4f, 89.5f);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-0.2f, 89.5f);
                third = true;
            }
        }
    }
}
