using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject player;
    [SerializeField] private float speed;

    [SerializeField] LayerMask layer;
    [SerializeField] Transform point;
    [SerializeField] float radius;
    [SerializeField] bool nearPlayer;

    [Header("key to green from red")]
    [SerializeField] LayerMask[] layerKey;
    [SerializeField] Transform pointKey;
    [SerializeField] float radiusKey;
    [SerializeField] bool[] nearKey;
    [SerializeField] GameObject Key;
    [SerializeField] GameObject Keysatu;
    [SerializeField] GameObject Keydua;
    [SerializeField] GameObject Keytiga;

    [SerializeField] GameObject fx;

    [SerializeField] float currTime;
    [SerializeField] float fixedTime;
    private SpriteRenderer sprite;

    [Header("player death")]
    [SerializeField] private GameObject Deathfx;
    [SerializeField] private GameObject livefx;
    [SerializeField] private Transform startPoint;

    private Animator animCamera;

    public static AudioSource audioFx;
    [SerializeField] private GameObject audioDeath;
    [SerializeField] private GameObject audioKey;

    private void Awake()
    {
        audioFx = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        Key = GameObject.FindGameObjectWithTag("Key");
        Keysatu = GameObject.FindGameObjectWithTag("KeySatu");
        Keydua = GameObject.FindGameObjectWithTag("KeyDua");
        Keytiga = GameObject.FindGameObjectWithTag("KeyTiga");

        // Death Player
        animCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        if (PlayerPrefs.GetString("sfx") == "true")
            audioFx.Play();
        else
            audioFx.Stop();

    }

    void FixedUpdate ()
    {
        //if (Player.health == 0)
        //{
        //    var orange = GameObject.FindGameObjectsWithTag("Bullet");
        //    foreach (var item in orange)
        //    {
        //        item.GetComponent<AudioSource>().enabled = false;
        //    }
        //    return;
        //}

        if (Finish.bulletMove == true)
        {
            audioFx.Stop();
            return;
        }
        if (Player.health == 0)
        {
            audioFx.Stop();
            return;
        }
        if (MovePortal.notMove == true)
        {
            audioFx.Stop();
            return;
        }



        nearPlayer = Physics2D.OverlapCircle(point.position, radius, layer);
        for (int i = 0; i < nearKey.Length; i++)
        {
            nearKey[i] = Physics2D.OverlapCircle(pointKey.position, radiusKey, layerKey[i]);
        }


            Vector2 temp = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, temp, speed);

        if (nearPlayer)
        {

            sprite.color = Color.red;


            if (currTime >= 2 )
            {
                if (nearKey[0])
                {
                    Key.GetComponent<SpriteRenderer>().color = Color.green;
                    Key.GetComponent<TrailRenderer>().material.color = Color.green;
                    Instantiate(audioKey, transform.position, Quaternion.identity);
                }
                if (nearKey[1])
                {
                    Keysatu.GetComponent<SpriteRenderer>().color = Color.green;
                    Keysatu.GetComponent<TrailRenderer>().material.color = Color.green;
                    Instantiate(audioKey, transform.position, Quaternion.identity);
                }
                if (nearKey[2])
                {
                    Keydua.GetComponent<SpriteRenderer>().color = Color.green;
                    Keydua.GetComponent<TrailRenderer>().material.color = Color.green;
                    Instantiate(audioKey, transform.position, Quaternion.identity);
                }
                if (nearKey[3])
                {
                    Keytiga.GetComponent<SpriteRenderer>().color = Color.green;
                    Keytiga.GetComponent<TrailRenderer>().material.color = Color.green;
                    Instantiate(audioKey, transform.position, Quaternion.identity);
                }

                string sound = PlayerPrefs.GetString("sfx");
                if (sound == "true")
                {
                    Instantiate(audioDeath, transform.position, Quaternion.identity);
                }

                Instantiate(fx, transform.position, Quaternion.identity);
                animCamera.SetTrigger("shake");
                Destroy(gameObject);
                currTime = fixedTime;
            }
            else
            {
                currTime += Time.deltaTime;
            }
        }
	}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        animCamera.SetTrigger("shake");
    //        other.transform.position = startPoint.transform.position;
    //        Player.speed = 0f;
    //        Player.dash = 0f;
    //        Player.health--;
    //        Instantiate(Deathfx, transform.position, Quaternion.identity);
    //        transform.position = new Vector3(0f, 100f, 0f);

    //        other.GetComponent<SpriteRenderer>().enabled = false;
    //        other.GetComponent<TrailRenderer>().enabled = false;

    //        if (Player.health == 0)
    //        {
    //            other.transform.position = startPoint.transform.position;
    //            Player.speed = 5f;
    //            Player.dash = 100f;
    //            Player.health = 0;

    //            transform.position = new Vector3(0f, 100f, 0f);
    //        }
    //        else
    //        {
    //            StartCoroutine("WaitPlayer");
    //        }

    //    }
    //}

    //IEnumerator WaitPlayer()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Instantiate(livefx, startPoint.transform.position, Quaternion.identity);
    //    animCamera.SetTrigger("shake");
    //    player.GetComponent<SpriteRenderer>().enabled = true;
    //    player.GetComponent<TrailRenderer>().enabled = true;
    //    Player.speed = 5f;
    //    Player.dash = 100f;
    //    Destroy(gameObject);
    //}

}
