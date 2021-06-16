using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject objective;
    public int counter = 4;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(objective, counter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
