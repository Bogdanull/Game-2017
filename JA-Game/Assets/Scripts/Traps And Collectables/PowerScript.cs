using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour {
    public GameObject an1, an2, an3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (this.name.StartsWith("Slow"))
            {
                other.GetComponent<Controller>().slowTime = true;
                other.GetComponent<Controller>().ASlow = other.GetComponent<Controller>().timeSlow;
                Instantiate(an1, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            if (this.name.StartsWith("Speed"))
            {
                other.GetComponent<Controller>().Speed = true;
                other.GetComponent<Controller>().ASpeed = other.GetComponent<Controller>().timeSpeed;
                Instantiate(an2, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            if (this.name.StartsWith("Jetpack"))
            {
                other.GetComponent<Controller>().Jetpack = true;
                other.GetComponent<Controller>().AJetpack = other.GetComponent<Controller>().timeJetpack;
                Instantiate(an3, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            StartCoroutine(Disappear());
        }
        else if (other.tag == "wall")
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    { 
        if (other.tag == "wall")
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
    }
    public IEnumerator Disappear()
    {
        Destroy(GetComponent<Collider2D>());
        float time = 0;
        while (time <= 1f)
        {
            time += Time.deltaTime;
            transform.localScale += new Vector3(Time.deltaTime/3, Time.deltaTime/3, 0);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
