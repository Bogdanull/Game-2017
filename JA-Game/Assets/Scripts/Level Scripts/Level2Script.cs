using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool reversed = true;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddPipe(3, "left");
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(10, true);
        //Main.GetComponent<mapCreatorLevel1>().AddMidSlab(6, reversed);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 11);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 10;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 15, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 15, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 15, 0));
    }

    void Update()
    {
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
