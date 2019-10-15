using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Script : MonoBehaviour
{

    GameObject Main;
    GameObject Character;
    bool regular = false, reversed = true, first = false, second = false;
    void Start()
    {
        Main = GameObject.Find("GM");
        Character = GameObject.Find("Character");
        //GameObject.Find("Main Camera").GetComponent<CameraController>().start = true; //porneste camera
        //Gaseste scriptul de creare
        //Comenzi disponibilie, accesabile cu GetComponent<MapCreatorLevel1> :
        //AddSaw, AddPlatform, AddSidePlatform, AddPipe, AddBoulder, etc.
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(2, "right");
        Main.GetComponent<mapCreatorLevel1>().AddSidePlatform(6, "left");
        Main.GetComponent<mapCreatorLevel1>().AddPipe(8, "left");

        Main.GetComponent<mapCreatorLevel1>().AddGenerator(17, regular, 4);
        Main.GetComponent<mapCreatorLevel1>().AddGenerator(23, reversed, 4);

        Main.GetComponent<mapCreatorLevel1>().AddSaw(28, 0, 0);
        Main.GetComponent<mapCreatorLevel1>().AddPipe(29, "right");

        Main.GetComponent<mapCreatorLevel1>().AddLowerSlab(34, true);
        Main.GetComponent<mapCreatorLevel1>().AddGate(1.6f, 35);
        GameObject.Find("Main Camera").GetComponent<CameraController>().maximPos = 34;
        GameObject.Find("Main Camera").GetComponent<CameraController>().maxExist = true;
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(0, 39, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(3, 39, 0));
        Main.GetComponent<mapCreatorLevel1>().AddPlatformDown(new Vector3(-3, 39, 0));
    }

    void Update()
    {
        if (Character != null)
        {

            if (!first && Character.transform.position.y >= 10)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(Main.GetComponent<mapCreatorLevel1>().ScreenWidth - 1.6f, 21);
                first = true;
            }
            if (!second && Character.transform.position.y >= 17)
            {
                Main.GetComponent<mapCreatorLevel1>().AddBoulder(-Main.GetComponent<mapCreatorLevel1>().ScreenWidth + 1.6f, 28);
                second = true;
            }
        }
    }
}
