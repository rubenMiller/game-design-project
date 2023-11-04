using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    // Start is called before the first frame update

    public JumpDirectionIndicator jdi;
    public bool alive = true;
    private Rigidbody2D Arigidbody2D;
    private float spacePressed = 0.5f;
    public bool readyToJump = false;
    public float maxLoad = 2;
    public float upForce = 200;
    public float xForce = 70;

    void Start()
    {
        Arigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //RaycastHit2D rhit;
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.52f, LayerMask.GetMask("Default")))
        {
            readyToJump = true;
        }
        else if (Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Default")))
        {
            readyToJump = false;
        }

        Debug.DrawRay(transform.position, Vector2.down * 0.52f, Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        if (Arigidbody2D.velocity.y < -0.25f)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (!readyToJump || !alive)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed Space!");
            spacePressed = spacePressed + Time.deltaTime;
        }


        if (Input.GetKeyUp(KeyCode.Space) && spacePressed > 0 || spacePressed > 2)
        {

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Debug.Log("Jump! " + spacePressed);

            if (jdi)
                Debug.Log("Exists");
            else
                Debug.Log("Nope");


            float AngleDeg = jdi.AngleDeg;
            float AngleRad = AngleDeg * Mathf.PI / 180;
            Debug.Log("Jump " + AngleRad);
            Arigidbody2D.velocity = Vector3.zero;
            //Arigidbody2D.AddForce(new Vector3(xForce * AngleRad, upForce * spacePressed, 0));
            Arigidbody2D.AddForce(jdi.Direction * upForce * spacePressed);

            spacePressed = 0.5f;
            readyToJump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Danger"))
        {
            alive = false;
            //GetComponent<SpriteRenderer>().enabled = false;
            //jdi.GetComponentInChildren<SpriteRenderer>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Debug.Log("Collission detected!");
        //readToJump = true;
    }

    public void AddJump()
    {
        Debug.Log("Additional Jump");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Arigidbody2D.velocity = Vector3.zero;
        readyToJump = true;
    }

}