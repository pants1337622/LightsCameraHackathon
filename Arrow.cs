using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float sp;
    SpriteRenderer spriteRenderer;
    public Color upcolor = new Vector4(1f,0f,0f,1f);
    public Color downcolor = new Vector4(0.2941177f, 0.5137255f, 1f, 1f);
    public Color rightcolor = new Vector4(1f, 1f, 0f, 1f);
    public Color leftcolor = new Vector4(0.007843138f, 1f, 0.1960784f, 1f);
    public bool Canbepressed;
    public KeyCode KeytoPress;
    public Boss bosscode;
    public Character charactercode;
    public GameObject Rank;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.y = this.transform.position.y - sp;
        transform.position = pos;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveRight();
        }
        if (this.gameObject.tag == "Down")
        {
            spriteRenderer.color = downcolor;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if (this.gameObject.tag == "Up")
        {
            spriteRenderer.color = upcolor;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 90;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if (this.gameObject.tag == "Left")
        {
            spriteRenderer.color = leftcolor;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 180;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if (this.gameObject.tag == "Right")
        {
            spriteRenderer.color = rightcolor;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if(Input.GetKey(KeytoPress))
        { 
            if(Canbepressed == true)
            {
                GameObject ranking = Instantiate(Rank);
                Judge rankingcode = ranking.GetComponent<Judge>();
                if (this.gameObject.tag == "Donttouch")
                {
                    charactercode.PlayerDamage();
                    rankingcode.Show(1);
                }
                else
                {
                    bosscode.DecreaseBossHealth();
                    if(Random.Range(1,6) == 1)
                    {
                        rankingcode.Show(3);
                    }
                    else
                    {
                        rankingcode.Show(2);
                    }

                }
                Destroy(this.gameObject);
            }
        }
    }
    public void MoveLeft()
    {
        if(this.gameObject.tag == "Down" || this.gameObject.tag == "Left" || this.gameObject.tag == "Right")
        {

            Vector3 pos = this.transform.position;
            pos.x = this.transform.position.x - 1;
            if(pos.x <= 2)
            {
                pos.x = 2.6f;
            }
            transform.position = pos;
            if(this.gameObject.tag == "Down")
            {
                this.gameObject.tag = "Up";
            }
            if (this.gameObject.tag == "Right")
            {
                this.gameObject.tag = "Down";
            }
            if (this.gameObject.tag == "Left")
            {
                this.gameObject.tag = "Right";
            }
        }
        else if (this.gameObject.tag == "Up")
        {
            Vector3 pos = this.transform.position;
            pos.x = this.transform.position.x + 3;
            if (pos.x >= 6)
            {
                pos.x = 5.6f;
            }
            transform.position = pos;
            this.gameObject.tag = "Left";
        }
    }
    public void MoveRight()
    {
        if (this.gameObject.tag == "Down" || this.gameObject.tag == "Right" || this.gameObject.tag == "Up")
        {
            Vector3 pos = this.transform.position;
            pos.x = this.transform.position.x + 1;
            if(pos.x >= 6)
            {
                pos.x = 5.6f;
            }
            transform.position = pos;
            if (this.gameObject.tag == "Right")
            {
                this.gameObject.tag = "Left";
            }
            if (this.gameObject.tag == "Down")
            {
                this.gameObject.tag = "Right";
            }
            if (this.gameObject.tag == "Up")
            {
                this.gameObject.tag = "Down";
            }
            
        }
        else if(this.gameObject.tag == "Left")
        {
            Vector3 pos = this.transform.position;
            pos.x = this.transform.position.x - 3;
            if (pos.x <= 2)
            {
                pos.x = 2.6f;
            }
            transform.position = pos;
            this.gameObject.tag = "Up";
        }
            
    }
    public void ChangeSpeed(float speed)
    {
        sp = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            Canbepressed = true;
        }
        if(collision.tag == "Despawner")
        {
            charactercode.PlayerDamage();
            GameObject ranking = Instantiate(Rank);
            Judge rankingcode = ranking.GetComponent<Judge>();
            rankingcode.Show(1);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            Canbepressed = true;
        }
        
    }
    public void StopGame()
    {
        Destroy(this.gameObject);
    }
}
