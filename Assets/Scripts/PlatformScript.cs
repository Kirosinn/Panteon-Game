using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate( 0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self); //Engeli rotasyonla z ekseninde döndürme işlemi
    }
}
