using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level20Script : MonoBehaviour
{
    // Slow X=2, Y=18.7
    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, ok = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false, tenth = false, eleventh = false, twelveth = false, thirteenth = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(1, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(1.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(2.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(3.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(3.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(1.7f, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(3.2f, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(8, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(8.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(9.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(10.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(10.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(8.7f, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth, Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.7f);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(10.2f, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth, Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.7f);

        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(17, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(17, "right");
        //Main.GetComponent<mapCreatorLevel1>().AddPlatform(20);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(23, regular, 4);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(23, reversed, 4);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(29, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(29.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(29, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(29.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(29.35f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPipe(31, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(32.5f, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(34, "left");
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(35.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(36, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(35.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(36, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(35.65f, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddGenerator(44, regular, 3);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(44, reversed, 3);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(57, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddPlatform(63);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(64);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(65);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(66);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(67);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(68);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(69);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(70);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(71);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(72);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(73);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(74);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(75);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(67.5f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(69, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(70.5f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(72, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(73.5f, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddPlatform(81);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(82);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(83);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(84);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(85);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(86);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(87);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(88);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(89);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(89.3f, "left");

        Quaternion a = new Quaternion();
        a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
        foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
        {
            if (something.name.StartsWith("Platform 1"))
                something.transform.rotation = a;
        }

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(93, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 94);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 93;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 98, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 98, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 98, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!eighth && time >= 1.5f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(58.5f, 0, 0);
            eighth = true;
        }
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 44)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1, 55);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, 55);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1, 55);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.7f, 55);
                first = true;
            }
            if (!second && Character.transform.position.y >= 47)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1, 58);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.7f, 58);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1, 58);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 2.4f, 58);
                second = true;
            }

        }
    }
}
