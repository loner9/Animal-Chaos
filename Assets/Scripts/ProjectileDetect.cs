using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        GameManager gameManager = gm.GetComponent<GameManager>();
        gameManager.score -= 3;
        Debug.Log("Destroyed");
        Destroy(other.gameObject);
    }
}
