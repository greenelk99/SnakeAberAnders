using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private CounterScript counterScript;
    
    // Start is called before the first frame update
    void Start()
    {
         counterScript = GameObject.Find("Counter").GetComponent<CounterScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        die();
    }

    private void die()
    {
        counterScript.coins++;
        Destroy(gameObject);
    }
}
