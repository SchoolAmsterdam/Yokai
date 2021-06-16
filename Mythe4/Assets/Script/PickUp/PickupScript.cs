using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float distance = 1f;
    public Transform equipPostion;
    GameObject currentWeapon;
    int collection;

    bool canGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrab();
        
        if (canGrab) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
                collection++;
                Destroy(currentWeapon, 2);
                Debug.Log(collection);
            }
        }

        else
        {
            canGrab = false;
        }


    }
    private void CheckGrab()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("I can Grab it!");
                currentWeapon = hit.transform.gameObject;
                canGrab = true;
            }
        }
        else
        {
            canGrab = false;
        }
    }
    private void Pickup()
    {
        currentWeapon.transform.position = equipPostion.position;
        currentWeapon.transform.parent = equipPostion;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }
}
