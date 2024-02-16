using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;

    public string itemMode = "left";

    public Sprite roboLeft;
    public Sprite roboRight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);

        checkInput();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            die();
        }
        if (collision.gameObject.CompareTag("left"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = roboLeft;
            itemMode = "left";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("right"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = roboRight;
            itemMode = "right";
            Destroy(collision.gameObject);
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
                    break;
                case "right":
                    gameObject.transform.Rotate(new Vector3(0, 0, -90));
                    break;
            }
        }
    }

    private void die()
    {
        gameObject.transform.position = new Vector3(8, -4.5f);
        gameObject.transform.rotation = Quaternion.identity;
        itemMode = "left";
    }
}
