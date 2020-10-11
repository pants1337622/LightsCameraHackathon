using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public MainMenu bosstype;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = sprites[bosstype.bosstype - 1];
    }
}
