using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level21Script : MonoBehaviour
{
    // Slow X=2, Y=18.7
    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, ok1 = false, ok2 = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false, tenth = false, eleventh = false, twelveth = false, thirteenth = false, fourteenth = false, fifteenth = false, sixteenth = false;
    float time = 0, time1 = 0, time2 = 0 ;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(0, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(1.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(3.5f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(4, reversed, 3);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(8, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(8.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(9.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(10.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(10.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(11.5f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(12, regular, 3);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(17, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(17.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(18.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(19.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(19.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(20.5f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(18, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);

        Main.GetComponent<mapCreatorLevel1>().AddGate(0.2f, 88);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 88;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 93, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 93, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 93, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        if (time >= 1.1f && !first)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(19.5f, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);
            first = true;
        }
        if (time1 >= 0.5f && ok1 && !third)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(27, "left");
            third = true;
        }
        if (time1 >=1.5f && ok1 && !fourth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(28.5f, "left");
            fourth = true;
        }
        if (time1 >= 2.5f && ok1 && !fifth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddPipe(30, "left");
            fifth = true;
        }
        if (time2 >= 0.5f && ok2 && !ninth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(70.5f, 0, 0);
            ninth = true;
        }
        if (time2 >= 1 && ok2 && !tenth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(72, 0, 0);
            tenth = true;
        }
        if (time2 >= 1.5f && ok2 && !eleventh)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(73.5f, 0, 0);
            eleventh = true;
        }
        if (time2 >= 2 && ok2 && !twelveth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(75, 0, 0);
            twelveth = true;
        }
        if (time2 >= 2.5f && ok2 && !thirteenth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(76.5f, 0, 0);
            thirteenth = true;
        }
        if (time2 >= 3 && ok2 && !fourteenth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(78, 0, 0);
            fourteenth = true;
        }
        if (time2 >= 3.5f && ok2 && !fifteenth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(79.5f, 0, 0);
            fifteenth = true;
        }

        if (Character != null)
        {
            if (!second && Character.transform.position.y >= 12)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(31.5f, "right");
                ok1 = true;
                time1 = 0;
                second = true;
            }
            if (!sixth && Character.transform.position.y >= 26)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSaw(37, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(38.5f, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(40, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddPipe(41.5f, "left");
                Main.GetComponent<mapCreatorLevel1>().AddPipe(43.5f, "left");
                Main.GetComponent<mapCreatorLevel1>().AddPipe(45.5f, "left");
                Main.GetComponent<mapCreatorLevel1>().AddSaw(47, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(48.5f, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(50, 0, 0);
                sixth = true;
            }
            if (!seventh && Character.transform.position.y >= 46)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(58);
                Main.GetComponent<mapCreatorLevel1>().AddPlatform(59);
                Main.GetComponent<mapCreatorLevel1>().AddGenerator(61, regular, 4);
                Main.GetComponent<mapCreatorLevel1>().AddGenerator(61, reversed, 4);

                Quaternion a = new Quaternion();
                a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
                foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
                {
                    if (something.name.StartsWith("Platform 1"))
                        something.transform.rotation = a;
                }

                seventh = true;
            }
            if (!eighth && Character.transform.position.y >= 55)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 65);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 65);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(69, 0, 0);
                ok2 = true;
                time2 = 0;
                eighth = true;
            }
            if (!sixteenth && Character.transform.position.y >= 75)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(87, "right");
                sixteenth = true;
            }
        }
    }
}
