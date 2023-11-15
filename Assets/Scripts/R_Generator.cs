using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class R_Generador : MonoBehaviour

{
    public GameObject Battery;
    public GameObject PlasticBottle;

    private float minX = 100f;

    private float maxX = 750f;

    private float minY = 1f;

    private float maxY = 2f;

    private float minZ = 150f;

    private float maxZ = 600f;


    private int InitialCantBattery = 20;
    private int InitialCantPlasticBottle = 20;

 

    private int generatedBatteries = 0;

    private int generatedPlasticBottles = 0;

 

    void Start()

    {

        // Initial cubes and spheres generator
        prefabsGenerator("Battery", InitialCantBattery);
        prefabsGenerator("PlasticBottle", InitialCantPlasticBottle);

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

 

        if (prefabObject == "Battery" && generatedBatteries < 100000)
        {

            newPrefab = Instantiate(Battery, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);

            newPrefab.tag = "Battery";

            generatedBatteries++;

        }
        else if (prefabObject == "PlasticBottle" && generatedPlasticBottles < 100000)
        {

            newPrefab = Instantiate(PlasticBottle, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);

            newPrefab.tag = "PlasticBottle";

            generatedPlasticBottles++;

        }

    }

}