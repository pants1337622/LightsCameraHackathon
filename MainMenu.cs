using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int bosstype;
    public Button button;
    public GameObject Text;
    public AudioSource applause;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick()
    {
        this.GetComponentInParent<Canvas>().enabled = false;
        Text.SetActive(true);
        applause.Play();
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Completed(int type)
    {
        if(type == bosstype)
        {
            button.GetComponent<Image>().sprite = sprites[1];
        }
    }
}
