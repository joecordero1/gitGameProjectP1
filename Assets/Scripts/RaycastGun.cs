using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Se requiere un componente LineRenderer en el objeto que tenga este script.
[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;          // La cámara del jugador.
    public Transform laserOrigin;        // Punto de origen del láser.
    public float gunRange = 50f;         // Alcance del arma.
    public float laserDuration = 0.05f;  // Duración del láser visible.
    public float fireRate = 0.2f;        // Tasa de disparo en segundos.

    float fireTimer;                      // Temporizador para controlar la tasa de disparo.
    private LineRenderer laserLine;       // Componente LineRenderer para dibujar el láser.

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>(); // Obtiene el componente LineRenderer en Awake.
    }

    void Update()
    {
        fireTimer += Time.deltaTime;  // Incrementa el temporizador con el tiempo transcurrido.

        // Si se presiona el botón de disparo y ha pasado suficiente tiempo desde el último disparo.
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;  // Reinicia el temporizador.

            laserLine.SetPosition(0, laserOrigin.position); // Establece el inicio del láser en el punto de origen.

            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            // Realiza un rayo desde el centro de la cámara hacia adelante y verifica si golpea algo.
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);  // Si golpea algo, establece el final del láser en el punto de impacto.
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange)); // Si no golpea nada, establece el final del láser en el alcance máximo.
            }

            StartCoroutine(ShootLaser()); // Inicia la rutina para mostrar el láser durante un tiempo.
        }
    }

    // Rutina para mostrar el láser durante un tiempo y luego ocultarlo.
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;          // Activa la representación del láser.
        yield return new WaitForSeconds(laserDuration); // Espera el tiempo de duración del láser.
        laserLine.enabled = false;         // Desactiva la representación del láser.
    }
}
