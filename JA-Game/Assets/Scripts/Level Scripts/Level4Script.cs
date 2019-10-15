using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool first = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(0, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(4, "right");
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(18, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 19);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 18;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 23, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 23, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 23, 0));
    }

    void Update()
    {
        if (Character != null && !first && Character.transform.position.y >= 7)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 18);
            first = true;
        }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
