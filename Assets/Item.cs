
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

     void Start()
    {
       
    }
     void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + " ‚ªÚG‚µ‚½");
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
