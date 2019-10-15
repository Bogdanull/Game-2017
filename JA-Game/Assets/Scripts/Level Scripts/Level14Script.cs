using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, ok = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false, tenth = false, eleventh = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(0);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(1);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(2);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(3);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(4);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(5);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(3, 0, 0);

        Quaternion a = new Quaternion();
        a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
        foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
        {
            if (something.name.StartsWith("Platform 1"))
                something.transform.rotation = a;
        }

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(64, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 65);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 64;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 69, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 69, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 69, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Character != null)
        {
            if (Character.transform.position.y >= 8 && !first)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 18);
                first = true;
            }
            if (Character.transform.position.y >= 10 && !second)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 20);
                second = true;
            }
            if (Character.transform.position.y >= 12 && !third)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 22);
                third = true;
            }
            if (Character.transform.position.y >= 14 && !fourth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 24);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 24);
                fourth = true;
            }
            if (Character.transform.position.y >= 16 && !fifth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 26);
                fifth = true;
            }
            if (Character.transform.position.y >= 37 && !ninth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 48);
                ninth = true;
            }
            if (Character.transform.position.y >= 28 && !tenth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(39, "left");
                Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(43.5f, "left");
                Main.GetComponent<mapCreatorLevel1>().AddSaw(40.5f, 0, 0);

                Main.GetComponent<mapCreatorLevel1>().AddPlatform(50);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(51);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(52);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(53);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(54);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(55);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(56);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(57);

                Main.GetComponent<mapCreatorLevel1>().AddPipe(56, "left");

                Quaternion a = new Quaternion();
                a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
                foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
                {
                    if (something.name.StartsWith("Platform 1"))
                        something.transform.rotation = a;
                }

                ok = true;
                time = 0;
                tenth = true;
            }
        }
        if (time >= 1 && !sixth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(27, "left");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(28, "left");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(29, "left");
            sixth = true;
        }
        if (ok)
        {
            if (time >= 0.2f && !eighth)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSaw(42, 0, 0);
                eighth = true;
            }
            if (time >= 2.5f && !eleventh)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(51, "left");
                eleventh = true;
            }
        }
            if (time >= 2.5f && !seventh)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(30, "right");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(31, "right");
            Main.GetComponent<mapCreatorLevel1>().AddPipe(32, "right");
            seventh = true;
        }
    }
}
