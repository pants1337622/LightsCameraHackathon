using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject UpArrow;
    public GameObject DownArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject DontTouch;
    public AudioSource ShowYourMoves;
    public int boss;
    public Arrow arrowcode;
    public Character charactercode;
    public AudioSource[] Songs;
    public Slider enemyhealthbar;
    public int EnemyHealth;
    public MainMenu bosstype;
    // Start is called before the first frame update
    void Start()
    {
        boss = bosstype.bosstype;
        EnemyHealth = 200;
        SetMaxEnemyHealth(200);
        Songs[boss - 1].Play();
        StartCoroutine("Boss"+boss.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth <= 0)
        {
            charactercode.GameWin();
        }
    }
    public void Spawn(int type, float speed)
    {
        if (type == 1)
        {
            GameObject spawnedarrow = Instantiate(UpArrow, new Vector3(2.6f, this.transform.position.y, 0), transform.rotation) as GameObject;
            Arrow arrowscript = spawnedarrow.GetComponent<Arrow>();
            arrowscript.sp = speed;
        }
        if (type == 2)
        {
            GameObject spawnedarrow = Instantiate(DownArrow, new Vector3(3.6f, this.transform.position.y, 0), transform.rotation) as GameObject;
            Arrow arrowscript = spawnedarrow.GetComponent<Arrow>();
            arrowscript.sp = speed;
        }
        if (type == 3)
        {
            GameObject spawnedarrow = Instantiate(RightArrow, new Vector3(4.6f, this.transform.position.y, 0), transform.rotation) as GameObject;
            Arrow arrowscript = spawnedarrow.GetComponent<Arrow>();
            arrowscript.sp = speed;
        }
        if (type == 4)
        {
            GameObject spawnedarrow = Instantiate(LeftArrow, new Vector3(5.6f, this.transform.position.y, 0), transform.rotation) as GameObject;
            Arrow arrowscript = spawnedarrow.GetComponent<Arrow>();
            arrowscript.sp = speed;
        }
        if (type == 5)
        {
            GameObject spawnedarrow = Instantiate(DontTouch, new Vector3(this.transform.position.x, this.transform.position.y, 0), transform.rotation) as GameObject;
            Arrow arrowscript = spawnedarrow.GetComponent<Arrow>();
            arrowscript.sp = speed;
        }

    }
    public IEnumerator Boss1()
    {
        Spawn(Random.Range(1, 5), 0.01f);
        yield return new WaitForSeconds(1.2f);
        StartCoroutine("Boss1");
    }
    public IEnumerator Boss2()
    {
        Spawn(Random.Range(1, 5), 0.006f);
        yield return new WaitForSeconds(0.6f);
        StartCoroutine("Boss2");
    }
    public IEnumerator Boss3()
    {
        for (int i = 0; i < 8; i++)
        {
            Spawn(Random.Range(1, 5), 0.007f);
            yield return new WaitForSeconds(0.6f);
        }
        for (int i = 0; i < 6; i++)
        {
            Spawn(Random.Range(1, 5), 0.007f);
            yield return new WaitForSeconds(0.45f);
        }
        for (int i = 0; i < 18; i++)
        {
            Spawn(Random.Range(1, 5), 0.007f);
            yield return new WaitForSeconds(0.6f);
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Spawn(Random.Range(1, 5), 0.007f);
                yield return new WaitForSeconds(0.6f);
            }
            Spawn(5, 0.007f);
            yield return new WaitForSeconds(0.6f);
        }
        yield return new WaitForSeconds(4f);
        while (true)
        {
            Spawn(Random.Range(1, 5), 0.02f);
            yield return new WaitForSeconds(1f);
        }
    }
    public IEnumerator Boss4()
    {
        for (int i = 0; i < 3; i++)
        {
            Spawn(Random.Range(1, 5), 0.003f);
            yield return new WaitForSeconds(0.6f);
        }
        ShowYourMoves.Play();
        StartCoroutine("Boss4");
    }
    public IEnumerator Boss5()
    {
        for (int i = 0; i < 4; i++)
        {
            Spawn(Random.Range(1, 5), 0.003f);
            yield return new WaitForSeconds(0.5f);
        }
        if (Random.Range(1, 3) == 1)
        {
            arrowcode.MoveLeft();
        }
        else
        {
            arrowcode.MoveRight();
        }
        StartCoroutine("Boss5");
    }
    public IEnumerator Boss6()
    {
        yield return new WaitForSeconds(3.5f);
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                Spawn(Random.Range(1, 5), 0.001f);
                yield return new WaitForSeconds(0.5f);
            }
            arrowcode.ChangeSpeed(0f);
            yield return new WaitForSeconds(0.5f);
            arrowcode.ChangeSpeed(0.001f);
        }
    }
    public IEnumerator Boss7()
    {
        yield return new WaitForSeconds(2f);
        Spawn(1, 0.0007f);
        yield return new WaitForSeconds(14f);
        arrowcode.MoveLeft();
        Spawn(1, 0.02f);
        yield return new WaitForSeconds(0.1f);
        Spawn(2, 0.02f);
        yield return new WaitForSeconds(0.1f);
        Spawn(3, 0.02f);
        yield return new WaitForSeconds(0.1f);
        Spawn(4, 0.02f);
        yield return new WaitForSeconds(3.1f);
        int type = Random.Range(1, 5);
        for (int i = 0; i < 5; i++)
        {
            Spawn(type, 0.02f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {
            type = Random.Range(1, 5);
            for (int j = 0; j < 5; j++)
            {
                Spawn(type, 0.02f);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.1f);

        }
        yield return new WaitForSeconds(2f);
        while (true)
        {
            Spawn(Random.Range(1, 5), 0.02f);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator Boss8()
    {
        for (int i = 0; i < 4; i++)
        {
            Spawn(Random.Range(1, 5), 0.006f);
            Spawn(Random.Range(1, 5), 0.006f);
            yield return new WaitForSeconds(0.6f);
        }
        yield return new WaitForSeconds(1);
        Spawn(Random.Range(1, 5), 0.015f);
        Spawn(Random.Range(1, 5), 0.015f);
        while (true)
        {
            Spawn(Random.Range(1, 5), 0.015f);
            Spawn(Random.Range(1, 5), 0.015f);
            Spawn(Random.Range(1, 5), 0.015f);
            yield return new WaitForSeconds(1f);
        }
    }
    public IEnumerator Boss9()
    {
        Spawn(Random.Range(1, 5), 0.01f);
        yield return new WaitForSeconds(0.45f);
        StartCoroutine("Boss9");
    }
    public void SetMaxEnemyHealth(int health)
    {
        enemyhealthbar.maxValue = health;
        enemyhealthbar.value = health;
    }
    public void DecreaseBossHealth()
    {
        EnemyHealth = EnemyHealth - 1;
        enemyhealthbar.value = EnemyHealth;
    }
    public void StopGame()
    {
        Songs[boss - 1].Stop();
        Destroy(this.gameObject);
    }

        
}

