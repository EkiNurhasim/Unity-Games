using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Movement And Fx")]
    [SerializeField] public static float speed = 5f;
    [SerializeField] public static float dash = 100f;
    [SerializeField] private GameObject fx;

    private Animator animCamera;
    private Rigidbody2D rig;

    // INPUT UNTUK MOBILE DEVICE
    private bool top = false;
    private bool right = false;
    private bool bottom = false;
    private bool left = false;
    private bool dodge = false;

    // HEALTH STUFF
    [Header("Health Stuff")]
    public static int health = 3;
    [SerializeField] private int numOfHearts;
    [SerializeField] private Color squareGreen;
    [SerializeField] private Color squareRed;
    [SerializeField] private Image[] squares;

    // FOR BULLET
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject deathFX;
    [SerializeField] private GameObject liveFx;
    [SerializeField] private AudioSource[] soundFx;

    // AUDIO STUFF
    private AudioSource audioFx;

    // JOYSTICK STUFF
    private float horizontal;
    private float vertical;
	
	private void Awake ()
    {
        audioFx = GetComponent<AudioSource>();
        GetComponent<PlayerBounds>().enabled = true;
        speed = 5f;
        dash = 100f;
        rig = GetComponent<Rigidbody2D>();
        animCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
	}

    private void Update()
    {
        Health();
    }

    private void FixedUpdate()
    {
        Move();
        JoyStick();
        JoyDash();
    }

    // JOYSTICK STUFF
    private void JoyStick()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed ;
        vertical = Input.GetAxisRaw("Vertical") * speed ;

        transform.Translate(new Vector2(horizontal * Time.fixedDeltaTime, vertical * Time.fixedDeltaTime));
    }

    private void JoyDash()
    {
        if (dodge || Input.GetKeyDown(KeyCode.Space))
        {
            if (horizontal > 0 ||
                horizontal < 0 ||
                vertical > 0 ||
                vertical < 0)
            {
                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                    audioFx.Play();
                else
                    audioFx.Stop();

                animCamera.SetTrigger("shake");
                Instantiate(fx, transform.position, Quaternion.identity);
                transform.Translate(new Vector2(horizontal * (dash / 5f) * Time.fixedDeltaTime, vertical * (dash / 5f) * Time.fixedDeltaTime));
                dodge = false;
            }
            else
            {
                dodge = false;
            }
        }
        else
        {
            dodge = false;
        }
        
    }



    // HEALTH BAR
    private void Health()
    {
        if (health > numOfHearts)
            health = numOfHearts;

        if (health < 0)
        {
            health = 0;
            GetComponent<PlayerBounds>().enabled = false;
            transform.position = new Vector2(0, 10000f);
        }

        for (int i = 0; i < squares.Length; i++)
        {
            if (i < health)
            {
                squares[i].color = squareGreen;
            }
            else
            {
                squares[i].color = squareRed;
            }

            if (i < numOfHearts)
            {
                squares[i].enabled = true;
            }
            else
            {
                squares[i].enabled = false;
            }
        }
    }

    // HANDLE MOVEMENT PLAYER
    private void Move()
    {
        if (right || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
            if (dodge || Input.GetKeyDown(KeyCode.Space))
            {
                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                    audioFx.Play();
                else
                    audioFx.Stop();

                animCamera.SetTrigger("shake");
                Instantiate(fx, transform.position, Quaternion.identity);
                transform.Translate(new Vector2(dash * Time.fixedDeltaTime, rig.velocity.y));
                dodge = false;
            }
            dodge = false;
        }
        else
        {
            right = false;
        }

        if (left || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
            if (dodge || Input.GetKeyDown(KeyCode.Space))
            {
                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                    audioFx.Play();
                else
                    audioFx.Stop();

                animCamera.SetTrigger("shake");
                Instantiate(fx, transform.position, Quaternion.identity);
                transform.Translate(new Vector2(-dash * Time.fixedDeltaTime, rig.velocity.y));
                dodge = false;
            }
            dodge = false;
        }
        else
        {
            left = false;
        }

        if (top || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
            if (dodge || Input.GetKeyDown(KeyCode.Space))
            {
                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                    audioFx.Play();
                else
                    audioFx.Stop();

                animCamera.SetTrigger("shake");
                Instantiate(fx, transform.position, Quaternion.identity);
                transform.Translate(new Vector2(rig.velocity.x, dash * Time.fixedDeltaTime));
                dodge = false;
            }
            dodge = false;
        }
        else
        {
            top = false;
        }

        if (bottom || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
            if (dodge || Input.GetKeyDown(KeyCode.Space))
            {
                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                    audioFx.Play();
                else
                    audioFx.Stop();

                animCamera.SetTrigger("shake");
                Instantiate(fx, transform.position, Quaternion.identity);
                transform.Translate(new Vector2(rig.velocity.x, -dash * Time.fixedDeltaTime));
                dodge = false;
            }
            dodge = false;
        }
        else
        {
            bottom = false;
        }
    }

    // FOR BULLET
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                soundFx[0].Play();
            else
                soundFx[0].Stop();

            animCamera.SetTrigger("shake");
            transform.position = startPoint.transform.position;
            speed = 0f;
            dash = 0f;
            health--;
            Instantiate(deathFX, other.transform.position, Quaternion.identity);
            other.transform.position = new Vector3(0f, 100f, 0f);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;

            if (health == 0)
            {
                transform.position = startPoint.transform.position;
                speed = 5f;
                dash = 100f;
                health = 0;

                other.transform.position = new Vector3(0f, 100f, 0f);
            }
            else
            {
                StartCoroutine("WaitPlayer");
                Destroy(other.gameObject);
            }

        }
    }

    IEnumerator WaitPlayer()
    {
        yield return new WaitForSeconds(1f);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            soundFx[1].Play();
        else
            soundFx[1].Stop();

        Instantiate(liveFx, startPoint.transform.position, Quaternion.identity);
        animCamera.SetTrigger("shake");
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<TrailRenderer>().enabled = true;
        speed = 5f;
        dash = 100f;
    }


    // INPUT UNTUK MOBILE DEVICE
    public void Top()
    {
        top = true;
    }

    public void TopRelease()
    {
        top = false;
    }

    public void Right()
    {
        right = true;
    }

    public void RightRelease()
    {
        right = false;
    }

    public void Bottom()
    {
        bottom = true;
    }

    public void BottomRelease()
    {
        bottom = false;
    }

    public void Left()
    {
        left = true;
    }

    public void LeftRelease()
    {
        left = false;
    }

    public void Dodge()
    {
        dodge = true;
    }

    public void DodgeRelease()
    {
        dodge = false;
    }
}
