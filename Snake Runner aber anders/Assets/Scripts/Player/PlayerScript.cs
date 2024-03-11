using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float stepSpeed;

    public string itemMode = "left";

    public Sprite roboLeft;
    public Sprite roboRight;
    private Grid grid;
    private float gridY;

    private bool canUseItem = false;
    private bool canMove = true;
    private bool isinvulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        gridY = grid.cellSize.y;
        InvokeRepeating("Movement", stepSpeed, stepSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
    }

    void Movement()
    {
        //gameObject.transform.Translate(new Vector3(0, 1, 0) * stepSize);
        if (canMove)
        {
            gameObject.transform.Translate(new Vector3(0, gridY, 0));
        }
        canUseItem = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            canMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (collision.gameObject.CompareTag("indestructible"))
        {
            itemMode = "indestructible";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("death") && !isinvulnerable)
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
        if (Input.GetKeyDown(KeyCode.Space) && canUseItem)
        {
            switch (itemMode)
            {
                case "left":
                    gameObject.transform.Rotate(new Vector3(0, 0, 90));
                    break;
                case "right":
                    gameObject.transform.Rotate(new Vector3(0, 0, -90));
                    break;
                case "indestructible":
                    isinvulnerable = !isinvulnerable;

                    if (isinvulnerable)
                    {
                        //hier soll der Sprite gewechselt werden
                    }
                    break;
            }
            canUseItem = false;
        }
    }

    private void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameObject.transform.position = new Vector3(8, -4.0f);
        //gameObject.transform.rotation = Quaternion.identity;
        //itemMode = "left";
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = roboLeft;
    }
}
