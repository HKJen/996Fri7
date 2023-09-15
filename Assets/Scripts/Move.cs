using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded;
    Vector3 startPos;
    Animator anim;
    bool slide;
    [SerializeField] GameObject beginAgain;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.position = beginAgain.transform.position;
        startPos = transform.position;
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);

        //jump
        if(isGrounded) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            }
        }

        //respawn
        if(transform.position.y < -10) {
            transform.position = startPos;
        }

        //anims
        if(direction.magnitude > 0) {
            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);

        //slide
        if(slide) {
            rb.AddForce(direction * 0.3f, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision collision) {
        if(collision != null){
            isGrounded = true;
            anim.SetBool("Jump", false);
        }

        if(collision.gameObject.CompareTag("slide")) {
            slide = true;
        }
        else slide = false;
    }

    private void OnCollisionExit(Collision collision) {
        isGrounded = false;
        anim.SetBool("Jump", true);
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("plate")) {
            Destroy(collider.gameObject);
        }

        if(collider.CompareTag("home")) {
            rb.transform.position = beginAgain.transform.position;
            startPos = transform.position;
            Cursor.lockState = CursorLockMode.None;
            GetComponent<Move>().enabled = false;
            GetComponent<Look>().enabled = false;
            SceneManager.LoadScene(1);
        } 

        if(collider.CompareTag("CP")) {
            startPos = transform.position;
        }  
    }
}
