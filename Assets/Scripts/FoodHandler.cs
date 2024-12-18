using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(dead());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0,0,1) * Time.fixedDeltaTime * speed);
    }

    IEnumerator dead(){
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Deleted");
        Destroy(gameObject);
    }
}
