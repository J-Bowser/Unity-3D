using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        //Debug.Log("Bumped into the wall.");
        if(other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.magenta;
            gameObject.tag = "Hit"; //since not other.gameObject.tag, refers to gameObject that this script is applied to (obstacles in this case)
        }
    }
}
