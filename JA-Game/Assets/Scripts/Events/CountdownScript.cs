using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour {
    public Text a;
    private void Start()
    {
        a = GetComponent<Text>();
        a.color = new Color(1, 1, 1, 0);
    }

    public IEnumerator StartCountdown(int seconds)
    {
        float x = seconds;
        while (x >= 0)
        {
            a.text = Mathf.FloorToInt(x+1).ToString();
            a.color = new Color(1, 1, 1, x - Mathf.FloorToInt(x));
            GetComponent<RectTransform>().localScale = new Vector2(1 + (Mathf.CeilToInt(x)-x)/2 , 1 + (Mathf.CeilToInt(x) - x) / 2);
            yield return new WaitForEndOfFrame();
            x -= Time.fixedDeltaTime;
        }
        a.color = new Color(1, 1, 1, 0); 
    }
    public void startCount(int seconds)
    {
       StartCoroutine(StartCountdown(seconds));
    }
    public void stopCount()
    {
        StopAllCoroutines();
        a.color = new Color(1, 1, 1, 0);
    }
}
