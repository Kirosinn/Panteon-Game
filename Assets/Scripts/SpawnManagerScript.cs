using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform respawnPoint;
    private object collision;
    //Başlangıç noktasına döngü
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }
    
}
