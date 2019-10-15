using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class GetFacebookProfile : MonoBehaviour {
    GameObject name, pic;
	void Start () {
        name = GameObject.Find("Username");
        pic = GameObject.Find("ProfilePic");
    }
	
	// Update is called once per frame
	void Update () {
        if (FB.IsLoggedIn)
        {
            if (name.GetComponent<Text>().text == "username")
            {
                name.GetComponent<Text>().text = GameObject.Find("FB Holder").GetComponent<FBholder>().username;
            }
            if (pic.GetComponent<Image>().sprite == null)
            {
                pic.GetComponent<Image>().sprite = GameObject.Find("FB Holder").GetComponent<FBholder>().ProfilePicture;
            }
        }
    }
}
