using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCreatorTutorial : MonoBehaviour
{
    public GameObject Platform, Wall, Saw, Boulder, wallCollider, Wallpaper, leftPipe, rightPipe, Coin;
    public GameObject DeadCanvas, first, second, thrid, fourth, fifth, sixth, hook;
    public int canvas;
    public float time;
    bool SawSpawned = false, PipeSpawned = false;
    public float ScreenWidth, ScreenHeight;
    float squaredim = 1;
    int lastTouches=0;
    float i, lastWallpaper = 0, wallpaperHeight = 9.6f;
    Camera camera;

    void Awake()
    {
        hook = GameObject.Find("Hook");
        canvas = 1;
        Time.timeScale = 0;
        first.SetActive(true);
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ScreenWidth = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        ScreenHeight = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        AddPlatformDown(new Vector3(0, -ScreenHeight, 0));
        i = 1;
        do
        {
            AddPlatformDown(new Vector3(4 * i * squaredim, -ScreenHeight, 0));
            AddPlatformDown(new Vector3(-4 * i * squaredim, -ScreenHeight, 0));
            i++;
        } while (4 * i * squaredim < ScreenWidth);
        i = -ScreenHeight + 2.5f * squaredim;
        AddWall(i);
        AddCollider();
    }

    void Update()
    {
        time += Time.unscaledDeltaTime;
        if (!PipeSpawned && GameObject.Find("Character").transform.position.y > 22)
        {
            AddPipe(30, "left");
            PipeSpawned = true;
        }
        if (!SawSpawned && GameObject.Find("Character").transform.position.y > 10)
        {
            AddSaw(18);
            SawSpawned = true;
        }

        if (first.activeSelf == true && canvas == 1 && Input.touchCount > lastTouches)
        {
            Time.timeScale = 1;
            canvas = 2;
            first.SetActive(false);
        }
        else if (canvas == 2 && Input.touchCount == 0 && second.activeSelf == false)
        {
            Time.timeScale = 0;
            second.SetActive(true);
            time = 0;
        }
        else if (second.activeSelf == true && canvas == 2 && Input.touchCount > lastTouches && time > 2)
        {
            Time.timeScale = 1;
            canvas=3;
            second.SetActive(false);
        }
        else if(canvas == 3 && thrid.activeSelf == false && GameObject.Find("Character").transform.position.y > 14)
        {
            Time.timeScale = 0;
            thrid.SetActive(true);
            time = 0;
        }
        else if (thrid.activeSelf == true && canvas == 3 && Input.touchCount > lastTouches && time > 2)
        {
            Time.timeScale = 1;
            canvas=4;
            thrid.SetActive(false);
        }
        else if (canvas == 4 && fourth.activeSelf == false && GameObject.Find("Character").transform.position.y >26)
        {
            Time.timeScale = 0;
            fourth.SetActive(true);
            time = 0;
        }
        else if (fourth.activeSelf == true && canvas == 4 && Input.touchCount > lastTouches && time > 2)
        {
            Time.timeScale = 1;
            canvas=5;
            fourth.SetActive(false);
        }
        else if (canvas==5 &&  fifth.activeSelf == false && GameObject.Find("Character").transform.position.y > 34)
        {
            Time.timeScale = 0;
            fifth.SetActive(true);
            AddBoulder(GameObject.Find("Character").transform.position.x, 44);
            time = 0;
        }
        else if (fifth.activeSelf == true && canvas == 5 && Input.touchCount > lastTouches && time > 2)
        {
            Time.timeScale = 1;
            canvas=6;
            fifth.SetActive(false);
        }
        else if (canvas == 6 && sixth.activeSelf == false && GameObject.Find("Character").transform.position.y > 50)
        {
            Time.timeScale = 0;
            sixth.SetActive(true);
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }

        else if (camera.transform.position.y + ScreenHeight + 4 * squaredim > i + 2 * squaredim)
        {
            i += 4 * squaredim;
            AddWall(i);
        }
        else if (lastWallpaper < camera.transform.position.y + wallpaperHeight)
        {
            lastWallpaper += wallpaperHeight;
            AddWallpaper(lastWallpaper);
        }
        lastTouches = Input.touchCount;
    }
    void AddWallpaper(float y)
    {
        Vector3 position;
        position.z = Wallpaper.transform.position.z;
        position.y = y;
        position.x = 0;
        Instantiate(Wallpaper, position, Quaternion.identity);
    }
    void AddPlatformDown(Vector3 position)
    {
        Instantiate(Platform, position, Quaternion.identity);
    }
    void AddWall(float y)
    {
        Vector3 position;
        position.z = 0;
        position.y = y;
        position.x = -ScreenWidth;
        Instantiate(Wall, position, Quaternion.identity);
        position.x = ScreenWidth;
        Instantiate(Wall, position, Quaternion.identity);
    }
    void AddCollider()
    {
        Vector3 position;
        position.z = 0;
        position.y = 0;
        position.x = -ScreenWidth - squaredim * 6 / 4;
        Instantiate(wallCollider, position, Quaternion.identity);
        position.x = ScreenWidth + squaredim * 6 / 4;
        Instantiate(wallCollider, position, Quaternion.identity);
    }
    void AddPipe(float y, string side)
    {
        Vector3 position;
        position.z = -1;
        position.y = y;
        if (side == "left")
        {
            position.x = -ScreenWidth + 0.35f;
            Instantiate(leftPipe, position, Quaternion.identity);
        }
        else if (side == "right")
        {
            position.x = ScreenWidth - 0.35f;
            Instantiate(rightPipe, position, Quaternion.identity);
        }
    }
    void AddSaw(float y)
    {
        Vector3 position;
        position.z = Saw.transform.position.z;
        position.y = y;
        position.x = 0;
        GameObject saw;
        saw = Instantiate(Saw, position, Quaternion.identity);
        saw.GetComponentInChildren<sawScript>().moving = true;
        saw.GetComponentInChildren<sawScript>().right = true;
    }
    void AddBoulder(float x, float y)
    {
        Vector3 position;
        position.z = Boulder.transform.position.z;
        position.y = y;
        position.x = x;
        GameObject boulder;
        boulder = Instantiate(Boulder, position, Quaternion.identity);
    }
    void AddCoin(float y)
    {
        Vector3 position;
        position.z = 1;
        position.y = y;
        position.x = 0;
        int a = Random.Range(1, 3);
        if (a == 1)
            position.x = 0;
        if (a == 2)
            position.x = -ScreenWidth / 2;
        if (a == 3)
            position.x = ScreenWidth / 2;
        Instantiate(Coin, position, Quaternion.identity);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        DeadCanvas.SetActive(true);
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void GoGame()
    {
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        Application.LoadLevel("Singleplayer");
    }
}
