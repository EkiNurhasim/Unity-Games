using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] GameObject bullets;
    [SerializeField] Transform pointBullet;
    [SerializeField] float currTime = 0;
    [SerializeField] float fixedTime = 0;
    [SerializeField] private AudioSource audioFx;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("bamm");
        Instantiate(bullets, pointBullet.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Finish.bulletMove == true)
            return;
        if (Player.health == 0)
            return;
        if (MovePortal.notMove == true)
            return;

        if (currTime > 8f)
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx.Play();
            else
                audioFx.Stop();

            anim.SetTrigger("bamm");
            Instantiate(bullets, pointBullet.transform.position, Quaternion.identity);
            currTime = fixedTime;
        }
        else
        {
            currTime += Time.deltaTime;
        }
    }


}
