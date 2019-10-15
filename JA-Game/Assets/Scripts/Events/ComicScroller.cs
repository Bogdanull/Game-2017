using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicScroller : MonoBehaviour {
    public float firstPos, LastPos;
    public float timeCD;
    public string nextScene;
    public GameObject x;
		void Awake () {
        StartCoroutine(scroll());
	}
    public IEnumerator scroll()
    {
        x.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, firstPos);
        yield return new WaitForSecondsRealtime(2);
        for(float a=0; a<=timeCD; a+= Time.fixedDeltaTime)
        {
            Debug.Log(a);
            x.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, firstPos + 2 * LastPos * (a / timeCD));
            yield return new WaitForEndOfFrame();
        }
    }
}
