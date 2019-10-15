using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour {
    float time = 0;
	// Use this for initialization
	void Awake () {
        if (!this.name.StartsWith("CharacterEvent_Burnt"))
        {
            foreach (Transform child in transform)
            {
                if (!(GameObject.Find("Main Camera").transform.position.y > transform.position.y + GameObject.Find("Character").GetComponent<Controller>().ScreenHeight + 1))
                    child.GetComponent<Rigidbody2D>().velocity = GameObject.Find("Character").GetComponent<Rigidbody2D>().velocity;
                if (!(GameObject.Find("Main Camera").transform.position.y > transform.position.y + GameObject.Find("Character").GetComponent<Controller>().ScreenHeight + 1))
                    child.GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * Mathf.Sin(Random.Range(-100, 100)), 10 * Mathf.Sin(Random.Range(-100, 100))), ForceMode2D.Force);
                else child.GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * Mathf.Sin(Random.Range(-100, 100)), 200), ForceMode2D.Force);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {    
		if(this.name.StartsWith("CharacterEvent_Burnt"))
        {
            time += Time.deltaTime;
            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1 - time*2, 1 - time*2);
            }
        }
	}
}
