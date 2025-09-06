using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public GameObject barrelPrefab;
    public int barrelCount = 5;
    private List<GameObject> allBarrels = new List<GameObject>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        if (spawnPoints.Count == 0) return;
        if(barrelCount > spawnPoints.Count)
        {
            barrelCount = spawnPoints.Count;
        }
        bool isPrefabWithRB = barrelPrefab.GetComponent<Rigidbody>() != null;
        if(!isPrefabWithRB)
        {
            barrelPrefab.AddComponent<Rigidbody>();
        }
        for (int i = 0; i < barrelCount; i++)
        {
            GameObject barrel = Instantiate(barrelPrefab, spawnPoints[i].position, Quaternion.identity);
            //barrel.transform.position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 10f), Random.Range(-50f, 50f));
            barrel.name = "Barrel_" + i;
            barrel.GetComponent<Rigidbody>().mass = Random.Range(0.5f, 0.6f);
            //barrel.AddComponent<BarrelBehavior>();
            allBarrels.Add(barrel);
        }
    }

    //void Update()
    //{
    //    for (int i = 0; i < allBarrels.Count; i++)
    //    {
    //        //GameObject b = allBarrels[i];

    //        //// Unnecessary per-frame tag check
    //        //if (b.tag != "Untagged")
    //        //    Debug.Log("Still tagged");

    //        //// Constantly re-finding components
    //        //Rigidbody rb = b.GetComponent<Rigidbody>();
    //        //if (rb == null)
    //        //{
    //        //    rb = b.AddComponent<Rigidbody>();
    //        //    rb.mass = Random.Range(0.5f, 5f);
    //        //}

    //        // Random rotation every frame = no batching
    //        allBarrels[i].transform.Rotate(Vector3.up * Random.Range(0.1f, 10f));
    //    }
    //}
}