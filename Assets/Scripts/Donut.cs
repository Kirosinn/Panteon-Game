using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public float Donutspeed = 3f;
    void Start()
    {

    }


    void Update()
    //X yönünde Donut'ın dönme işlemi
    {
        transform.Rotate(Donutspeed * Time.deltaTime / 0.01f, 0f, 0f, Space.Self); 
    }
}

