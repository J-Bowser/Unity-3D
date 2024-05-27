using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //These variables change our movement speed.

    //[SerializeField] float xValue = 0;
    //[SerializeField] float yValue = 0.01f;
    //[SerializeField] float zValue = 0;
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(1,0,0);
        //transform here corresponds to transform in the 
        //game object's Inspector menu
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Use the arrow keys or WASD to move the player.");
        Debug.Log("Avoid colliding into the walls and obstacles.");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.Translate(new Vector3(xValue, 0, zValue));
    }
}
