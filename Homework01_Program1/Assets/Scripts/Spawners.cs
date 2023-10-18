using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawners : MonoBehaviour
{
    private float timePassed;
    private int counter;
    private int bugRarity;
    public GameObject[] bugs;
    public GameObject[] bugLocations;
    public GameObject coin;
    public GameObject[] collectables;
    public GameObject[] collectLocations;
    public GameObject platform;
    public GameObject[] platformLocations;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        timePassed = 0f;
        bugRarity = 4;

        spawnPlatforms();
        spawnBugs();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > 2.5f)
        {
            Debug.Log("2.5 seconds passed");

            spawnerControl();

            timePassed = 0f;
        }

    }

    public void spawnBugs()
    {
        int spawn;
        int randomIndex;
        GameObject spawnedBug;

        //for each spawn location
        for(int i = 0; i < bugLocations.Length; i++)
        {
            //decide to spawn a bug here or not
            spawn = Random.Range(0, bugRarity);

            if(spawn == 0)
            {
                //picks random bug type
                randomIndex = Random.Range(0, bugs.Length);

                //spawns bug
                spawnedBug = Instantiate(bugs[randomIndex]);

                //place bug at location
                spawnedBug.transform.position = new Vector2(bugLocations[i].transform.position.x, bugLocations[i].transform.position.y);
            }
            
        }
    }

    public void spawnCollectables()
    {

        int randomIndex;
        GameObject spawnedCoin;

        randomIndex = Random.Range(0, collectLocations.Length);

        spawnedCoin = Instantiate(coin);

        spawnedCoin.transform.position = new Vector2(collectLocations[randomIndex].transform.position.x, collectLocations[randomIndex].transform.position.y);
    }

    public void spawnPlatforms()
    {
        int spawn;
        GameObject spawnedPlatform;

        for(int i = 0; i < platformLocations.Length; i++)
        {
            spawn = Random.Range(0, 2);

            if(spawn == 0)
            {
                spawnedPlatform = Instantiate(platform);

                spawnedPlatform.transform.position = new Vector2(platformLocations[i].transform.position.x, platformLocations[i].transform.position.y);
            }
        }
    }

    public void spawnerControl()
    {
        Debug.Log("Trigger Lead Platform");

        counter++;

        //spawn a new layer of platforms/collectables/bugs
        if(counter % 2 == 0)
        {
            spawnBugs();
        }

        spawnPlatforms();

        if(counter % 3 == 0)
        {
            spawnCollectables();
        }

        //increase bugs spawned
        if(counter >= 20)
        {
            bugRarity = 2;
        }

        else if(counter >= 10)
        {
            bugRarity = 3;
        }
        
    }

}
