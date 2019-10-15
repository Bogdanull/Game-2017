using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool regular = false, reversed = true, first = false, second = false, third = false, fourth = false, fifth = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddPipe(4, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(5, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(16, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(19, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(24);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(25);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(26);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(27);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(39, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(40, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(40, "right");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(42, "left");

        Quaternion a = new Quaternion();
        a.SetEulerAngles(new Vector3(0, 0, Mathf.PI / 2));
        foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
        {
            if (something.name.StartsWith("Platform 1"))
                something.transform.rotation = a;
        }

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(51, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 52);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 51;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 56, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 56, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 56, 0));
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.5f && !first)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(11, 0, 0);
            first = true;
        }
        if (time >= 0f && !second)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(12.5f, 0, 0);
            second = true;
        }
        if (Character != null)
        {
            if (!third && Character.transform.position.y >= 0)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(0, 11);
                third = true;
            }
            if (!fourth && Character.transform.position.y >= 27)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 39);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 39);
                fourth = true;
            }
            if (!fifth && Character.transform.position.y >= 45)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 56);
                fifth = true;
            }
        }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
