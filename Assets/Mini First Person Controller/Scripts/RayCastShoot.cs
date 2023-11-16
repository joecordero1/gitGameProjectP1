    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class RayCastShoot : MonoBehaviour
    {
        public float range = 50f;  // Alcance del rayo.
        public GameObject effect;  // Efecto visual cuando el rayo impacta.
        public float force = 4;   // Fuerza del impacto.
        private AudioSource audioSource; // Referencia al AudioSource
        public bool canShoot = true; // Controla si el jugador puede disparar
        public GameObject newMuzzleFlash;
        public int bulletsTotal = 15; // Balas totales que el jugador tiene al inicio
        public int bulletsLeft; // Balas restantes que se van gastando
        public int bulletsShot = 0; // Balas disparadas

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            bulletsLeft = bulletsTotal;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                // Verifica si hay balas disponibles antes de disparar
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
                    Debug.Log("No hay más balas disponibles");
                    // Aquí podrías mostrar un mensaje o realizar alguna acción indicando que no hay balas disponibles
                }
                
            }
        }


        private void Fire()
        {
            RaycastHit myHit;

            // Dispara un rayo desde la posición de la cámara en la dirección de la cámara con un alcance determinado.
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out myHit, range))
            {
                // Instancia una bala en el punto de impacto y lo destruye después de un tiempo.
                GameObject _effect = Instantiate(effect, myHit.point, Quaternion.identity);
                
                Destroy(_effect, 0.2f); 

                // Comprueba si el objeto impactado tiene un componente "Target".
                Target target = myHit.collider.GetComponent<Target>();
                if (target != null)
                {
                    GameObject _newMuzzleFlash = Instantiate(newMuzzleFlash, myHit.point, Quaternion.identity);
                    Destroy(_newMuzzleFlash, 0.3f);
                    target.HandleImpact(); // Llama a un método para manejar el impacto en el objeto.
                    
                }
            }
            
        }

        private void OnDrawGizmos()
        {
            // Dibuja un rayo en la escena para visualizar el alcance del disparo.
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range);
        }
    }
