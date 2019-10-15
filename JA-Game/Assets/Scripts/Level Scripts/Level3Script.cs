using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        //Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(6, "right");
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(7, reversed, 6);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(9, regular, 6);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(9, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 10);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 9;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 14, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 14, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 14, 0));

    }

    void Update()
    {
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
