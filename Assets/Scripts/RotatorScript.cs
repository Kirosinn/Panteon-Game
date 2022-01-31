using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime / 0.01f,  0f, Space.Self); //Engeli rotasyonla y ekseninde döndürme işlemi
    }
}
