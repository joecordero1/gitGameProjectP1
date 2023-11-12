using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generador : MonoBehaviour

{

    public GameObject newCube;

    public GameObject newSphere;

    public float minX = 10f;

    public float maxX = 30f;

    public float minY = 1f;

    public float maxY = 5f;

    public float minZ = 10f;

    public float maxZ = 25f;

 

    public int InitialCantCubes = 20;

    public int InitialCantSpheres = 20;

 

    private int generatedCubes = 0;

    private int generatedSpheres = 0;

 

    void Start()

    {

        // Initial cubes and spheres generator

        prefabsGenerator("Cube", InitialCantCubes);

        prefabsGenerator("Sphere", InitialCantSpheres);

    }

 

    public void prefabsGenerator(string prefabObject, int cant)

    {

        for (int i = 0; i < cant; i++)

        {

            prefabGenerator(prefabObject);

        }

    }

 

    public void prefabGenerator(string prefabObject)

    {

        GameObject newPrefab = null;

 

        if (prefabObject == "Cube" && generatedCubes < 100000)

        {

            newPrefab = Instantiate(newCube, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);

            newPrefab.tag = "Cube";

            generatedCubes++;

        }

        else if (prefabObject == "Sphere" && generatedSpheres < 100000)

        {

            newPrefab = Instantiate(newSphere, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);

            newPrefab.tag = "Sphere";

            generatedSpheres++;

        }

    }

}