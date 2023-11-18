# gitGameProjectP1
#Aplicación de principios y arquitecturas de sistemas hipermedia
# JOE'S RECYCLING GAME
Link del video en Loom:
https://www.loom.com/share/b1e6ea3d6a9443faa4874845f7d37bc8?sid=37620d5c-7e74-4946-9a50-b19643d223fa

https://www.loom.com/share/2737385461134cd099ee9f044ce99ec9?sid=8876fa86-c954-4d81-bdf3-c508dfe67a41
## Game Overview
Desert Recycling Shooter is a first-person shooter game where you navigate through a desert landscape filled with dry trees, cacts, rocks, and various enemies. Your goal is to survive enemy attacks, collect trash from the enemies, and go to the next level, where you should take recyclable materials, and ultimately achieve a high recycling score.

## Features
- **Desert Environment**: A vast desert with an immersive environment that includes enemies and they trash after beign destroyed.
- **Enemies**: Aggressive enemies that will attack when you're in proximity and will chase if you try to escape.
- **Health System**: Start with 100 health points, with each enemy shot deducting 10 points.
- **Ammo Management**: Use ammo to take down enemies; each enemy requires 5 hits to be destroyed.
- **Recycling Mechanic**: Defeated enemies turn into Cola cans, symbolizing trash that can be collected.
- **Levels**: After collecting three cans, move to the next level, a trash-filled world where you could recycle items within a time limit.
- **Continuing Progress**: Recycling points are cumulative across attempts to encourage repeated play and strategy.
- **Scene Management**: Seamlessly switch between the main menu, sample scene, and recycling scene using colliders.
- **Score Saving**: Scores are saved in a JSON file and displayed on-screen.
- **First-Person Shooting**: Engage with enemies using raycast-based shooting mechanics, complete with visual and sound effects.
- **Health and Ammo Pickups**: Scattered throughout the world to replenish your supplies.
- **Enemy AI**: Smart enemies that detect your proximity and engage or pursue you.
- **Animations**: Smooth animations for recycling items like batteries and plastic bottles to make them more noticeable.
- **Sound**: Rich audio experience with background music, movement sounds, and victory sounds.
- **Progressive Destruction**: Enemies shrink in size with each hit, indicating damage.
- **Automatic Generation**: Enemies, health points, ammo, and recyclables are dynamically generated around the game world.

## Game Flow
1. **Main Menu**: Start your adventure and enter your name to track your score.
2. **Desert Scene**: Survive, shoot enemies, and collect cans to recycle.
3. **Recycling Scene**: Within a 20-second timer, grab as many recyclables as you can and deposit them.
4. **Repetition and Progress**: Return to the desert to continue collecting and recycling, aiming for 30 points.
5. **Victory**: Achieve the recycling goal, win the game, and save your score.

### --------------------------------------------
# Programming exclusive Features

## Health and Ammo Pickups
- Players start with a limited supply of ammo and health.
- Each shot fired depletes the ammo count.
- Each shot received from enemies depletes health.
- Ammo and health pickups are scattered throughout the level to resupply.
- Script `RayCastShoot.cs` keeps the bullets, handles the behavior in `Update()`.  
  ### RayCastShoot.cs
  ```csharp
    public class RayCastShoot : MonoBehaviour
    {
        // More code in the .cs
        public int bulletsTotal = 15; // Initial bullets
        public int bulletsLeft; // bullets left
        public int bulletsShot = 0; // shooted bullets

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            bulletsLeft = bulletsTotal;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                // Checks bullets left, if true, manage bullets counter, plays audio, Fire();
                if (bulletsLeft > 0)
                {
                    bulletsLeft--;
                    bulletsShot++;
                    Debug.Log("bulletsLeft = " + bulletsLeft);
                    audioSource.Play();
                    Fire();
                }
                else
                {
                    Debug.Log("You have no bullets left");
                }
            }
        }
        // More code in the .cs
    }

  ```
  ### FirstPersonMovement.cs
  Added parameters for health, and recycling points, and recycled cans.
  ```csharp
    public class FirstPersonMovement : MonoBehaviour
    {
        public string playerName;
        public float speed = 5; // player speed
        public int health = 100;
        public int currentHealth;
        public HealthScript _healthbar;
        public int R_Points;    // cola-cans points.
        public int RecyclingPoints; // recycled objects points
        // More code in the .cs
    }
  ```  
    ### AmmoBoxScript.cs
  Ammonation is a prefab with a collider. `AmmoBoxScript.cs` handles the reload of ammonation in `OnTriggerEnter.cs`
  Updates canvas counter in `Start()` and `Update()`
  ```csharp
  public class AmmoBoxScript : MonoBehaviour
  {
      public RayCastShoot playerShots;
      public TMP_Text CounterBulletsText;   // Texto para mostrar puntos
      void Start()
      {
          CounterBulletsText.SetText("Bullets left: " + playerShots.bulletsLeft);
      }
      void Update()
      {
          CounterBulletsText.SetText("Bullets left: " + playerShots.bulletsLeft);
  
      }
      private void OnTriggerEnter(Collider other)
      {
          if(other.gameObject.tag == "Player"){
              
              playerShots.bulletsLeft += 10;
              
              Debug.Log("Munición aumentada +10: "+playerShots.bulletsLeft);
              Destroy(gameObject);
          }
      }
  }
  ```
  ### plusHealthScript.cs
  Health reloader is a prefab with a collider. `plusHealthScript.cs` handles the reload of health in `OnTriggerEnter.cs`
  Updates canvas health bar in `Start()` and `Update()`
  ```csharp
  public class plusHealthScript : MonoBehaviour
  {
      public FirstPersonMovement playerHealth;
      public HealthScript _healthbar;
      void Start()
      {
          playerHealth = GameObject.FindWithTag("Player").GetComponent<FirstPersonMovement>();
          UpdateHealthBar(); // Actualiza la barra de vida al inicio
      }
      
      void UpdateHealthBar()
      {
          playerHealth.currentHealth = playerHealth.health;
          _healthbar.UpdateHealthbar(playerHealth.health, playerHealth.currentHealth);
      }
      
      private void OnTriggerEnter(Collider other)
      {
          if(other.gameObject.tag == "Player"){
              
              playerHealth.health = 100;
              UpdateHealthBar();
              Destroy(gameObject);
              Debug.Log("Salud restaurada: "+playerHealth.health);
              
          }
      }
  }
  ```


