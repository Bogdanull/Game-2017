using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu Main.GetComponent<MapCreatorLevel1>().
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(3, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(5, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(7, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(10, "right");
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(17, reversed, 5);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(17, regular, 3);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(20, "left");
        Main.GetComponent<mapCreatorLevel1>().AddSaw(22, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(29);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(32, regular, 5);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(32, reversed, 5);
        Main.GetComponent<mapCreatorLevel1>().AddPlatform(38);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(41, regular, 5);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(41, reversed, 5);
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(45, "left");
        Main.GetComponent<mapCreatorLevel1>().AddGate(-1.4f, 46f);
        Quaternion a = new Quaternion();
        a.SetEulerAngles(new Vector3(0, 0, Mathf.PI/2));
        foreach (var something in GameObject.FindGameObjectsWithTag("wall"))
        {
            if(something.name.StartsWith("Platform 1"))
            something.transform.rotation = a;
        }
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 44;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 49, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 49, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 49, 0));

    }

    void Update()
    {
       if (!first && Character!=null && Character.transform.position.y >= 16)
        {
            Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.5f, 25);
            first = true;
        }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
