using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Controller : MonoBehaviour
{
    //Grandezza dei background
    [SerializeField] float tileSize;

    //Array dei background
    Transform[] tiles;
    int leftIndex, rightIndex;
    float lastCameraX;

    Rigidbody rbCamera;
    [SerializeField] float cameraSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rbCamera = GameObject.Find("Main Camera").GetComponent<Rigidbody>();
        lastCameraX = rbCamera.position.x;
        tiles = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            tiles[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = tiles.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        rbCamera.velocity = Vector3.right * cameraSpeed;
        float deltaX = rbCamera.position.x - lastCameraX;
        lastCameraX = rbCamera.position.x;

        if (rbCamera.position.x < (tiles[leftIndex].transform.position.x))
        {
            SwitchLeft();
        }

        if (rbCamera.position.x > (tiles[rightIndex].transform.position.x))
        {
            SwitchRight();
        }
    }

    private void SwitchLeft()
    {
        //Sposto tile a sinistra
        tiles[rightIndex].position = Vector3.right * (tiles[leftIndex].position.x - tileSize);

        //Aggiorno gli indici
        leftIndex = rightIndex;
        rightIndex--;

        //Controllo che l'indice non sfori la size nell'arrey
        if (rightIndex < 0)
        {
            rightIndex = tiles.Length - 1;
        }
    }

    private void SwitchRight()
    {
        tiles[leftIndex].position = Vector3.right * (tiles[rightIndex].position.x + tileSize);

        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == tiles.Length)
        {
            leftIndex = 0;
        }
    }
}
