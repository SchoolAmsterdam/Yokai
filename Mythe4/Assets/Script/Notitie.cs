using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notitie : MonoBehaviour
{
    public GameObject wholeNotitie;
    public bool onCheck;
    // Start is called before the first frame update
    void Start()
    {
        wholeNotitie.SetActive(false);
        onCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && onCheck == false)
        {
            wholeNotitie.SetActive(true);
            onCheck = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.I) && onCheck == true)
        {
            wholeNotitie.SetActive(false);
            onCheck = false;
            Time.timeScale = 1f;
        }
    }
}
