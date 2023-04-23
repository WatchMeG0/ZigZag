using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour
{

    private Rigidbody rb;
    private Animator anim;
    private bool walkingRight = true;
    public Transform rayStart;
    public GameObject crystalEffect;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gameStarted");
        }
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit hit;

        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        }
        else
        {
            anim.SetTrigger("NotFallingAnymr");
        }
        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }
        
    }
    private void Switch()
    {
        if(!gameManager.gameStarted)
        {
            return;
        }
        walkingRight = !walkingRight;
        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);

        }
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
