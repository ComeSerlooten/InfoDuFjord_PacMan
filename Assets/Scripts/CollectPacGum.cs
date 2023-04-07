using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPacGum : MonoBehaviour
{
    
    public int pacGumCollected = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        var name = "";
        
        if (other.gameObject.name == "PacGum")
        {
            name = " PacGum";
            
            Destroy(other.gameObject);
            pacGumCollected++;
        }
        
        Debug.Log("Trigger"+name);
    }
}
