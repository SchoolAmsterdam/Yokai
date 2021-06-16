using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNurikabe : MonoBehaviour
{
    public GameObject Prefab;

    private void Start()
    {
        Prefab.SetActive(false);
    }
    void OnTriggerEnter()
    {
        Prefab.SetActive(true);
    }
}