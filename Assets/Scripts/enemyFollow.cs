using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    [SerializeField] private float timer = 5; // Tiempo entre disparos
    private float bulletTime; // Controla el tiempo entre disparos
    public GameObject enemyBullet; // Prefab del proyectil del enemigo
    public Transform spawnPoint; // Punto de generación del proyectil
    public float enemySpeed; // Velocidad del proyectil
    public NavMeshAgent myEnemy; // Enemigo
    public Transform myPlayer; // Jugador

    private GameObject bulletObj; // Referencia al proyectil

    public LayerMask whatIsGround, whatIsPlayer; // Máscaras de capas para colisiones

    // Patrullaje
    public Vector3 walkPoint; // Punto al que el enemigo se dirige
    bool walkPointSet; // Indicador de si el punto de patrullaje está establecido
    public float walkPointRange; // Rango de distancia para establecer un nuevo punto de patrullaje

    // Ataque
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start se llama antes del primer cuadro
    private void Awake()
    {
        myPlayer = GameObject.Find("Player").transform;
        myEnemy = GetComponent<NavMeshAgent>();
    }

    // Update se llama una vez por cuadro
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange){
            Patroling();
        }
        if(playerInSightRange && !playerInAttackRange){
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange){
            ShootAtPlayer();
        }
    }

    // Función para disparar al jugador
    void ShootAtPlayer()
    {
        myEnemy.SetDestination(myPlayer.position);
        alreadyAttacked = true;

        // Disminuye el temporizador entre disparos
        bulletTime -= Time.deltaTime;

        // Si aún no es tiempo de disparar, no hace nada
        if (bulletTime > 0)
        {
            return;
        }

        // Reinicia el temporizador para el siguiente disparo
        bulletTime = timer;

        // Instancia un proyectil en el spawnPoint con la rotación actual
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();

        // Aplica una fuerza al proyectil en la dirección del jugador con la velocidad del enemigo
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);

        // Destruye el proyectil después de 5 segundos
        Destroy(bulletObj, 5f);
    }

    // Se activa cuando el objeto entra en colisión con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Si colisiona con el objeto del jugador, destruye el proyectil
        if (other.gameObject.tag == "Player")
        {
            Destroy(bulletObj);
        }
    }

    private void Patroling(){
        if(!walkPointSet){
            SearchWalkPoint();
        }
        if(walkPointSet){
            myEnemy.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet  = true;
        }
    }

    private void ChasePlayer(){
        myEnemy.SetDestination(myPlayer.position);
    }
    
}
