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
    private bool _readyToJump = false;
    public bool readyToJump  { get { return _readyToJump; } set { _readyToJump = value; } }
    public float minJump = 0.5f;
    public float maxJump = 2;
    public float upForce = 0;
    public float xForce = 0;
    public float FrogHeight = 2;

    void Start()
    {
        Arigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        /*
        Vector3 offset = new Vector3(0.5f, 0, 0);
        //RaycastHit2D rhit;
        if (Physics2D.Raycast(transform.position + offset, Vector2.down, 1.02f, LayerMask.GetMask("Default")) || Physics2D.Raycast(transform.position - offset, Vector2.down, 1.02f, LayerMask.GetMask("Default")))
        {
            readyToJump = true;
        }
        else if (Physics2D.Raycast(transform.position + offset, Vector2.down, 2f, LayerMask.GetMask("Default")) || Physics2D.Raycast(transform.position - offset, Vector2.down, 2f, LayerMask.GetMask("Default")))
        {
            readyToJump = false;
        }
        */
        //Debug.DrawRay(transform.position + offset, Vector2.down * 40f * 2, Color.black);
    }

    // Update is called once per frame
    void Update()
    {

        //CrossSceneInformation.frogMousePressedPercentage = (mousePressed / maxLoad);
        if (Arigidbody2D.velocity.y < -0.25f)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (!readyToJump || !alive)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            float AngleDeg = jdi.AngleDeg;
            float AngleRad = AngleDeg * Mathf.PI / 180;
            Arigidbody2D.velocity = Vector3.zero;
            Arigidbody2D.AddForce(jdi.Direction * upForce * CrossSceneInformation.frogJumpForce);
            readyToJump = false;
        }

        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Pressed Space!");
            mousePressed = mousePressed + Time.deltaTime;
        }


        if (Input.GetKeyUp(KeyCode.Mouse0) || mousePressed > maxLoad)
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

            mousePressed = mousePressedMin;
            readyToJump = false;
        }*/

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