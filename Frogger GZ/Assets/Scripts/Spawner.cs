using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float nextTimeToSpawn;
    // float nextTimeToSpawn = 0f;
    [SerializeField]
    private GameObject[] obstacle;
    int i = 0;
    int t = 0;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float[] intervalTime;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnCar", 2f, intervalTime[t]);
    }

    // Update is called once per frame
    void Update()
    {



        //Invoke("SpawnCar", intervalTime[i]);


        //Instantiate()

        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + intervalTime[t-1];
        }
    }

    void SpawnCar ()
    {
        if (i >= obstacle.Length)
        {
            i = 0;
        }
        if (t >= intervalTime.Length)
        {
            t = 0;
        }
        Instantiate(obstacle[i], transform.position, transform.rotation);
        t++;
        i++;

        Debug.Log("time counter " + t);
    }
}
