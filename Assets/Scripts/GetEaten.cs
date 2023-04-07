using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetPositionAndRotation(new Vector3(5000, 5000, 5000), Quaternion.identity);
    }
}
