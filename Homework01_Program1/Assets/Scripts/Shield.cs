using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bug"))
        {
            Debug.Log("Shield Hit");

            collision.GetComponent<BugAI>().destroyBug();

            gameObject.SetActive(false);
        }
    }
}
