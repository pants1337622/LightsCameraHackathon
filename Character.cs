using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Sprite[] CharacterSprites;
    public Sprite[] EndingSprites;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer screenspriteRenderer;
    public Slider healthbar;
    public int Health;
    public GameObject Screen;
    public Arrow arrowcode;
    public MainMenu mainmenuscript;
    public Boss bosscode;
    public AudioSource[] Endsongs;
    // Start is called before the first frame update
    void Start()
    {
        screenspriteRenderer = Screen.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        SetMaxPlayerHealth(100);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            spriteRenderer.sprite = CharacterSprites[1];
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = CharacterSprites[2];
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = CharacterSprites[3];
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = CharacterSprites[4];
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = CharacterSprites[5];
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = CharacterSprites[6];
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = CharacterSprites[7];
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = CharacterSprites[8];
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = CharacterSprites[9];
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = CharacterSprites[10];
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = CharacterSprites[11];
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = CharacterSprites[12];
            }
        }
        else
        {
            spriteRenderer.sprite = CharacterSprites[0];
        }
        if(Health <= 0)
        {
            arrowcode.StopAllCoroutines();
            arrowcode.StopGame();
            bosscode.StopAllCoroutines();
            bosscode.StopGame();
            spriteRenderer.sprite = CharacterSprites[13];
            Endsongs[1].Play();
            screenspriteRenderer.sprite = EndingSprites[0];
            Screen.SetActive(true);
            StartCoroutine("ChangeScene");
        }

    }
    public void PlayerDamage()
    {
        spriteRenderer.sprite = CharacterSprites[13];
        Health = Health - 3;
        healthbar.value = Health;
    }
    public void SetMaxPlayerHealth(int health)
    {
        healthbar.maxValue = health;
        healthbar.value = health;
    }
    public void GameWin()
    {
        arrowcode.StopAllCoroutines();
        arrowcode.StopGame();
        bosscode.StopAllCoroutines();
        bosscode.StopGame();
        spriteRenderer.sprite = CharacterSprites[14];
        Endsongs[1].Play();
        screenspriteRenderer.sprite = EndingSprites[1];
        Screen.SetActive(true);
        mainmenuscript.Completed(bosscode.boss);
        StartCoroutine("ChangeScene");
        
    }
    public IEnumerator ChangeScene()
    {
        while (!Input.GetMouseButton(0))
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
