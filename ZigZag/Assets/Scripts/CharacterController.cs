using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    private bool walkingRight = true;
    public Transform rayStart;
    public GameObject crystalEffect;

    private GameManager gameManager;

    private Animator anim;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("isIdle");
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            Switch();
        }
        
        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position,-transform.up,out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        }
        if (rb.transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void Switch()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal")
        {
            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(collider.gameObject);
            gameManager.IncreaseScore();
        }
    }
}
