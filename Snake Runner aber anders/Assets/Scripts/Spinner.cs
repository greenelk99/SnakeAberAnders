using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float xvalue = 0;
    [SerializeField] float yvalue = 1;
    [SerializeField] float zvalue = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xvalue, yvalue, zvalue);
    }
}
