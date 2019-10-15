using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeScript : MonoBehaviour {

	public void show()
    {
        StartCoroutine(showE());
    }
    public void hide()
    {
        StartCoroutine(hideE());
    }
    public IEnumerator showE()
    {
        for(float i=0; i<=1; i += Time.deltaTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, i*0.3f);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator hideE()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, (1 - i) * 0.3f);
            yield return new WaitForEndOfFrame();
        }
    }
}
