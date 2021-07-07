using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    //public TextMeshProUGUI youFoundText;
    public GameObject bananaText;
    public GameObject wrenchText;
    public GameObject waterBottleText;
    //public string numba1 = "Banana";
    //public string numba2 = "Wrench";
    //public string numba3 = "Waterbottle";
    public float distance = 1f;
    public Transform equipPostion;
    GameObject currentWeapon;
    RaycastHit hit;
    //int collection;

    bool canGrab;

    // Start is called before the first frame update
    void Start()
    {
        bananaText.SetActive(false);
        wrenchText.SetActive(false);
        waterBottleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrab();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.name == "Banana")
            {
                Pickup();
                Destroy(currentWeapon, 2);
                bananaText.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.name == "Wrench")
            {
                Pickup();
                Destroy(currentWeapon, 2);
                wrenchText.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.name == "Waterbottle")
            {
                Pickup();
                Destroy(currentWeapon, 2);
                waterBottleText.SetActive(true);
            }
        }

        else
        {
            canGrab = false;
        }


    }
    private void CheckGrab()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("I can Grab It!");
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
