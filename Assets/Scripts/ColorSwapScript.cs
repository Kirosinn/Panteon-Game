using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapScript : MonoBehaviour
{
   
    void Start()
    {

    }
    //Eğer Player bloğa dokunursa blok kırmızı rengi alacaktır.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    
    
}