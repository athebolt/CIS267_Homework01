using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private int counter;
    private int bugRarity;
    public GameObject[] bugs;
    public GameObject[] bugLocations;
    public GameObject coin;
    public GameObject[] collectables;
    public GameObject[] collectLocations;
    public GameObject platform;
    public GameObject leadPlatform;
    public GameObject leadPlatformLocation;
    public GameObject[] platformLocations;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        bugRarity = 4;

        spawnPlatforms();
        spawnBugs();
    }

    // Update is called once per frame
    void Update()
    {
        //counter += (int)Time.deltaTime;

        //spawnBugs();
        //spawnCollectables();
        //spawnPlatforms();
    }

    public void spawnBugs()
    {
        int spawn;
        int randomIndex;
        GameObject spawnedBug;

        //for each spawn location
        for(int i = 0; i < bugLocations.Length; i++)
        {
            //decide to spawn something here
            spawn = Random.Range(0, bugRarity);

            if(spawn == 0)
            {
                //picks random bug type
                randomIndex = Random.Range(0, bugs.Length);

                //spawns bug
                spawnedBug = Instantiate(bugs[randomIndex].gameObject);

                //place bug at location
                spawnedBug.transform.position = new Vector2(bugLocations[i].transform.position.x, bugLocations[i].transform.position.y);
            }
            
        }
    }

    public void spawnCollectables()
    {
        
    }

    public void spawnPlatforms()
    {
        int spawn;
        GameObject spawnedPlatform;

        spawnedPlatform = Instantiate(platform.gameObject);

        spawnedPlatform.transform.position = new Vector2(leadPlatformLocation.transform.position.x, leadPlatformLocation.transform.position.y);

        for(int i = 0; i < platformLocations.Length; i++)
        {
            spawn = Random.Range(0, 2);

            if(spawn == 0)
            {
                spawnedPlatform = Instantiate(platform.gameObject);

                spawnedPlatform.transform.position = new Vector2(platformLocations[i].transform.position.x, platformLocations[i].transform.position.y);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Trigger Enter");

        if(collision.gameObject.CompareTag("LeadPlatform"))
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
                bugRarity = 1;
            }
            else if(counter >= 10)
            {
                bugRarity = 3;
            }
        }
    }

}
