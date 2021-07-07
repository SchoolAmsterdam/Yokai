using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        StartCoroutine(ending());
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(seconds);
        thePlayer.SetActive(true);
        cutsceneCam.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
