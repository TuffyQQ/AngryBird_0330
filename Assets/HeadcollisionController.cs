using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadcollisionController : MonoBehaviour {

    public GameObject Audiobirddie;
    public GameObject Enemy;
    public ParticleSystem dieparticle;
    public GameObject win;
    public GameObject AudioWin;

    public int winnumber = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        winnumber = 1;
        Audiobirddie.SetActive(true);
        Enemy.gameObject.SetActive(false);
        dieparticle.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        AudioWin.gameObject.SetActive(true);

    }
    void Update()
    {

    }

}
