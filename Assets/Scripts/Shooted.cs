using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooted : Target
{
    private float scaleFactor = 0.8f;  // Factor de escala para reducir el tamaño del objeto.
    private int maxImpacts = 5;        // Número máximo de impactos permitidos.
    public int currentImpacts = 0;     // Contador de impactos actuales.
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
            //Instanciar R_Point justo donde se encuentra el gameObject a destruir
            newR_Point = Instantiate(R_Point, transform.position, transform.rotation);

            Destroy(gameObject);  // Destruye el objeto si se supera el número máximo de impactos.
        }
    }

    void Start()
    {
        // Este método se ejecuta al inicio, pero en este caso está vacío.
    }

    void Update()
    {
        // Este método se ejecuta en cada frame, pero en este caso está vacío.
    }
}
