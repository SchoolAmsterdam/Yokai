using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public bool checkBool;

    public GameObject dialogStuff;
    PlayerMovement playerMovementScript;
    AdvancedMovement advancedMovementSpeed;
    //public Animator textDisplayAnim;
    //private AudioSource source;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        advancedMovementSpeed = GetComponent<AdvancedMovement>();
        //source = GetComponent<AudioSource>();

        dialogStuff.SetActive(false);
        checkBool = false;
        dialogStuff.SetActive(false);
    }
    void Update()
    {

        if (checkBool == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && textDisplay.text == sentences[index])
            {
                NextSentence();
                dialogStuff.SetActive(true);
                
            }
            else if (index == 5)
            {
                dialogStuff.SetActive(false);
                playerMovementScript.speed = 2.6f;
                advancedMovementSpeed.speedBoost = 1.2f;
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        //source.Play();
        //textDisplayAnim.SetTrigger("Change");
        dialogStuff.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            dialogStuff.SetActive(false);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {

            checkBool = true;
            dialogStuff.SetActive(true);
            playerMovementScript.speed = 0f;
            advancedMovementSpeed.speedBoost = 0f;
            Debug.Log("PlaseHalp");
            StartCoroutine(Type());
        }
        else
        {
            dialogStuff.SetActive(false);
            checkBool = false;
            
        }
    }
}
