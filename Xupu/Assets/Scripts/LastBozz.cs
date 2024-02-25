using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LastBozz : MonoBehaviour {

    public static string complate = "false";
    public static int health;
    [SerializeField] GameObject deathBoz;
    [SerializeField] GameObject congratulation;
    [SerializeField] GameObject[] respawners;
    [SerializeField] Transform[] pointsRespawner;
    [SerializeField] Text text;
    private Animator anim;
	
	void Awake ()
    {
        health = 1000;
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        text.text = health.ToString();
        if (Player.health == 0)
            return;

        if (health == 0)
        {
            health = 0;
            complate = "true";
            PlayerPrefs.SetString("complate", complate);
            Instantiate(deathBoz, transform.position, Quaternion.identity);
            congratulation.SetActive(true);
            Destroy(gameObject);
        }

        if (health == 0)
            return;

        int random = Random.Range(0, 3);

        if (random == 0)
            anim.SetTrigger("attack");
        else
            anim.ResetTrigger("attack");

        if (random == 1)
            anim.SetTrigger("move");
        else
            anim.ResetTrigger("move");
	}

    public void Attack()
    {
        for (int i = 0; i < respawners.Length; i++)
        {
            Instantiate(respawners[i], pointsRespawner[i].transform.position, Quaternion.identity);
        }
    }
}
