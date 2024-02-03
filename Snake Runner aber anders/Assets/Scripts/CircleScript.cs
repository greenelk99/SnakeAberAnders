using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField] float speed;

    public string itemMode = "left";
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);

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

    public void changeItemMode(string iMode)
    {
        itemMode = iMode;
    }
}
