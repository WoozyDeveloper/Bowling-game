using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class game2ColorPoints : MonoBehaviour
{
    public Rigidbody myPin;
    public int points = 0;

    private int indexNumber;

    void Start()
    {
        myPin = GetComponent<Rigidbody>();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Death();

    }

    public void Death()
    {
        Time.timeScale = 0;
        System.Threading.Thread.Sleep(1000);

        SceneManager.LoadScene(0);
    }

}
