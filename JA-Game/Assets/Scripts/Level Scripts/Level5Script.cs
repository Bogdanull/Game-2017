using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Script : MonoBehaviour {

    GameObject Main;
    GameObject Character;
    bool reversed = true, regular = false, first = false, second = false, third = false;
    float time = 0;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc. 
        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(0, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + 0.7f, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + (0.7f) * 2, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + (0.7f) * 3, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + (0.7f) * 4, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + (0.7f) * 5, regular);
        Main.GetComponent<mapCreatorLevel1>().AddMidSlab(0 + (0.7f) * 6, regular);
        Main.GetComponent<mapCreatorLevel1>().AddUpperSlab(0 + (0.7f) * 7, regular);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(24, 0, 0);

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(33, false);
        Main.GetComponent<mapCreatorLevel1>().AddGate(-1.6f, 34);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 33;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 38, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 38, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 38, 0));

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time>1 && !first)
        {
            Main.GetComponent<mapCreatorLevel1>().AddSaw(28, 0, 0);
            first = true;
        }
        if (Character != null)
        {
            if (!second && Character.transform.position.y >= 7)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.4f, 18);
                second = true;
            }
            if (!third && Character.transform.position.y >= 12)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.4f, 23);
                third = true;
            }
        }
        //Aici adaugi comenzi speciale, desi probabil nu o sa fie mare nevoie. Ask Bogdan First
    }
}
