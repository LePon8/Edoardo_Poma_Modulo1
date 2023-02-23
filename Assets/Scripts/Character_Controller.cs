using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //InputManager = Input orizzontale e verticale
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xMovement, yMovement, 0);

        //Modifico la posizione del rb
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }
}
