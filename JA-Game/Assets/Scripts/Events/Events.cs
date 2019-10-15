using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour {
    public GameObject canvas1, canvas2;
    bool loadingScene = false;
    GameObject LoadingCanvas;

    private void Awake ()
    {
        LoadingCanvas = Resources.Load<GameObject>("Prefabs/Estetics/Loading Canvas");
    }
    public void Login()
    {
        GameObject.Find("FB Holder").GetComponent<FBholder>().FBLogin();
    }
    public void QueryScore()
    {
        GameObject.Find("FB Holder").GetComponent<FBholder>().QueryScores();
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
    public void GoFacebook()
    {
        Application.OpenURL("https://www.facebook.com/BogdanIsThere");
    }
    public void GoGame()
    {
        StartCoroutine(loadScene("Singleplayer"));
    }
    public void GoComicOne()
    {
        StartCoroutine(loadScene("Comic1"));
    }
    public void GoComicTwo()
    {
        StartCoroutine(loadScene("Comic2"));
    }
    public void GoComicThree()
    {
        StartCoroutine(loadScene("Comic3"));
    }
    public void GoComicFour()
    {
        StartCoroutine(loadScene("Comic4"));
    }
    public void GoLevelOne()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level1"));
    }
          
    public void GoLevelTwo()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level2"));
    }
    public void GoLevelThree()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level3"));
    }
    public void GoLevelFour()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level4"));
    }
    public void GoLevelFive()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level5"));
    }
    public void GoLevelSix()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level6"));
    }
    public void GoLevelSeven()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level7"));
    }
    public void GoLevelEight()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level8"));
    }
    public void GoLevelNine()
    {
        PlayerPrefs.SetInt("Background", 1);
        StartCoroutine(loadScene("Level9"));
    }
    public void GoLevelTen()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level10"));
    }
    public void GoLevelEleven()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level11"));
    }
    public void GoLevelTwelve()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level12"));
    }
    public void GoLevelThirteen()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level13"));
    }
    public void GoLevelFourteen()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level14"));
    }
    public void GoLevelFifteen()
    {
        PlayerPrefs.SetInt("Background", 2);
        StartCoroutine(loadScene("Level15"));
    }
    public void GoLevelSixteen()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level16"));
    }
    public void GoLevelSeventeen()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level17"));
    }
    public void GoLevelEighteen()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level18"));
    }
    public void GoLevelNineteen()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level19"));
    }
    public void GoLevelTwenty()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level20"));
    }
    public void GoLevelTwentyOne()
    {
        PlayerPrefs.SetInt("Background", 3);
        StartCoroutine(loadScene("Level21"));
    }

    public void GoMenu()
    {
        Application.LoadLevel("Menu");
    }
    public void GoOptions()
    {
        Application.LoadLevel("Options");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Canvas1()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }
    public void Canvas2()
    {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
    }
    public IEnumerator loadScene(string scene)
    {
        float time = 0;
        if(LoadingCanvas == null)
            LoadingCanvas = Resources.Load<GameObject>("Prefabs/Estetics/Loading Canvas");
        Instantiate(LoadingCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        loadingScene = true;
        AsyncOperation async = Application.LoadLevelAsync(scene);
        while (!async.isDone)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
