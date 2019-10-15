using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15Script : MonoBehaviour
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
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(3);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(4);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(5);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(6);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(7);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(8);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(9);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(10);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(11);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(11.3f, "left");

        Main.GetComponent<mapCreatorLevel1>().AddSaw(17, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(28, "right");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(29.5f, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(31, "left");

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(47, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(47, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 2, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(50, "right");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(55, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(55.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(56.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(57.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(57.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(58.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(59, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(59.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(55, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(55.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(56.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(57.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(57.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(58.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(59, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(59.7f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddPipe(64, "left");

        Quaternion a = new Quaternion();
        a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
        foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
        {
            if (something.name.StartsWith("Platform 1"))
                something.transform.rotation = a;
        }

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(70, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 71);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 70;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 75, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 75, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 75, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Character != null)
        {
            if (Character.transform.position.y >= -2 && !first)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.5f, 9);
                first = true;
            }
            if (Character.transform.position.y >= 33 && !second)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 44);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0.3f, 44);
                second = true;
            }
            if (Character.transform.position.y >= 36 && !third)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 47);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-0.3f, 47);
                third = true;
            }
            if (Character.transform.position.y >= 60 && !fourth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 70);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 70);
                fourth = true;
            }
        }
        if (time >= 1 && !sixth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(20, 0, 0);
            Main.GetComponent<mapCreatorLevel1>().AddSaw(50, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth, Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 2);
            sixth = true;
        }
        if (time >= 0.5f && !eighth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(23, 0, 0);
            eighth = true;
        }
    }
}
