using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         rb.MovePosition(transform.position + new Vector3(0,0,-1) * Time.fixedDeltaTime * speed);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("Food"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }else if (other.gameObject.name == "Player"){

        }
    }
}
