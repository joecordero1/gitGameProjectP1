using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;
    public NavMeshAgent myEnemy;
    public Transform myPlayer;
    private GameObject bulletObj; 

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myEnemy.SetDestination(myPlayer.position);
        ShootAtPlayer();
        
    }
    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if(bulletTime > 0){
            return;
        }
        bulletTime = timer;
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(bulletObj);
        }
    }

}