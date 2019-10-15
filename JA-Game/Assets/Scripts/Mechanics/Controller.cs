using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public float Force;
    public float ScreenHeight, ScreenWidth, speedCoeficient;
    public bool going, touchingWall, slowTime, Jetpack, Speed;
    public float timeSpeed, timeJetpack, timeSlow, ASpeed, AJetpack, ASlow;
    Touch lastTouch;
    Vector2 GoToPos;
    public GameObject x1, x2, x3;
    public Image P1, P2, P3;
    public Text T2, T3;
    public GameObject DeadExplosion, DeadElectric, DeadDust, DeadBurnt;
    public Slider slider;
    Vector2 LastPosition;
    public bool isDead;
    bool TurnedOn1 = false, TurnedOn2 = false, turnedOn3 = false;
    bool gravity;
    float gravityTime;
    string killer;
    public GameObject Jet, Fire;
    public Sprite normal, goingLeft, goingRight, standingLeft, standingRight;
    Camera camera;

    void Start()
    {
        ScreenHeight = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        ScreenWidth = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        if (!isDead && GameObject.Find("Main Camera").transform.position.y > transform.position.y + ScreenHeight + 1)
        {
            StartCoroutine(Dead());
            isDead = true;
        }
        if (!isDead)
        {
            if (gravity == true)
            {
                gravityTime -= Time.deltaTime;
                if (gravityTime < 0)
                {
                    gravity = false;
                    this.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }
            slider.value = AJetpack / timeJetpack;
            T2.text = Mathf.CeilToInt(ASlow).ToString();
            if (ASlow < 3) T2.color = new Color(1, 0, 0, 1);
            else T2.color = new Color(1, 1, 1, 1);
            T3.text = Mathf.CeilToInt(ASpeed).ToString();
            if (ASpeed < 3) T3.color = new Color(1, 0, 0, 1);
            else T3.color = new Color(1, 1, 1, 1);
            if (!going && !touchingWall ) GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite = normal;
            going = false;
            if (Jetpack)
            {
                AJetpack -= Time.deltaTime;
                if (AJetpack < 0)
                {
                    GetComponent<TrailRenderer>().enabled = false;
                    AJetpack = 0;
                    Jetpack = false;
                    gravity = true;
                    gravityTime = 1;
                    this.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                }
                if (!TurnedOn1)
                {
                    GetComponent<TrailRenderer>().enabled = true;
                    GetComponent<TrailRenderer>().startColor = new Color(1, 0, 0);
                    LastPosition = this.transform.position;
                    Jet.SetActive(true);
                    Fire.SetActive(false);
                    TurnedOn1 = true;
                    x1.SetActive(true);
                    P1.enabled = true;
                }
                if (Input.touchCount > 0)
                {
                    lastTouch = Input.GetTouch(Input.touchCount - 1);
                    GoToPos = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(lastTouch.position.x, lastTouch.position.y, 0));
                    GoToJetpack(GoToPos, Force);
                    LastPosition = this.transform.position;
                }
            }
            else if (TurnedOn1)
            {
                x1.SetActive(false);
                P1.enabled = false;
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                Jet.SetActive(false);
                TurnedOn1 = false;
            }
            if (slowTime)
            {
                ASlow -= Time.deltaTime;
                if (ASlow < 0)
                {
                    slowTime = false;
                    ASlow = 0;
                    GameObject.Find("SlowShade").GetComponent<ShadeScript>().hide();
                }
                if (!TurnedOn2)
                {
                    GameObject.Find("SlowShade").GetComponent<ShadeScript>().show();
                    x2.SetActive(true);
                    P2.enabled = true;
                    TurnedOn2 = true;
                    foreach (GameObject a in GameObject.FindGameObjectsWithTag("damage"))
                    {
                        if (a.GetComponent<sawScript>() != null)
                        {
                            a.GetComponent<sawScript>().movingSpeed = 3;
                        }
                        if (a.GetComponent<BoulderScript>() != null)
                        {
                            a.GetComponent<BoulderScript>().fallingSpeed = 2;
                        }
                        if (a.GetComponent<PipeScript>() != null)
                        {
                            a.GetComponent<PipeScript>().Freeze();
                        }
                    }
                }
            }
            else if (TurnedOn2)
            {
                x2.SetActive(false);
                P2.enabled = false;
                TurnedOn2 = false;
                foreach (GameObject a in GameObject.FindGameObjectsWithTag("damage"))
                {
                    if (a.GetComponent<sawScript>() != null)
                    {
                        a.GetComponent<sawScript>().movingSpeed = 6;
                    }
                    if (a.GetComponent<BoulderScript>() != null)
                    {
                        a.GetComponent<BoulderScript>().fallingSpeed = 4;
                    }
                    if (a.GetComponent<PipeScript>() != null)
                    {
                        a.GetComponent<PipeScript>().Unfreeze();
                    }
                }
            }
            if (Speed)
            {
                if (!turnedOn3)
                {
                    x3.SetActive(true);
                    P3.enabled = true;
                    turnedOn3 = false;
                    GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/FlashHead");
                }
                ASpeed -= Time.deltaTime;
                if (ASpeed < 0)
                {
                    GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Head");
                    Speed = false;
                    ASpeed = 0;
                    x3.SetActive(false);
                    P3.enabled = false;
                }
            }
            if (x1.activeSelf)
            {
                P1.rectTransform.anchoredPosition = new Vector3(80, -175);
                if (x2.activeSelf)
                {
                    P2.rectTransform.anchoredPosition = new Vector3(80, -270);
                    if (x3.activeSelf) P3.rectTransform.anchoredPosition = new Vector3(80, -365);
                }
                else if (x3.activeSelf) P3.rectTransform.anchoredPosition = new Vector3(80, -270);
            }
            else if (x2.activeSelf)
            {
                P2.rectTransform.anchoredPosition = new Vector3(80, -165);
                if (x3.activeSelf) P3.rectTransform.anchoredPosition = new Vector3(80, -270);
            }
            else if (x3.activeSelf) P3.rectTransform.anchoredPosition = new Vector3(80, -175);
        }
    }

    public void GoToPoint(Vector3 pos, float power)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        if (Mathf.Abs(transform.position.x - pos.x) > 0.25f || Mathf.Abs(transform.position.y - pos.y) > 0.25f)
        {
            going = true;
            if (pos.x < 0 && !touchingWall)
                GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite = goingLeft;
            else if (pos.x > 0 && !touchingWall)
                GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite = goingRight;
            float angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            if(Speed)
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x, pos.y) * power * speedCoeficient, ForceMode2D.Impulse);
            else this.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x, pos.y) * power, ForceMode2D.Impulse);
        }
    }

    public void GoToJetpack(Vector3 pos, float power)
    {
        Fire.SetActive(true);
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        if (Mathf.Abs(transform.position.x - pos.x) > 0.3f || Mathf.Abs(transform.position.y - pos.y) > 0.3f)
        {
            if (pos.x < transform.position.x) transform.localScale = new Vector3 (-0.5f, 0.5f, 1);
            else transform.localScale = new Vector3(0.5f, 0.5f, 1);
            going = true;
            float angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            if (Speed)
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x, pos.y) * power * speedCoeficient, ForceMode2D.Impulse);
            else this.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x, pos.y) * power, ForceMode2D.Impulse);
        }
    }

    public IEnumerator Dead()
    {
        if (PlayerPrefs.GetInt("vibrationsOn") == 1)
            Handheld.Vibrate();
        if (killer != null && killer.StartsWith("Electricity"))
            Instantiate(DeadElectric, this.transform.position, Quaternion.identity);
        else if (killer != null && killer.StartsWith("Fire"))
            Instantiate(DeadBurnt, this.transform.position, Quaternion.identity);
        else if (killer != null && killer.StartsWith("Saw"))
            Instantiate(DeadDust, this.transform.position, Quaternion.identity);
        else Instantiate(DeadExplosion, this.transform.position, Quaternion.identity);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        if (GameObject.Find("GM").GetComponent<mapCreator>() != null) GameObject.Find("GM").GetComponent<mapCreator>().gameCanvas.SetActive(false);
        else if (GameObject.Find("GM").GetComponent<mapCreatorLevel1>() != null) GameObject.Find("GM").GetComponent<mapCreatorLevel1>().gameCanvas.SetActive(false);
        Destroy(this.GetComponent<Rigidbody2D>());
        isDead = true;
        yield return new WaitForSecondsRealtime(1);
        if (GameObject.Find("GM").GetComponent<mapCreator>() != null) GameObject.Find("GM").GetComponent<mapCreator>().EndGame();
        else if (GameObject.Find("GM").GetComponent<mapCreatorLevel1>() != null) GameObject.Find("GM").GetComponent<mapCreatorLevel1>().EndGame();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "damage")
        {
            killer = collision.collider.name;
            StartCoroutine(Dead());
        }
        if (collision.collider.tag == "wall" && transform.position.x < 0)
        {
            touchingWall = true;
            if (!Jetpack) GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite = standingLeft;
        }
        if (collision.collider.tag == "wall" && transform.position.x > 0)
        {
            touchingWall = true;
            if(!Jetpack) GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite = standingRight;
        }
    }
 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
            touchingWall = false;
    }
}