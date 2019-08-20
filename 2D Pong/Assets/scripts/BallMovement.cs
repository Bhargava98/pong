using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
   // private float speedX = 5f;
    //private float speedY= 6f;

    public Text leftscore;
    public Text rightscore;
    public Text Score;

    private int Lscore;
    private int Rscore;
    private int score;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-0.7f, 0.7f), 0) * 800 * Time.deltaTime;
        Lscore = 0;
        Rscore = 0;

        rightscore.text = Rscore.ToString();
        leftscore.text = Lscore.ToString();
    }
	
	
	void FixedUpdate ()
    {
		      /*if(Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(speedX, speedY, 0);
        }*/
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Lwall")
        {
            rb.transform.position = Vector3.zero;
            Lscore++;

            if(Lscore==3)
            {
                Score.text = "Right Player won";
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;

            }
            leftscore.text = "Right player:" + Lscore.ToString();
        }
        else if(collision.gameObject.tag == "Rwall")
        {
            rb.transform.position = Vector3.zero;
            Rscore++;
            if(Rscore==3)
            {
                Score.text = "Left Player wins";
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
            }
            rightscore.text = "Left player:" + Rscore.ToString();
            
        }
    }
}
