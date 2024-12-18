using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = spawn(2f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // StartCoroutine(spawn());
    }

    void spawnBeast(){
        int beastIndex = Random.Range(0, enemies.Length);
        GameObject beast = enemies[beastIndex];
        Vector3 randomPos = new Vector3(Random.Range(pointA.position.x, pointB.position.x), transform.position.y, transform.position.z);
        Instantiate(beast, randomPos, beast.transform.rotation);
    }

    IEnumerator spawn(float time){
        while (true)
        {
            yield return new WaitForSeconds(time);
            print("WaitAndPrint " + Time.time);
            spawnBeast();
        }
    }
}
