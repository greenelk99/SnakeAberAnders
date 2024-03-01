using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] string itemName;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerScript>().changeItemMode(itemName);
        
        die();
    }

    private void die()
    {
        if(itemName != "death")
        {
            Destroy(gameObject);
        }
    }
}
