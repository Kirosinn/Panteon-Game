using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentCharacterScript : MonoBehaviour
{
    //Hız
    public float speed = 6;
    //Animasyon
    private Animator enemyAnim;
    //Hedef
    private Transform target;
    //Oppenent tanımı
    [SerializeField] public Transform oppenent;
    //Başlangıç Yeri
    [SerializeField] public Transform respawnPoint;
    //AI zekası 
    private NavMeshAgent nav;
    //Player
    public Transform player;

    void Start()
    {
        //Bitiş bloğunu hedef alarak ilerleme,animasyon ve yapay zeka
        enemyAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();

    }

    void Update()
    {     
        //haritada belirlenmiş yerlerden gitmesi için komut
        nav.SetDestination(target.position); 
        enemyAnim.SetTrigger("Running");
           
       
    }
    //Engelle temasa geçince başlangıca geri dön.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            oppenent.transform.position = respawnPoint.transform.position;
        }
    }
}
