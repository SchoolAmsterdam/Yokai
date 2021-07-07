using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchMovement : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedheight;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GoUp();
        }
    }

    void Crouch()
    {
        playerCol.height = reducedheight;

    }
    void GoUp()
    {
        playerCol.height = originalHeight;

    }

}
