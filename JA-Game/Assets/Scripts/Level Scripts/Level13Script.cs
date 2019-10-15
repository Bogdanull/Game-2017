using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level13Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false, fourth = false, fifth = false, sixth = false, seventh = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true;
        //Main.GetComponent<mapCreatorLevel1>().
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(0, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(1.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(2.4f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(3.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(4.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(4.8f, regular);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(10, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(10.7f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(11.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(12.4f, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(13.4f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(14.1f, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(14.8f, reversed);

        Main.GetComponent<mapCreatorLevel1>().AddPipe(18, "left");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(48, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(48.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(49.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(50.1f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(50.8f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(51.3f, regular);
        /*Main.GetComponent<mapCreatorLevel1>().AddMidSlab(52, regular);
        /*Main.GetComponent<mapCreatorLevel1>().AddMidSlab(53.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(54.4f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(55.1f, regular);*/
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(52, regular);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(60, regular);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 61);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 60;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 65, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 65, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 65, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Character != null)
        {
            if (Character.transform.position.y >= 21 && !first)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 32);
                first = true;
            }
            if (Character.transform.position.y >= 24 && !second)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 35);
                second = true;
            }
            if (Character.transform.position.y >= 27 && !third)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 38);
                third = true;
            }
            if (Character.transform.position.y >= 49 && !seventh)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 60);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 60);
                seventh = true;
            }
        }
        if (time >= 1 && !fourth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(36, 0, 0);
            fourth = true;
        }
        if (time >= 1.3f && !fifth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(37.5f, 0, 0);
            fifth = true;
        }
        if (time >= 1.6f && !sixth)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(39, 0, 0);
            sixth = true;
        }
    }
}
