using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colorPoints : MonoBehaviour
{
    public Color[] myUsedColors;
    public Rigidbody myPin;
    public Movement ball;
    public Renderer rend;

    private int indexNumber;
    void Start()
    {

        myUsedColors[0] = Color.red;
        myUsedColors[1] = Color.blue;
        myUsedColors[2] = Color.green;
        myUsedColors[3] = Color.yellow;
        myUsedColors[4] = Color.magenta;
        myUsedColors[5] = Color.white;
        myUsedColors[6] = Color.black;
        myUsedColors[7] = Color.cyan;

        rend = GetComponent<Renderer>();
        myPin = GetComponent<Rigidbody>();
        indexNumber = Random.Range(0, 7);
        rend.material.color = myUsedColors[indexNumber];
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (ball.currentColor.Equals(rend.material.color))
            {
                ball.myPoints++;
                ball.myScoreText.text = ball.myPoints.ToString();

                indexNumber = Random.Range(0, 7);
                ball.rend_here.material.color = myUsedColors[indexNumber];
                ball.currentColor = myUsedColors[indexNumber];
            }
            else 
                ball.Death();
        }

    }

}
