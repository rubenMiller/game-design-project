using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    // Start is called before the first frame update

    public JumpDirectionIndicator jdi;
    //public GameOverScreen gameOverScreen;
    public bool alive = true;
    private Rigidbody2D Arigidbody2D;
    private float mousePressed = 0.5f;
    public bool readyToJump = false;
    public float maxLoad = 2;
    public float upForce = 200;
    public float xForce = 70;
    public float FrogHeight = 2;

    void Start()
    {
        Arigidbody2D = GetComponent<Rigidbody2D>();
    }

    /*
    void FixedUpdate()
    {
        //RaycastHit2D rhit;
        if (Physics2D.Raycast(transform.position, Vector2.down, 2 * 0.52f, LayerMask.GetMask("Default")))
        {
            readyToJump = true;
        }
        else if (Physics2D.Raycast(transform.position, Vector2.down, 1f * 2, LayerMask.GetMask("Default")))
        {
            readyToJump = false;
        }

        Debug.DrawRay(transform.position, Vector2.down * 0.52f * 2, Color.black);
    }*/

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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Pressed Space!");
            mousePressed = mousePressed + Time.deltaTime;
        }


        if (Input.GetKeyUp(KeyCode.Mouse0) && mousePressed > 0 || mousePressed > 2)
        {

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Debug.Log("Jump! " + mousePressed);

            if (jdi)
                Debug.Log("Exists");
            else
                Debug.Log("Nope");


            float AngleDeg = jdi.AngleDeg;
            float AngleRad = AngleDeg * Mathf.PI / 180;
            Debug.Log("Jump " + AngleRad);
            Arigidbody2D.velocity = Vector3.zero;
            //Arigidbody2D.AddForce(new Vector3(xForce * AngleRad, upForce * spacePressed, 0));
            Arigidbody2D.AddForce(jdi.Direction * upForce * mousePressed);

            mousePressed = 0.5f;
            readyToJump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        CrossSceneInformation.curentLevel = SceneManager.GetActiveScene().name;
        Debug.Log("Collision with: " + coll.transform.tag);
        if (coll.transform.CompareTag("Danger"))
        {
            alive = false;
            //GetComponent<SpriteRenderer>().enabled = false;
            //jdi.GetComponentInChildren<SpriteRenderer>().enabled = false;

            //gameOverScreen.transform.gameObject.SetActive(true);
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
            Debug.Log("You`re Dead");
          
        }
        if (coll.transform.CompareTag("Ground"))
        {
            readyToJump = true;
        }
        if (coll.transform.CompareTag("Pond"))
        {
            Debug.Log("You WIN!");
            SceneManager.LoadScene("Win");
        }


    }

    public void AddJump()
    {
        Debug.Log("Additional Jump");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Arigidbody2D.velocity = Vector3.zero;
        readyToJump = true;
    }

}