using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerGridMovement : MonoBehaviour
{
    [SerializeField] private float timeToMove = 0.5f;
    
    private bool isMoving;
    private Vector3 origPos, targetPos;
    

    public string itemMode = "left";

    public Sprite roboLeft;
    public Sprite roboRight;



    void Update()
    {
        checkInput();
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
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


        if (!isMoving)
        {
            StartCoroutine(MovePlayer(transform.up));
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (itemMode)
            {
                case "left":
                    transform.Rotate(new Vector3(0, 0, 90));
                    break;
                case "right":
                    transform.Rotate(new Vector3(0, 0, -90));
                    break;
            }
        }
    }

    private void die()
    {
        gameObject.transform.position = new Vector3(8, -4f);
        gameObject.transform.rotation = Quaternion.identity;
        itemMode = "left";
    }
}
