using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGum : MonoBehaviour
{
    public bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Collected()
    {
        isCollected = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
