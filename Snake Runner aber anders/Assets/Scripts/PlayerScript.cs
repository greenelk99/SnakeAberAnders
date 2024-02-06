using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;

    public string itemMode = "left";

    public SpriteRenderer spriteRenderer;
    public Sprite roboLeft;
    public Sprite roboRight;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);

        checkInput();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            die();
        }
    }

    public void changeItemMode(string iMode)
    {
        itemMode = iMode;
    }



    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (itemMode)
            {
                case "left":
                    gameObject.transform.Rotate(new Vector3(0, 0, 90));
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = roboLeft;
                    break;
                case "right":
                    gameObject.transform.Rotate(new Vector3(0, 0, -90));
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = roboRight;
                    break;
            }
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
