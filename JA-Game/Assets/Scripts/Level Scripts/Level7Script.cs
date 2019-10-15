using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu Main.GetComponent<MapCreatorLevel1>().
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        //Main.GetComponent<mapCreatorLevel1>().AddSpeed(4, Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 2);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(6,0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(7, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(8, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddSaw(9, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddPipe(23, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(24, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(25, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(26, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(27, "left");

        Main.GetComponent<mapCreatorLevel1>().AddSaw(43, -Main.GetComponent<mapCreatorLevel1>().ScreenWidth, Main.GetComponent<mapCreatorLevel1>().ScreenWidth);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(43 - 1.4f, true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43 - 0.7f, true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43, true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43 + 0.7f, true);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(43 + 1.4f, true);
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(43 - 1.4f, !true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43 - 0.7f, !true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43, !true);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(43 + 0.7f, !true);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(43 + 1.4f, !true);


        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(52, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 53);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 52;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 57, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 57, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 57, 0));

    }

    void Update()
    {
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