## Levels, scenes and canvas
- The game includes multiple levels with unique challenges and environments.
- Scenes:
      -MainMenu
      -SampleScene
      -RecyclingScene
- Transition between levels is managed by `ScenesManagerScript.cs`.
- each scene is loaded using colliders or buttons in case of MainMenuScene, You Win and Game Over canvas.
### R_PointScript.cs
  handles the next level with `OnTriggerEnter()` 
```csharp
public class R_PointScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    public ScenesManagerScript SceneLoader;
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.R_Points++;
            if(playerPoints.R_Points == 3){
                playerPoints.R_Points = 0;
                SceneLoader.LoadLevel(SceneName);
            }
        }
    }
}
```
- You win and GameOver screens were created with canvas and UI components, both screens work with `GameOverScript.cs`
- This scripts also write the points per player in a json file.
### GameOverScript.cs
```csharp
public class GameOverScript : MonoBehaviour
{
    public RayCastShoot rayCastShootScript;
    public ScenesManagerScript SceneLoader;
    public JsonWritter jsonWritter; // Referencia al script JsonWritter

    public void Setup()
    {
        //Aqui bloqueamos la capacidad de disparar y activamos el cursor para poder usar los botones del canvas.
        gameObject.SetActive(true);
        if (rayCastShootScript != null)
        {
            rayCastShootScript.canShoot = false; // Desactiva la capacidad de disparar
        }

        // Hacer que el cursor sea visible y no esté bloqueado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame() //este metodo está seleccionado por un botón
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.ResetPlayerPoints(); // Restablecer puntos del jugador
        }
        SceneLoader.LoadAgain("SampleScene");
    }

    public void MainMenuGame() //este metodo está seleccionado por un botón
    {
        // Guardar los datos del jugador en el JSON y luego regresar al menú principal
        if (PlayerData.Instance != null)
        {
            jsonWritter.AddPlayerData(PlayerData.Instance.playerName, PlayerData.Instance.playerPoints);
            PlayerData.Instance.ResetPlayerName(); // Restablecer el nombre del jugador
        }
        SceneLoader.LoadAgain("MainMenu");
    }
}
``` 

## Continuing Progress
- Player progress, including collected recyclables and score, persists between level changes.
- `PlayerData.cs` keeps track of points and is not reset until the game is over, ensuring cumulative progress.
### PlayerData.cs
```csharp
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string playerName;
    public int playerPoints;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Método para añadir puntos
    public void AddPoints(int pointsToAdd)
    {
        playerPoints += pointsToAdd;
    }
    public void ResetPlayerPoints()
    {
        playerPoints = 0;
    }
    public void ResetPlayerName()
    {
        playerName = null;
        playerPoints = 0;
    }
}
```

