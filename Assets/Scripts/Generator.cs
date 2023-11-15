using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generador : MonoBehaviour

{

    public GameObject newCube;

    public GameObject newSphere;
    public GameObject Enemy;
    public GameObject Ammo;
    public GameObject PlusHealth;

    private float minX = 100f;

    private float maxX = 750f;

    private float minY = 1f;

    private float maxY = 2f;

    private float minZ = 150f;

    private float maxZ = 600f;

 

    private int InitialCantCubes = 20;

    private int InitialCantSpheres = 20;
    private int InitialCantEnemys = 40;
    private int InitialCantAmmo = 20;
    private int InitialCantPlusHealth = 20;

 

    private int generatedCubes = 0;

    private int generatedSpheres = 0;
    private int generatedEnemys = 0;
    private int generatedAmmo = 0;
    private int generatedPlusHealth = 0;

 

    void Start()

    {

        // Initial cubes and spheres generator

        prefabsGenerator("Cube", InitialCantCubes);
        prefabsGenerator("Sphere", InitialCantSpheres);
        prefabsGenerator("Enemy", InitialCantEnemys);
        prefabsGenerator("Ammo", InitialCantAmmo);
        prefabsGenerator("PlusHealth", InitialCantPlusHealth);

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
        else if (prefabObject == "Enemy" && generatedEnemys < 100000)
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