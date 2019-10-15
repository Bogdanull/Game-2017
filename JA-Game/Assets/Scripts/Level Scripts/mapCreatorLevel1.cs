using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapCreatorLevel1 : MonoBehaviour
{
    //Ints : Highscore
    // Use this for initialization
    public GameObject Platform, SidePlatform, DownPlatform, Wall,
                      Saw, Boulder, wallCollider, Wallpaper1, Wallpaper2, Wallpaper3, Wallpaper4,
                      Generator, Electricity,
                      leftPipe, rightPipe, Coin, Gate,
                      upperSlab, midSlab, lowerSlab, Speed, Slow, Jetpack;
    public float ScreenWidth, ScreenHeight;
    Coroutine x;
    float squaredim = 1;
    float i, lastWallpaper = 0, wallpaperHeight = 9.6f;
    Camera camera;
    public GameObject deadScreen;
    public GameObject pauseScreen;
    public GameObject gameCanvas;
    public GameObject endCanvas;


    void Awake()
    {
        if (PlayerPrefs.GetInt("Particles") == 0)
        {
            if (PlayerPrefs.GetInt("Background") == 2)
            {
                Destroy(GameObject.Find("Sewer Particles Falling"));
            }
            if (PlayerPrefs.GetInt("Background") == 3)
            {
                Destroy(GameObject.Find("Blue Particles Falling"));
            }
        }
        deadScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
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
        if (camera.transform.position.y + ScreenHeight + 4 * squaredim > i + 2 * squaredim)
        {
            i += 4 * squaredim;
            AddWall(i);
        }
        if (lastWallpaper < camera.transform.position.y + wallpaperHeight)
        {
            lastWallpaper += wallpaperHeight;
            AddWallpaper(lastWallpaper);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("Character").GetComponent<Controller>().isDead)
            Pause();
    }
    public void AddUpperSlab(float y, bool reversed)
    {
        float x = -ScreenWidth + 1.35f;
        if (reversed) x = -x;
        GameObject a = Instantiate(upperSlab, new Vector3(x, y, 0), Quaternion.identity);
        if (reversed) a.transform.localScale = new Vector3(-1, 1, 1);
    }
    public void AddMidSlab(float y, bool reversed)
    {
        float x = -ScreenWidth + 1.35f;
        if (reversed) x = -x;
        GameObject a = Instantiate(midSlab, new Vector3(x, y, 0), Quaternion.identity);
        if (reversed) a.transform.localScale = new Vector3(-1, 1, 1);
    }
    public void AddLowerSlab(float y, bool reversed)
    {
        float x = -ScreenWidth + 1.35f;
        if (reversed) x = -x;
        GameObject a = Instantiate(lowerSlab, new Vector3(x, y, 0), Quaternion.identity);
        if (reversed) a.transform.localScale = new Vector3(-1, 1, 1);
    }
    public void AddGenerator(float y, bool reversed, int times)
    {
        float x = -ScreenWidth + 0.6f;
        if (reversed) x = -x;
        GameObject a = Instantiate(Generator, new Vector3(x, y, -1), Quaternion.identity);
        if (reversed) a.transform.localScale = new Vector3(-a.transform.localScale.x, 1, 1);
        y = y - 1;
        for (int i = 1; i <= times; i++)
        {
            Instantiate(Electricity, new Vector3(x, y, 1), Quaternion.identity);
            y -= 1.25f;
        }
    }
    void AddWallpaper(float y)
    {
        Vector3 position;
        float a = Random.Range(0, 100);
        position.z = Wallpaper1.transform.position.z;
        position.y = y;
        position.x = 0;
        if (a < 5) Instantiate(Wallpaper2, position, Quaternion.identity);
        else if (a < 10) Instantiate(Wallpaper3, position, Quaternion.identity);
        else if (a < 15) Instantiate(Wallpaper4, position, Quaternion.identity);
        else Instantiate(Wallpaper1, position, Quaternion.identity);
    }
    public void AddPlatformDown(Vector3 position)
    {
        Instantiate(DownPlatform, position, Quaternion.identity);
    }
    public void AddGate(float x, float y)
    {
        Vector3 position;
        position.z = Gate.transform.position.z;
        position.x = x;
        position.y = y;
        Instantiate(Gate, position, Quaternion.identity);
    }
    public void AddWall(float y)
    {
        Vector3 position;
        position.z = 0;
        position.y = y;
        position.x = -ScreenWidth;
        Instantiate(Wall, position, Quaternion.identity);
        position.x = ScreenWidth;
        GameObject x;
        x = Instantiate(Wall, position, Quaternion.identity);
        foreach (SpriteRenderer a in x.GetComponentsInChildren<SpriteRenderer>()){
            a.flipX = true;
        }
    }
    public void AddCollider()
    {
        Vector3 position;
        position.z = 0;
        position.y = 0;
        position.x = -ScreenWidth - squaredim * 6 / 4;
        Instantiate(wallCollider, position, Quaternion.identity);
        position.x = ScreenWidth + squaredim * 6 / 4;
        Instantiate(wallCollider, position, Quaternion.identity);
    }
    public void AddPlatform(float y)
    {
        Vector3 position;
        position.z = Platform.transform.position.z;
        position.y = y;
        position.x = 0;
        Instantiate(Platform, position, Quaternion.identity);
    }
    public void AddSidePlatform(float y, string side)
    {
        Vector3 position;
        position.z = SidePlatform.transform.position.z;
        position.y = y;
        position.x = 0;
        if (side == "left")
            position.x = -ScreenHeight + 3.3f;
        if (side == "right")
            position.x = ScreenHeight - 3.3f;
        GameObject x = Instantiate(SidePlatform, position, Quaternion.identity);
        if (side == "right")
            x.GetComponent<SpriteRenderer>().flipX = true;
    }
    public void AddPipe(float y, string side)
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
    public void AddSaw(float y, float left, float right)
    {
        Vector3 position;
        position.z = Saw.transform.position.z;
        position.y = y;
        position.x = 0;
        GameObject saw;
        saw = Instantiate(Saw, position, Quaternion.identity);
        saw.GetComponentInChildren<sawScript>().moving = true;
        saw.GetComponentInChildren<sawScript>().right = true;
        if (left != right)
        {
            saw.GetComponentInChildren<sawScript>().leftSide = left;
            saw.GetComponentInChildren<sawScript>().rightSide = right;
        }
    }
    public void AddBoulder(float x, float y)
    {
        Vector3 position;
        position.z = Boulder.transform.position.z;
        position.y = y;
        position.x = x;
        GameObject boulder;
        boulder = Instantiate(Boulder, position, Quaternion.identity);
    }
    public void AddCoin(float y)
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
    public void AddSpeed(float y, float x)
    {
        Vector3 position;
        position.z = 1;
        position.y = y;
        position.x = x;
        Instantiate(Speed, position, Quaternion.identity);
    }
    public void AddSlow(float y, float x)
    {
        Vector3 position;
        position.z = 1;
        position.y = y;
        position.x = x;
        Instantiate(Slow, position, Quaternion.identity);
    }

    public void EndGame()
    {
        if (endCanvas.activeSelf == false)
        {
            gameCanvas.SetActive(false);
            deadScreen.SetActive(true);
        }
    }
    public void Win()
    {
        gameCanvas.SetActive(false);
        endCanvas.SetActive(true);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause && deadScreen.activeSelf == false)
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (deadScreen.activeSelf == false)
        {
            if (x != null)
                StopCoroutine(x);
            GameObject.Find("Countdown").GetComponent<CountdownScript>().stopCount();
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }
    public void StartGame()
    {
        x = StartCoroutine(WaitToStart());
    }
    public IEnumerator WaitToStart()
    {
        GameObject.Find("Countdown").GetComponent<CountdownScript>().startCount(2);
        pauseScreen.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }
}
