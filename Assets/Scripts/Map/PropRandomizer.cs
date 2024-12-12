using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefaps;
    private bool propsSpawned = false; //fazla prop üretilmemesi için bool kontrolcüsü
    void Start()
    {
        if (!propsSpawned)
        {
            SpawnProps();
            propsSpawned = true;
        }
    }

    void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefaps.Count);
            GameObject prop = Instantiate(propPrefaps[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}
