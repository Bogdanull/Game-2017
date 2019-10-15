using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {
    public bool Heating = true, Firing = false, frozen = false;
    public float time, timeCharge, timeFire;
    public GameObject Fire, Sign;
    Color chargeColor;
    public Sprite FrozenPipe, NormalPipe;
    public AudioSource x;

    void Start()
    {
        x.Play();
        if (GameObject.Find("Character").GetComponent<Controller>().slowTime)
            Freeze();

    }

    void Update()
    {
        chargeColor.a = 1;
        chargeColor.b = 1;
        chargeColor.g = 1;
        chargeColor.r = 1;
        if(!frozen)
        time += Time.deltaTime;
        if (Heating && time >= timeCharge)
        {
            Sign.SetActive(false);
            Heating = false;
            Firing = true;
            time = 0;
            Fire.SetActive(true);
        }
        else if (Heating)
        {
            if (timeCharge - time < 1) Sign.SetActive(true);
            chargeColor.b = (timeCharge - time) / timeCharge;
            chargeColor.g = (timeCharge - time) / timeCharge;
            this.GetComponent<SpriteRenderer>().color = chargeColor;
        }
        else if (Firing && time >= timeFire)
        {
            Heating = true;
            Firing = false;
            time = 0;
            x.Stop();
            x.Play();
            this.GetComponent<SpriteRenderer>().color = chargeColor;
            Fire.SetActive(false);
        }
        else if (Firing)
        {
            chargeColor.b = time / timeFire;
            chargeColor.g = time / timeFire;
            this.GetComponent<SpriteRenderer>().color = chargeColor;
        }
    }

    public void Freeze()
    {
        frozen = true;
        if (Firing)
        {
            Fire.SetActive(false);
            Sign.SetActive(true);
        }
        x.Pause();
        this.GetComponent<SpriteRenderer>().sprite = FrozenPipe;
    }
    public void Unfreeze()
    {
        frozen = false;
        if (Firing)
        {
            Fire.SetActive(true);
            Sign.SetActive(false);
        }
        x.Play();
        this.GetComponent<SpriteRenderer>().sprite = NormalPipe;
    }

}
