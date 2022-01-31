using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObsScript : MonoBehaviour
{

    public bool horizontal = true; //Engelin yatay hareketinin tanımlanması
    public float distance = 0.35f; //Engelin hangi mesafe de hareket edeceği
    public float speed = 0.25f; //Engelin hareket hızı
    public float offset = 0; //Engelin başlangıç konumu
    private bool isForward = true; //Hareketi loop a sokmamız için tanımladığımız değer.
    private Vector3 startPos; //Engelin 3 vektörlü pozisyon tanımı

    void Start()
    {
        //Aşşağıda ki yapıda engelin hareket edeceği yönlere doğru pozisyon tanımları bulunmaktadır.

        startPos = transform.position;
        
        if (horizontal)
        {
            transform.position += Vector3.right * offset;
        }
        else
        {
            transform.position += Vector3.forward * offset;
        }
    }

    void Update()
    {


		if (horizontal)
		{
			if (isForward)
			{
				if (transform.position.x < startPos.x + distance)
				{
					transform.position += Vector3.right * Time.deltaTime * speed;
				}
				else
					isForward = false;
			}
			else
			{
				if (transform.position.x > startPos.x)
				{
					transform.position -= Vector3.right * Time.deltaTime * speed;
				}
				else
					isForward = true;
			}
		}
		else
		{
			if (isForward)
			{
				if (transform.position.z < startPos.z + distance)
				{
					transform.position += Vector3.forward * Time.deltaTime * speed;
				}
				else
					isForward = false;
			}
			else
			{
				if (transform.position.z > startPos.z)
				{
					transform.position -= Vector3.forward * Time.deltaTime * speed;
				}
				else
					isForward = true;
			}
		}

	}
}
