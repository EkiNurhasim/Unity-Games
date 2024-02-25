using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    // PHYSICS
    [SerializeField] private float speed;
    [SerializeField] private float dash;
    [SerializeField] private GameObject dashFx;

    // MOVEMENT AND ANIMATION PLAYER
    private Rigidbody2D rig;
    private Animator anim;   

    private Vector2 input;
    private Vector2 direction;
    private Vector2 velocity;

    //FLIP PLAYER AND MOBILE INPUT
    public bool facingRight;
    private bool dodge;

    // TIMER FOR ATTACK DODGE AND MAGIC
    [SerializeField] private float timeForDodge = 1f;
    private Image dodgeTimerImage;
    private bool toDodge;
    private SpriteRenderer sprite;

    private void Start()
    {
        dodgeTimerImage = GameObject.Find("Dodge Time").GetComponent<Image>();
        sprite = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        //WalkFx();
        Flip(input.x);
        JoyDash();
        DodgeTime();
        OrderLayerPlayerWithWorld();
    }

    private void OrderLayerPlayerWithWorld()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("layerorder");

        for (int i = 0; i < others.Length; i++)
        {
            others[i].GetComponent<Transform>();
            if (others[i].transform.position.y > transform.position.y)
            {
                sprite.sortingOrder = 1;
            }
            else if (others[i].transform.position.y < transform.position.y)
            {
                sprite.sortingOrder = -1;
            }
        }
    }

    // TIMER DODGE ATTACK AND MAGIC
    private void DodgeTime()
    {
        if (toDodge == true)
        {
            dodgeTimerImage.fillAmount = timeForDodge;
        }
        else
        {
            dodgeTimerImage.fillAmount -= Time.fixedDeltaTime;
            if (dodgeTimerImage.fillAmount <= 0f)
            {
                dodgeTimerImage.fillAmount = 0f;
            }
        }
    }


    // MOVING AND ANIMATING THE PLAYER
    private void Move()
    {

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = input.normalized;
        velocity = direction * speed;


        if (input.x > 0f || input.x < 0f)
            anim.SetFloat("speed", Mathf.Abs(input.x));
        else if (input.y > 0f || input.y < 0f)
            anim.SetFloat("speed", Mathf.Abs(input.y));
        else
            anim.SetFloat("speed", 0f);

        rig.velocity = new Vector2(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime);
    }

    // PLAYER DODGE
    private void JoyDash()
    {
        if (dodgeTimerImage.fillAmount == 0)
        {
            if (dodge || Input.GetKeyDown(KeyCode.Space))
            {
                if (input.x > 0 ||
                    input.x < 0 ||
                    input.y > 0 ||
                    input.y < 0)
                {
                    Instantiate(dashFx, transform.position, Quaternion.identity);
                    transform.Translate(velocity * (dash / 5f) * Time.fixedDeltaTime);
                    dodge = false;
                    toDodge = true;
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
    }

    // FLIP PLAYER
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && facingRight || horizontal < 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }


    // MOBILE INPUT
    public void Dodge()
    {
        dodge = true;
    }

    public void DodgeRelease()
    {
        dodge = false;
        toDodge = false;
    }
    }
