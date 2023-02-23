using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    //Velocità del mio player
    [SerializeField] float speed;

    //Limiti entro i quali non potrà muoversi
    [SerializeField] float limits;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Ottengo il rigidbody del mio player
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Limits();
    }

    void Movement()
    {
        //InputManager = Input orizzontale e verticale
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        //Creo un nuovo Vector3 con gli input orizzontali e verticali
        Vector3 movement = new Vector3(xMovement, yMovement, 0);

        //Modifico la posizione del rb
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    void Limits()
    {
        //Se supera i limiti, la posizione rimane uguale al limite
        if(transform.position.y >= limits)
        {
            transform.position = new Vector2(gameObject.transform.position.x, limits);
        }
        else if(gameObject.transform.position.y <= -limits)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -limits);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("Yeppa");
            //Time.timeScale = 0;
        }
    }
}
