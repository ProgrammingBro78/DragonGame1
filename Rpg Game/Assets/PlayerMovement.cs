using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float vel = 10f;
    public bool is_on_ground = false;
    public int current_health = 100;
    public GameObject gameoverui;
    public bool is_active = true;
    public bool is_caught = false;
    float original;
    
    public Animator animator;
    public GameObject dialog1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        original = transform.localScale.y;
        animator = GetComponent<Animator>();

        
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.gameObject.tag == "Abe")
                {
                    dialog1.SetActive(true);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


        Interact();
        float Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * vel;
        float Vertical = Input.GetAxis("Vertical") * Time.deltaTime * vel;
        transform.Translate(Horizontal, 0, Vertical);
        Vector3 movment_direction = new Vector3(Horizontal,0,Vertical);

        if (movment_direction != Vector3.zero) {
            animator.SetBool("running", true);
        }else {
            animator.SetBool("running", false);
        }

        if (is_active)
        {

            if (Input.GetKeyDown("space") && is_on_ground)
            {
                rb.AddForce(new Vector3(0,  10f, 0), ForceMode.Impulse);
                is_on_ground = false;
            }
            
            else
            {
               transform.localScale = new Vector3(transform.localScale.x, original, transform.localScale.z);
            }
        }
        

        if (current_health <= 0)
        {
            Time.timeScale = 0f;
            is_active = false;
            gameoverui.SetActive(true);
        }
        

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_on_ground = true;
        }
/*        if (collision.gameObject.tag == "Abe")
        {
            dialog1.SetActive(true);

        }*/
        
    }


    





}
