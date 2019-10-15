using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Disappear());
	}
	
	private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.2f);
        float time = 0;
        while (time < 0.5f)
        {
            transform.position += new Vector3 (0, Time.deltaTime/3, 0);
            GetComponent<TextMesh>().color = new Color(1, 1, 1, 1 - time * 2);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