## Enemy AI
- Enemies detect player's proximity and engage in pursuit if the player tries to escape.
- Enemies patroll looking for the player.
- The `enemyFollow.cs` script handles the AI behavior for patrolling, attacking and chasing the player.
### enemyFollow.cs
```csharp
public class enemyFollow : MonoBehaviour
{
    // more code in the cs.

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

    private void Awake()
    {
        myPlayer = GameObject.Find("Player").transform;
        myEnemy = GetComponent<NavMeshAgent>();
    }

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
        // more code in the cs.
    }

    // Se activa cuando la bala del enemigo entra en colisión con el jugador
    private void OnTriggerEnter(Collider other)
    {
        // Si colisiona con el jugador, destruye la bala
        if (other.gameObject.tag == "Player")
        {
            Destroy(bulletObj);
        }
    }

    private void Patroling(){
    //This method manages the enemy's patrolling behavior when the player is not within its sight or attack range.
    //The method first checks if a walk point is set (if(!walkPointSet)). If not, it calls SearchWalkPoint() to find a new random point for patrolling.
        if(!walkPointSet){
            SearchWalkPoint();
        }
        if(walkPointSet){
        //If a walk point is set (if(walkPointSet)), it instructs the enemy's navigation agent (myEnemy) to move towards the walkPoint.
            myEnemy.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() //This method is used to find a new random location for the enemy to patrol to.
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet  = true;
        }
    }

    private void ChasePlayer() //The enemy's navigation agent (myEnemy) is given the player's current position as its destination (myPlayer.position). This makes the enemy move towards the player.
    {
            myEnemy.SetDestination(myPlayer.position);
        }
        
    }
```

## Animations
- Animated objects such as recyclable items and enemy reactions enhance the game's visual feedback.
- Scripts like `RecycledObjScript.cs` and `R_PointScript.cs` manage the collection of this objects to gain points.
### RecycledObjScript.cs
```csharp
public class RecycledObjScript : MonoBehaviour
{
    public FirstPersonMovement playerPoints;
    public int pointsCounter;
    public TMP_Text CounterPointsText;   // Texto para mostrar puntos
    void Start()
    {
        CounterPointsText.SetText("New points: " + playerPoints.RecyclingPoints);
    }
    void Update()
    {
        CounterPointsText.SetText("New points: " + playerPoints.RecyclingPoints);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            playerPoints.RecyclingPoints++;
        }
    }
}

```


## Progressive Destruction
- Enemies react to being hit with visual cues such as scaling down, indicating damage taken.
- The `Shooted.cs` script modifies enemy appearance progressively as they take damage with the ReduceScale() method.
### Shooted.cs
```csharp

public class Shooted : Target
{
    //More code in .cs
    public GameObject R_Point;
    private GameObject newR_Point;

    public void ReduceScale()
    {
        // Método para reducir la escala del objeto.
        transform.localScale *= scaleFactor;
    }

    public override void HandleImpact()
    {
        ReduceScale();  // Llama al método para reducir la escala del objeto.

        // Incrementa el contador de impactos.
        currentImpacts++;

        // Comprueba si se alcanzó el número máximo de impactos.
        if (currentImpacts >= maxImpacts)
        {
            //Instanciar lata de cola justo donde se encuentra el enemigo a destruir
            newR_Point = Instantiate(R_Point, transform.position, transform.rotation);

            Destroy(gameObject);  // Destruye el objeto si se supera el número máximo de impactos.
        }
    }
}

```

## Automatic Generation
- The game world dynamically generates enemies and pickups to maintain a consistent challenge and resource availability.
- `Generator.cs` and `R_Generator.cs` scripts manage the spawning of these game objects throughout the level.
### Generator.cs
```csharp
public class Generador : MonoBehaviour

{

    public GameObject Enemy;
    public GameObject Ammo;
    public GameObject PlusHealth;
    // limits for generator 
    private float minX = 100f;
    private float maxX = 750f;
    private float minY = 1f;
    private float maxY = 2f;
    private float minZ = 150f;
    private float maxZ = 600f;
    // initial cant of objects
    private int InitialCantEnemys = 40;
    private int InitialCantAmmo = 20;
    private int InitialCantPlusHealth = 20;
    
    private int generatedEnemys = 0;
    private int generatedAmmo = 0;
    private int generatedPlusHealth = 0;

    void Start()
    {
        // Initial objects generator
        prefabsGenerator("Enemy", InitialCantEnemys);
        prefabsGenerator("Ammo", InitialCantAmmo);
        prefabsGenerator("PlusHealth", InitialCantPlusHealth);
    }

    public void prefabsGenerator(string prefabObject, int cant) //Bucle de Generación de Objetos
    {
        for (int i = 0; i < cant; i++)
        {
            prefabGenerator(prefabObject);
        }
    }
 
    public void prefabGenerator(string prefabObject) //Creación de Objetos. Asignación de Etiquetas y Limitaciones. Incremento de Contadores
    {
        GameObject newPrefab = null;
        if (prefabObject == "Enemy" && generatedEnemys < 100000)
        {
            newPrefab = Instantiate(Enemy, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            newPrefab.tag = "Enemy";
            generatedEnemys++;
        }
        else if (prefabObject == "Ammo" && generatedAmmo < 100000)
        {
            newPrefab = Instantiate(Ammo, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            newPrefab.tag = "Ammo";
            generatedAmmo++;
        }
        else if (prefabObject == "PlusHealth" && generatedAmmo < 100000)
        {
            newPrefab = Instantiate(PlusHealth, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            newPrefab.tag = "PlusHealth";
            generatedPlusHealth++;
        }
    }
}
```

Each feature is carefully crafted to create an engaging and dynamic gameplay experience. Scripts interact with Unity's physics, audio, and animation systems to bring the desert wasteland and its challenges to life

