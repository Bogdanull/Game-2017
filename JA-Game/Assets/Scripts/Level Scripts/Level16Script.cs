using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level16Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(0.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(1.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(0.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(1.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(1, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(5.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(6.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(5.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(6.4f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(13, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(12, "right");

        Main.GetComponent<mapCreatorLevel1>().AddPipe(20.5f, "left");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(33, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(33.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(34.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(35.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(35.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(36.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(33, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(33.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(34.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(35.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(35.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(36.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(39);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(36, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(45, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 46);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 45;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 50, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 50, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 50, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!eighth && time >= 0.2f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(6, 0, 0);

            eighth = true;
        }
        if (!seventh && time >= 0.4f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(11, 0, 0);
            seventh = true;
        }
        if (!sixth && time >= 0.4f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(22, "left");
            sixth = true;
        }
        if (!fifth && time >= 0.8f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(23.5f, "left");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(19, "left");
            fifth = true;
        }
        if (!fourth && time >= 1.2f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(25, "left");
            fourth = true;
        }
        if (!third && time >= 1.6f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(26.5f, "left");
            third = true;
        }
        if (!second && time >= 2)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(28, "left");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(19, "right");
            second = true;
        }
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 8)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 18);
                first = true;
            }
        }
    }
}
