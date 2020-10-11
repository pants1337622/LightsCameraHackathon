using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public SpriteRenderer rank;
    public Sprite[] ranks;
    // Start is called before the first frame update
    void Start()
    {
        rank = this.GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show(int rating)
    {
        this.gameObject.SetActive(true);
        rank.sprite = ranks[rating - 1];
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
