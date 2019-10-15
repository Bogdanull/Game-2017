using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level19Script : MonoBehaviour
{
    // Slow X=2, Y=18.7
    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, ok = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false, eighth = false, ninth = false, tenth = false, eleventh = false, twelveth = false, thirteenth = false, fourteenth = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().

        Main.GetComponent<mapCreatorLevel1>().AddSaw(1.5f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(3, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(3.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(4.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(5.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(5.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(6.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(3, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(3.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(4.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(5.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(5.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(6.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(7.8f, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(15, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(16.5f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(18, 0, 0);

        

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(45, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(45.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(45, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(45.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(45.35f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(49);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(53, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(53.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(53, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(53.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(57);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(57, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(61, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(61.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(62.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(63.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(63.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(64.3f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(65, regular);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(61, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(61.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(62.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(63.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(63.8f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(64.3f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(65, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(72, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 73);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 72;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 77, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 77, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 77, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!fourteenth && time >= 0.3f)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(19.5f, 0, 0);
            Main.GetComponent<mapCreatorLevel1>().AddSaw(21, 0, 0);
            Main.GetComponent<mapCreatorLevel1>().AddSaw(22.5f, 0, 0);
            fourteenth = true;
        }
        if (ok)
        {
            if (!eighth && time >= 0.5f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSaw(61.6f, 0, 0);
                Main.GetComponent<mapCreatorLevel1>().AddSaw(53.35f, 0, 0);
                eighth = true;
            }
            if (!tenth && time >= 1)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSaw(63.1f, 0, 0);
                tenth = true;
            }
            if (!eleventh && time >= 1.5f)
            {
                Main.GetComponent<mapCreatorLevel1>().AddSaw(64.6f, 0, 0);
                eleventh = true;
            }
            if (!ninth && time >= 1)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(31, "left");
                ninth = true;
            }
            if (!seventh && time >= 2)
            {

                Main.GetComponent<mapCreatorLevel1>().AddPipe(32, "left");
                seventh = true;
            }
            if (!sixth && time >= 3)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(33, "left");
                sixth = true;
            }
            if (!fifth && time >= 4)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(34, "left");
                fifth = true;
            }
            if (!fourth && time >= 5)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(35, "left");
                fourth = true;
            }
            if (!third && time >= 6)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(36, "left");
                third = true;
            }
            if (!second && time >= 7)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(37, "left");
                second = true;
            }
        }
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 5)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 17);
                first = true;
            }
            if (!thirteenth && Character.transform.position.y >= 12)
            {
                Main.GetComponent<mapCreatorLevel1>().AddPipe(30, "left");
                time = 0;
                ok = true;
                thirteenth = true;
            }
        }
    }
}
