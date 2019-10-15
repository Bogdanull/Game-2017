using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool regular = false, reversed = true, first = false, second = false, third = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddPipe(0.7f, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(2, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(8, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(9, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(13, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(14, "left");
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(23, regular, 4);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(21, "right");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(38.7f, "right");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(40, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(46, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(46, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(47, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(60, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 61);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 60;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 65, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 65, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 65, 0));
    }

    void Update()
    {
        if (Character != null)
        {
            if (!first && Character.transform.position.y >= 25)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 36);
                first = true;
            }
            if (!third && Character.transform.position.y >= 29)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 40);
                third = true;
            }
            if (!second && Character.transform.position.y >= 50)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.3f, 61);
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.3f, 61);
                second = true;
            }
        }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
