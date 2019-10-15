using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapCreator : MonoBehaviour {
    //Ints : Highscore
	// Use this for initialization
	public GameObject Platform, SidePlatform, DownPlatform, Wall, Saw, Boulder, Generator, Electricity, wallCollider, Wallpaper1, Wallpaper2, Wallpaper3, TransWallpaper, TransWallpaperBeep, SecondWallpaper, Wallpaper4, leftPipe, rightPipe, upperSlab, midSlab, lowerSlab, HighscoreLine, PJetpack, PSpeed, PSlow;
    public int wallsForPower;
    Coroutine x;
    public float ScreenWidth, ScreenHeight;
    float chanceJetpack=33, chanceSlow=33, chanceSpeed=33;
    float squaredim=1;
    int backgroundToSpawn;
    public int wallsTillPower;
    int lastSpawned;
    float i, lastWallpaper = -9.6f, wallpaperHeight = 9.6f;
    Camera camera;
    //generare
    public float lastPos, lengthToSpawn, distDifficulty;
    bool wasPlatfom, wasSaw;
    public Text Score, EndScore;
    public GameObject deadScreen;
    public GameObject pauseScreen;
    public GameObject gameCanvas;
    public GameObject HighscoreLineFB;
    public GameObject sewageParticles, blueParticles;
    

    void Awake () {
        backgroundToSpawn = PlayerPrefs.GetInt("Background");
        if (backgroundToSpawn == 1)
        {
            Wall = Resources.Load("Prefabs/Level/Wall") as GameObject;
            DownPlatform = Resources.Load("Prefabs/Level/PlatformDown") as GameObject;
        }
        else if (backgroundToSpawn == 2)
        {
            Wall = Resources.Load("Prefabs/Level/TransWall") as GameObject;
            DownPlatform = Resources.Load("Prefabs/Level/PlatformDown trans") as GameObject;
            if (PlayerPrefs.GetInt("Particles") == 1)
            {
                GameObject x = Instantiate(sewageParticles);
                x.transform.SetParent(GameObject.Find("Main Camera").transform);
            }
        }
        else if (backgroundToSpawn == 3)
        {
            Wall = Resources.Load("Prefabs/Level/Wall2") as GameObject;
            DownPlatform = Resources.Load("Prefabs/Level/PlatformDown 2") as GameObject;
            if (PlayerPrefs.GetInt("Particles") == 1)
            {
                GameObject x = Instantiate(blueParticles);
                x.transform.SetParent(GameObject.Find("Main Camera").transform);
            }
        }
        else
        {
            backgroundToSpawn = 1;
            PlayerPrefs.SetInt("Background", 1);
        }
        wallsTillPower = wallsForPower;
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
        } while (4 * i * squaredim  < ScreenWidth );
        i = -ScreenHeight + 2.5f * squaredim;
        AddWall(i);
        AddCollider();
        float highscore = PlayerPrefs.GetFloat("Highscore");
        if (highscore > 10)
        {
            HighscoreLine = Instantiate(HighscoreLine, new Vector3(0, 0, 10), Quaternion.identity);
            HighscoreLine.GetComponentInChildren<TextMesh>().text += highscore.ToString();
            HighscoreLine.transform.position = new Vector3(0, highscore / 1000 - 2.5f, 10);
        }
        if(GameObject.Find("FB Holder")!=null)
        {
            setHighscores(GameObject.Find("FB Holder").GetComponent<FBholder>().PlayersScores,
                          GameObject.Find("FB Holder").GetComponent<FBholder>().PlayersNames);
        }
    }
	void Update () {
		if(camera.transform.position.y + ScreenHeight + 4 * squaredim > i + 2 * squaredim)
        {
            i += 4 * squaredim;
            wallsTillPower--;
            if (wallsTillPower <= 0)
            {
                wallsTillPower = wallsForPower;
                AddPower(i);
            }
            AddWall(i);
        }
        if(lastPos - lengthToSpawn < camera.transform.position.y)
        {
            Spawn(lastPos);
        }
        if(lastWallpaper < camera.transform.position.y + wallpaperHeight)
        {
            lastWallpaper += wallpaperHeight;
            AddWallpaper(lastWallpaper);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("Character").GetComponent<Controller>().isDead)
            Pause();
        Score.text = Mathf.FloorToInt(camera.transform.position.y*1000).ToString();
    }
    void AddWallpaper(float y){
        Vector3 position;
        float a = Random.Range(0, 100);
        position.z = Wallpaper1.transform.position.z;
        position.y = y;
        position.x = 0;
        if (backgroundToSpawn == 1)
        {
            if (a < 10) Instantiate(Wallpaper2, position, Quaternion.identity);
            else if (a < 20) Instantiate(Wallpaper3, position, Quaternion.identity);
            else if (a < 30) Instantiate(Wallpaper4, position, Quaternion.identity);
            else Instantiate(Wallpaper1, position, Quaternion.identity);
        }
        else if(backgroundToSpawn == 2)
        {
            if (a < 25) Instantiate(TransWallpaperBeep, position, Quaternion.identity);
            else Instantiate(TransWallpaper, position, Quaternion.identity);
        }
        else if(backgroundToSpawn == 3)
        {
            Instantiate(SecondWallpaper, position, Quaternion.identity);
        }
    }
	void AddPlatformDown(Vector3 position){
         Instantiate(DownPlatform, position, Quaternion.identity);
    }
    void AddWall(float y) {
        Vector3 position;
        position.z = 0;
        position.y = y;
        position.x = -ScreenWidth;
        Instantiate(Wall, position, Quaternion.identity);
        position.x = ScreenWidth;
        GameObject x;
        x = Instantiate(Wall, position, Quaternion.identity);
        foreach (SpriteRenderer a in x.GetComponentsInChildren<SpriteRenderer>())
        {
            a.flipX = true;
        }
    }
    void AddCollider()
    {
        Vector3 position;
        position.z = 0;
        position.y = 0;
        position.x = -ScreenWidth - squaredim * 6/4;
        Instantiate(wallCollider, position, Quaternion.identity);
        position.x = ScreenWidth + squaredim * 6/4;
        Instantiate(wallCollider, position, Quaternion.identity);
    }
    void AddPipe(float y, bool reversed)
    {
        Vector3 position;
        position.z = -1;
        position.y = y;
        if (!reversed)
        {
            position.x = -ScreenWidth + 0.35f;
            Instantiate(leftPipe, position, Quaternion.identity);
        }
        else if (reversed)
        {
            position.x = ScreenWidth - 0.35f;
            Instantiate(rightPipe, position, Quaternion.identity);
        }
    }
    void AddGenerator(float y, bool reversed, int times)
    {
        float x = -ScreenWidth + 0.6f;
        if (reversed) x = -x;
        GameObject a = Instantiate(Generator, new Vector3(x, y, -1), Quaternion.identity);
        if (reversed) a.transform.localScale = new Vector3(-a.transform.localScale.x, 1, 1);
        y = y - 1;
        for(int i=1; i<=times; i++)
        {
            Instantiate(Electricity, new Vector3(x, y, 1), Quaternion.identity);
            y -= 1.25f;
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
        if (Random.value > 0.5f)
            boulder = Instantiate(Boulder, position, Quaternion.identity);
        else boulder = Instantiate(Boulder, new Vector3(GameObject.Find("Character").transform.position.x, position.y, position.z), Quaternion.identity);
    }
    void AddPlatform (float y)
    {
        Vector3 position;
        position.z = Platform.transform.position.z;
        position.y = y;
        position.x = 0;
        Instantiate(Platform, position, Quaternion.identity);
    }
    void AddSidePlatform(float y, string side)
    {
        Vector3 position;
        position.z = Platform.transform.position.z;
        position.y = y;
        position.x = 0;
        if (side == "left")
        position.x = -ScreenWidth + 1.2f;
        if (side == "right")
            position.x = ScreenWidth - 1.2f;
		GameObject x = Instantiate(SidePlatform, position, Quaternion.identity);
        if (side == "right")
            x.GetComponent<SpriteRenderer>().flipX = true;
    }
    void AddPower(float y)
    {
        Vector3 position;
        position.z = 1;
        position.y = y;
        position.x = 0;
        int a = Random.Range(1, 3);
        if (a == 1)
            position.x = 0;
        if (a == 2)
            position.x = -ScreenWidth/2;
        if (a == 3)
            position.x = ScreenWidth/2;
        float
        b = Random.Range(1, 99f);
        if (b <= chanceSlow)
        {
            Instantiate(PSlow, position, Quaternion.identity);
            chanceSlow -= 10;
            chanceJetpack += 5;
            chanceSpeed += 5;
        }
        else if (b <= chanceSlow + chanceSpeed)
        {
            Instantiate(PSpeed, position, Quaternion.identity);
            chanceSlow += 5;
            chanceJetpack += 5;
            chanceSpeed -= 10;
        }
        else if (b <= chanceJetpack + chanceSlow + chanceJetpack)
        {
            Instantiate(PJetpack, position, Quaternion.identity);
            chanceSlow += 5;
            chanceJetpack -= 10;
            chanceSpeed += 5;
        }
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
    public void EndGame()
    {
        gameCanvas.SetActive(false);
        float highscore = PlayerPrefs.GetFloat("Highscore");
        deadScreen.SetActive(true);
        if (highscore < Mathf.FloorToInt(camera.transform.position.y * 1000))
        {
            PlayerPrefs.SetFloat("Highscore", (Mathf.FloorToInt(camera.transform.position.y * 1000)));
            highscore = Mathf.FloorToInt(camera.transform.position.y * 1000);
        }
        EndScore.text = "Your Score: " + (Mathf.FloorToInt(camera.transform.position.y * 1000)) + "\nHighscore: " + highscore;
        if(GameObject.Find("FB Holder")!=null)
        GameObject.Find("FB Holder").GetComponent<FBholder>().setHighscore(Mathf.CeilToInt(highscore));
        Destroy(GameObject.Find("Main Camera").GetComponent<CameraController>());
    }
    public void setHighscores(List<int> scores, List<string> names)
    {
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] != PlayerPrefs.GetFloat("Highscore"))
            {
                GameObject x;
                x = Instantiate(HighscoreLineFB, new Vector3(0, (scores[i] / 1000 - 2.5f), 10), Quaternion.identity);
                x.transform.GetChild(0).GetComponent<TextMesh>().text = (names[i]);
            }
        }
    }
    public void Spawn(float i)
    {
        int chances = Mathf.Min((1 + Mathf.FloorToInt(i / distDifficulty))*10, 50) ;
        int thingToSpawn = Random.Range(1, chances);
        while (thingToSpawn==lastSpawned || 
            (wasPlatfom && (thingToSpawn == 7 || thingToSpawn == 8 || thingToSpawn == 13 || thingToSpawn == 14 || thingToSpawn == 15 || thingToSpawn == 22 || thingToSpawn == 26 || thingToSpawn == 31 || thingToSpawn == 39 || thingToSpawn == 40 || thingToSpawn == 41))||
            (wasSaw && (thingToSpawn == 5 || thingToSpawn == 10 || thingToSpawn == 25 || thingToSpawn == 29 || thingToSpawn == 30 || thingToSpawn == 33 || thingToSpawn == 38 || thingToSpawn == 45 || thingToSpawn == 46 || thingToSpawn == 48))) 
            thingToSpawn = Random.Range(1, chances);
        lastSpawned = thingToSpawn;
        wasPlatfom = false;
        wasSaw = false;
        if (thingToSpawn <= 3) lastPos += 3;
        else if (thingToSpawn == 4)
        {
            int x = Random.Range(1, 4);
            i += x * 1.4f + 1;
            AddGenerator(i, Random.value > 0.5f, x);
            lastPos = i + 3;
        }
        else if (thingToSpawn == 5)
        {
            wasSaw = true;
            AddSaw(i);
            lastPos += 3;
        }
        else if (thingToSpawn == 6)
        {
            AddPipe(i, Random.value > 0.5f);
            lastPos += 3;
        }
        else if (thingToSpawn == 7)
        {
            wasPlatfom = true;
            AddSidePlatform(i, "left");
            lastPos += 3;
        }
        else if (thingToSpawn == 8)
        {
            AddSidePlatform(i, "right");
            lastPos += 3;
        }
        else if (thingToSpawn == 9)
        {
            AddPipe(i, Random.value > 0.5f);
            lastPos += 3;
        }
        else if (thingToSpawn == 10)
        {
            wasSaw = true;
            AddSaw(i);
            lastPos += 3;
        }
        else if (thingToSpawn <= 12)
        {
            lastPos += 4;
        }
        else if (thingToSpawn == 13)
        {
            wasPlatfom = true;
            AddSidePlatform(i, "left");
            AddSidePlatform(i, "right");
            lastPos += 4;
        }
        else if (thingToSpawn == 14)
        {
            AddSidePlatform(i, "left");
            lastPos += 2;
        }
        else if (thingToSpawn == 15)
        {
            wasPlatfom = true;
            AddSidePlatform(i, "right");
            lastPos += 2;
        }
        else if (thingToSpawn == 16)
        {
            int x = Random.Range(1, 4);
            i += x * 1.4f + 1;
            AddGenerator(i, Random.value > 0.5f, x);
            lastPos = i + 2;
        }
        else if (thingToSpawn == 17)
        {
            int x = Random.Range(1, 4);
            i += x * 1.4f + 1;
            AddGenerator(i, Random.value > 0.5f, x);
            lastPos = i + 2;
        }
        else if (thingToSpawn == 18)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 19)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 20)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 21) lastPos += 5;
        else if (thingToSpawn == 22)
        {
            wasPlatfom = true;
            AddSidePlatform(i, "left");
            AddSidePlatform(i, "right");
            lastPos += 3;
        }
        else if (thingToSpawn == 23)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 24)
        {
            AddPipe(i, Random.value > 0.5f);
            lastPos += 2;
        }
        else if (thingToSpawn == 25)
        {
            wasSaw = true;
            AddSaw(i);
            lastPos += 3;
        }
        else if (thingToSpawn == 26)
        {
            wasPlatfom = true;
            if (Random.value > 0.5f)
            {
                AddSidePlatform(i, "left");
                i += 2;
                AddSidePlatform(i, "right");
            }
            else
            {
                AddSidePlatform(i, "right");
                i += 2;
                AddSidePlatform(i, "left");
            }

            lastPos += 4;
        }
        else if (thingToSpawn == 27)
        {
            AddPipe(i, Random.value > 0.5f);
            AddPipe(i + 1, Random.value < 0.5f);
            lastPos += 4;
        }
        else if (thingToSpawn == 28)
        {
            AddPipe(i, Random.value > 0.5f);
            AddPipe(i + 1, Random.value < 0.5f);
            lastPos += 4;
        }
        else if (thingToSpawn == 29)
        {
            wasSaw = true;
            AddSaw(i);
            AddSaw(i + 1.5f);
            lastPos += 6;
        }
        else if (thingToSpawn == 30)
        {
            wasSaw = true;
            AddSaw(i);
            AddSaw(i + 1.5f);
            lastPos += 6;
        }
        else if (thingToSpawn == 31)
        {
            wasPlatfom = true;
            if (Random.value > 0.5f)
            {
                AddSidePlatform(i, "left");
                i += 2;
                AddSidePlatform(i, "right");
            }
            else
            {
                AddSidePlatform(i, "right");
                i += 2;
                AddSidePlatform(i, "left");
            }

            lastPos += 4;
        }
        else if (thingToSpawn == 32)
        {
            AddPipe(i, Random.value > 0.5f);
            lastPos += 3;
        }
        else if (thingToSpawn == 33)
        {
            wasSaw = true;
            AddSaw(i);
            lastPos += 3;
        }
        else if (thingToSpawn == 34)
        {
            int x = Random.Range(1, 4);
            i += x * 1.4f + 1;
            AddGenerator(i, true, x);
            AddGenerator(i + 1, false, x);
            lastPos = i + 3;
        }
        else if (thingToSpawn == 35)
        {
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
                AddPipe(i + 2.8f, false);
            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 0.7f, !true);
                AddMidSlab(i + 1.4f, !true);
                AddUpperSlab(i + 2.1f, !true);
                AddPipe(i + 2.8f, !false);
            }
            lastPos += 5;
        }
        else if (thingToSpawn == 36)
        {
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
                AddPipe(i + 2.8f, false);
            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1 * 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);
                AddPipe(i + 2.8f, !false);
            }
            lastPos += 5;
        }
        else if (thingToSpawn == 37)
        {
            AddPipe(i, Random.value > 0.5f);
            AddPipe(i + 1, Random.value < 0.5f);
            lastPos += 4;
        }
        else if (thingToSpawn == 38)
        {
            wasSaw = true;
            AddSaw(i);
            AddSaw(i + 1.5f);
            lastPos += 6;
        }
        else if (thingToSpawn == 39)
        {
            wasPlatfom = true;
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1 * 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);

            }
            lastPos += 5f;
        }
        else if(thingToSpawn == 40)
        {
            wasPlatfom = true;
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1 * 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);

            }
            lastPos += 5f;
        }
        else if (thingToSpawn == 41)
        {
            wasPlatfom = true;
            if (Random.value > 0.5f)
            {
                AddSidePlatform(i, "left");
                i += 2;
                AddSidePlatform(i, "right");
            }
            else
            {
                AddSidePlatform(i, "right");
                i += 2;
                AddSidePlatform(i, "left");
            }

            lastPos += 4;
        }
        else if (thingToSpawn == 42)
        {
            int x = Random.Range(1, 4);
            i += x * 1.4f + 1;
            AddGenerator(i, true, x);
            AddGenerator(i + 1, false, x);
            lastPos = i + 3;
        }
        else if (thingToSpawn == 43)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 34)
        {
            AddBoulder(Random.Range(-ScreenWidth + 1, ScreenWidth - 1), i + 10);
            lastPos += 3;
        }
        else if (thingToSpawn == 45)
        {
            wasSaw = true;

            {
                if (Random.value > 0.5f)
                {
                    AddLowerSlab(i, true);
                    AddMidSlab(i + 1 * 0.7f, true);
                    AddMidSlab(i + 2 * 0.7f, true);
                    AddUpperSlab(i + 3 * 0.7f, true);
                }
                else
                {
                    AddLowerSlab(i, !true);
                    AddMidSlab(i + 1 * 0.7f, !true);
                    AddMidSlab(i + 2 * 0.7f, !true);
                    AddUpperSlab(i + 3 * 0.7f, !true);
                }
                AddSaw(i + 1.7f);
                lastPos += 5;
            }
        }
        else if (thingToSpawn == 46)
        {
            wasSaw = true;
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1 * 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);
            }
            AddSaw(i + 1.7f);
            lastPos += 5;
        }
        else if (thingToSpawn == 47)
        {
            AddPipe(i, Random.value > 0.5f);
            AddPipe(i + 1, Random.value < 0.5f);
            AddPipe(i + 2, Random.value > 0.5f);
            lastPos += 5;
        }
        else if (thingToSpawn == 48)
        {
            wasSaw = true;
            AddSaw(i);
            AddSaw(i + 1.5f);
            AddSaw(i + 3f);
            lastPos += 8;
        }
        else if (thingToSpawn == 49)
        {
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
                AddGenerator(i + 3 * 0.7f, false, 3);

            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1* 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);
                AddGenerator(i + 3 * 0.7f, !false, 3);
            }
            lastPos += 5f;
        }
        else if (thingToSpawn == 50)
        {
            if (Random.value > 0.5f)
            {
                AddLowerSlab(i, true);
                AddMidSlab(i + 1 * 0.7f, true);
                AddMidSlab(i + 2 * 0.7f, true);
                AddUpperSlab(i + 3 * 0.7f, true);
                AddGenerator(i + 2.1f, false, 3);

            }
            else
            {
                AddLowerSlab(i, !true);
                AddMidSlab(i + 1 * 0.7f, !true);
                AddMidSlab(i + 2 * 0.7f, !true);
                AddUpperSlab(i + 3 * 0.7f, !true);
                AddGenerator(i + 2.1f, !false, 3);
            }
            lastPos += 5f;
        }

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
        if (deadScreen.activeSelf == false && GameObject.Find("Tutorial Canvas")==null)
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
