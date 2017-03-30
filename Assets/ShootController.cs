using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootController : MonoBehaviour
{

    Vector2 start;
    public GameObject Shootpoint;
    public float speed;
    public Color color;
    Vector3[] positions = new Vector3[3];

    public GameObject Audiowhenshoot;
    public GameObject Audiowhencollision;

    private LineRenderer lineRenderer;

    public int stonenumber = 3;
    public GameObject lose;

    public HeadcollisionController head;

    public int check = 0;

    private int fail = 0;


    void Start()
    {
        //畫彈弓的線!!
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material.color = color;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;


        positions[0] = new Vector3(-9.73f, -0.83f, 0.0f);
        positions[1] = transform.position;
        positions[2] = new Vector3(-10.43f, -0.89f, 0.0f);
        GetComponent<LineRenderer>().numPositions = positions.Length;
        GetComponent<LineRenderer>().SetPositions(positions);
    }

    void Update()
    {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        if(Input.GetKeyDown("space"))   //按空白鍵重製
        {
            Audiowhenshoot.SetActive(false);
            transform.position = new Vector3(-10.2f, -1.17f, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().rotation = 0;

            if (stonenumber <= 0) //沒石頭就輸了
            {
                lose.gameObject.SetActive(true);
                fail = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && fail == 1) //沒石頭且輸時時按R重新開始
        {
            print("work");
            SceneManager.LoadScene("Angrybirdlevel1");
        }

        if (Input.GetMouseButton(0)) //有感應到滑鼠時
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().rotation = 0;
            //重製石頭狀態
            print("QQQ");
            Vector3 delta = mouse - Shootpoint.transform.position;
            //紀錄滑鼠現在位子與Shootpoint.transform.position差異
            if (delta.magnitude > 1.4f)
                delta = delta.normalized * 1.2f;
            //把delta加進原位置得到新位置
            transform.position = Shootpoint.transform.position + delta;

            if(stonenumber != 3 && check == 0)
            {
                check = 1;
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.material.color = color;
                lineRenderer.startWidth = 0.2f;
                lineRenderer.endWidth = 0.2f;

            }

            positions[0] = new Vector3(-9.73f, -0.83f, 0.0f);
            positions[1] = Shootpoint.transform.position + delta * 1.07f;
            positions[2] = new Vector3(-10.43f, -0.89f, 0.0f);
            GetComponent<LineRenderer>().numPositions = positions.Length;
            GetComponent<LineRenderer>().SetPositions(positions);
        }



        if (Input.GetMouseButtonUp(0)) //滑鼠起來時
        {
            stonenumber--;
            Audiowhenshoot.SetActive(true);
            Vector3 delta = Shootpoint.transform.position - transform.position;
            //向量減法方向是第二點到第一點
            GetComponent<Rigidbody2D>().AddForce(delta * speed);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(GetComponent<LineRenderer>());
            if(check == 1)
            {
                check = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && head.winnumber == 1)
        {
            print("PLZ");
            SceneManager.LoadScene("Angrybirdlevel2");
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("www");
        Audiowhencollision.SetActive(true);
        Audiowhencollision.GetComponent<AudioSource>().Play();
    }
}
