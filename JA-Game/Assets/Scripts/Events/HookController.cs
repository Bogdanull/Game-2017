using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour {
    public bool isShot, isAttached;
    public KeyCode Key;
    public GameObject user, hand, gunPos, hookPosition;
    public float ShotForce;
    public float PullForce;
    public float angleInDegrees;
    public float timeToBreak = 1, timerHook;
    Vector3 LastPosition;
    Touch Last;
    public int touchesLast = 0, lastID = -1;
    Camera camera;
    public Color x;
    Vector2 Target;
    public GameObject BrickParticles, SewageParticles, BlueParticles;
    int particlesActive;
    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        isShot = false;
        resetHook();
        particlesActive = PlayerPrefs.GetInt("Particles");
	}
	
	// Update is called once per frame
	void Update () {
        if (!user.GetComponent<Controller>().Jetpack)
        {
            lastID = lastID + Input.touchCount - touchesLast;
            if (Input.touchCount > 0 && lastID > -1)
                Last = Input.GetTouch(lastID);
            if (isShot == true && Input.touchCount == 0 || Last.phase == TouchPhase.Ended)
            {
                resetHook();
                lastID = -1;
            }
            if (isShot)
            {
                timerHook += Time.deltaTime;
                this.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 1));
                this.GetComponent<LineRenderer>().SetPosition(1, new Vector3(gunPos.transform.position.x, gunPos.transform.position.y, 1));
                if(!isAttached) this.GetComponent<LineRenderer>().material.color = new Color(timerHook*2, 0, 0, 1);
                x = new Color(timerHook*2.5f, 0, 0, 1);
                if (timerHook > timeToBreak && !isAttached) resetHook();
            }
                bool ok = false;
                for (int i = 0; i < Input.touchCount; i++)
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        Last = Input.GetTouch(i);
                        lastID = i;
                        ok = true;
                    }
                if (ok)
                {
                    Target = new Vector2(Last.position.x,
                                        Last.position.y);
                    Target = camera.ScreenToWorldPoint(new Vector3(Target.x, Target.y, 0));
                    angleInDegrees = hand.GetComponent<HandMove>().angleInDegrees;
                    Vector3 Rotation = transform.eulerAngles;
                    Rotation.z = 90 - angleInDegrees;
                    this.transform.eulerAngles = Rotation;
                    ShotAt(Target.x, Target.y, Last);
                }
            if (isShot && isAttached)
            {
                LastPosition = transform.position;
                user.GetComponent<Controller>().GoToPoint(transform.position, PullForce);
            }
            touchesLast = Input.touchCount;
        }
        else resetHook();
    }

    void ShotAt(float x, float y, Touch a)
    {
        resetHook();
        hand.GetComponent<HandMove>().Rotate(a);
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        float angle = Mathf.Atan2(y - transform.position.y, x - transform.position.x);
        x = Mathf.Cos(angle);
        y = Mathf.Sin(angle);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * 42, ForceMode2D.Impulse);
        isShot = true;
        isAttached = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" && isShot && !isAttached)
        {
            if (particlesActive == 1) {
                GameObject x = null;
                if (PlayerPrefs.GetInt("Background") != 2 && PlayerPrefs.GetInt("Background") != 3)
                    x = Instantiate(BrickParticles, transform.position - new Vector3(0, 0, 5), Quaternion.identity);
                if (PlayerPrefs.GetInt("Background") == 2)
                    x = Instantiate(SewageParticles, transform.position - new Vector3(0, 0, 5), Quaternion.identity);
                if (PlayerPrefs.GetInt("Background") == 3)
                    x = Instantiate(BlueParticles, transform.position - new Vector3(0, 0, 5), Quaternion.identity);
                if (x != null)
                    Destroy(x, x.GetComponent<ParticleSystem>().duration);
            }
            isAttached = true; 
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            user.GetComponent<Controller>().GoToPoint(transform.position, PullForce);
        }
    }
    void resetHook()
    {
        timerHook = 0;
        isShot = false;
        isAttached = false;
        this.GetComponent<LineRenderer>().SetPosition(0, new Vector2(1000, 1000));
        this.GetComponent<LineRenderer>().SetPosition(1, new Vector2(1000, 1000));
        if (this.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.transform.position = new Vector3(gunPos.transform.position.x, gunPos.transform.position.y, 1);
    }

}
