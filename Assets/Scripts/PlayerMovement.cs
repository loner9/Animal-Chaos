using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Vector2 Velocity;
    PlayerInput inputs;
    Rigidbody rb;
    bool isFiring = false;
    [SerializeField] float speed = 0;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firePoint;
    // Start is called before the first frame update

    void Awake()
    {
        inputs = new PlayerInput();

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        inputs.Game.Movement.performed += ctx => Velocity = ctx.ReadValue<Vector2>();
        inputs.Game.Movement.canceled += ctx => Velocity = Vector2.zero;
        inputs.Game.Fire.performed += ctx => Fire();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("Check Velocity "+Velocity.x);
        rb.MovePosition(transform.position + new Vector3(Velocity.x, 0, 0) * Time.fixedDeltaTime * speed);
        ApplyAnimation();
    }

    void ApplyAnimation()
    {
        anim.SetFloat("Xvelocity", Velocity.x);
        if (Velocity.magnitude == 1)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void Fire()
    {
        // StartCoroutine(FireCD());
        // if (!isFiring)
        // {
        // }
        Debug.Log("firing");
        Instantiate(projectile, firePoint.transform.position, projectile.transform.rotation);
    }

    // IEnumerator FireCD(){
    //     isFiring = true;
    //     yield return new WaitForSeconds(1.1f);
    //     isFiring = false;
    // }

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }
}
