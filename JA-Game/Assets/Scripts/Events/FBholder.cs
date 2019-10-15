using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FBholder : MonoBehaviour {
    public GameObject LoggedInDialog, LoggedOutDialog;
    public string username;
    public Sprite ProfilePicture;
    public GameObject ScoreEntryPanel;
    public GameObject ScrollScoreList;
    public GameObject ScrollContent;
    private List<object> scoresList = null;
    bool initialised, permit = false;
    public List<int> PlayersScores;
    public List<string> PlayersNames;
    private void OnLevelWasLoaded(int level)
    {
        if (Application.loadedLevelName == "Menu")
        {
            initialised = true;
            LoggedInDialog = GameObject.Find("FacebookLogged");
            LoggedOutDialog = GameObject.Find("FacebookNotLogged");
            ScoreEntryPanel = Resources.Load<GameObject>("Prefabs/Estetics/ScoreEntryPanel");
            FB.Init(SetInit, onHideUnity);
            setButtons(FB.IsLoggedIn);
        }
    }

    void Awake () {
        DontDestroyOnLoad(gameObject);
	}
    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("logged in");
        }
        else
        {
            Debug.Log("not logged in");
        }
        setButtons(FB.IsLoggedIn);
    }
    void onHideUnity(bool isGameShown)
    {
        if (!isGameShown)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void FBLogin()
    {
        List<string> Permissions = new List<string>();
        Permissions.Add("public_profile");
        Permissions.Add("user_friends");
        FB.LogInWithReadPermissions(Permissions, AuthCallBack);
        PlayerPrefs.SetInt("Logged", 1);
    }
    public void FBLogout()
    {
        FB.LogOut();
        username = null;
        ProfilePicture = null;
    }
    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("logged in");
            }
            else
            {
                Debug.Log("not logged in");
            }
            setButtons(FB.IsLoggedIn);
        }
    }
    void setButtons(bool isLogged)
    {
        if (isLogged)
        {
            LoggedOutDialog.SetActive(false);
            FB.API("/me?fields=first_name", HttpMethod.GET, returnUsername);
            FB.API("/me/picture?type=square&height=256&width=256", HttpMethod.GET, returnProfile);
        }
        if (!isLogged)
        {
            LoggedInDialog.SetActive(false);
            LoggedOutDialog.SetActive(true);
        }
    }
    void returnUsername(IResult result)
    {
        if (result.Error == null)
            username = result.ResultDictionary["first_name"] as string;
        else Debug.Log(result.Error);
        GameObject.Find("Username").GetComponent<Text>().text = username;
    }
    void returnProfile(IGraphResult result)
    {
        if (result.Texture != null)
            ProfilePicture = Sprite.Create(result.Texture, new Rect(0,0,256,256), new Vector2());
        GameObject.Find("ProfilePic").GetComponent<Image>().sprite = ProfilePicture;
    }
    public void QueryScores()
    {
        FB.API("/app/scores?fields=score,user.limit(30)", HttpMethod.GET, ScoresCallback);
    }
    private void ScoresCallback(IResult result)
    {
        PlayersNames.Clear();
        PlayersScores.Clear();
        ScrollScoreList = GameObject.Find("ScrollView");
        ScrollContent = GameObject.Find("ScrollContent");
        IDictionary<string, object> data = result.ResultDictionary;
        List<object> scoreList = (List<object>) data["data"];
        foreach (Transform obj in ScrollContent.transform)
        {
            Destroy(obj.gameObject);
        }   
            foreach (object obj in scoreList)
        {
            var entry = (Dictionary<string, object>)obj;
            var user = (Dictionary<string, object>)entry["user"];
            GameObject scorePanel = Instantiate(ScoreEntryPanel) as GameObject;

            Debug.Log(user["name"].ToString() + " , " + entry["score"].ToString());
               
            scorePanel.transform.SetParent(ScrollContent.transform, false);

            Transform Fname = scorePanel.transform.Find("FriendName");
            Transform Fscore = scorePanel.transform.Find("FriendScore");
            Transform FAvatar = scorePanel.transform.Find("FriendAvatar");

            Text Fnametext = Fname.GetComponent<Text>();
            Text Fscoretext = Fscore.GetComponent<Text>();
            Image Fuseravatar = FAvatar.GetComponent<Image>();

            Fnametext.text = user["name"].ToString();
            PlayersNames.Add(Fnametext.text);
            Fscoretext.text = entry["score"].ToString();
            PlayersScores.Add(int.Parse(Fscoretext.text));
            FB.API(user["id"].ToString() + "/picture?width=256&height=256", HttpMethod.GET, delegate (IGraphResult picResult)
            {
                if (picResult.Error != null)
                {
                    Debug.Log(picResult.RawResult);
                }
                else
                {
                    Fuseravatar.sprite = Sprite.Create(picResult.Texture, new Rect(0, 0, 256, 256), new Vector2());
                }
            });
        }
    }
    public void setHighscore(int x)
    {
        if (permit == false)
        {
            List<string> Permissions = new List<string>();
            Permissions.Add("publish_actions");
            FB.LogInWithPublishPermissions(Permissions, AuthCallBack);
            permit = true;
        }
        var scoreData = new Dictionary<string, string>();
        scoreData["score"] = x.ToString();
        FB.API("/me/scores",
            HttpMethod.POST,
            delegate (IGraphResult result) {
                Debug.Log("Score submit " + result.RawResult);
            }
            , scoreData);
    }

}
