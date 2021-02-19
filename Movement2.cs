using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public int myPoints;
    private static float left_limit = -0.8f;
    private static float right_limit = 3.9f;
    private float pinSpawnerValue = 10f;

    public Camera myCamera;
    public int cont, tunnels, myIndex;
    public GameObject myTunnel;
    private bool tapDirection;
    private float direction;
    public Rigidbody bowlingBall;

    public Rigidbody pin1;

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("ForAudio", 1);

        Time.timeScale = 0;

        myPoints = 0;


        #region First tunnels
        Instantiate(myTunnel, new Vector3(42.1f, 0.11f, -0.07f), Quaternion.Euler(0, 0, 0));
        Instantiate(myTunnel, new Vector3(22f, 0.11f, -0.07f), Quaternion.Euler(0, 0, 0));
        Instantiate(myTunnel, new Vector3(1.78f, 0.11f, -0.07f), Quaternion.Euler(0, 0, 0));
        #endregion

        cont = 0;
        tunnels = 3;
        bowlingBall = GetComponent<Rigidbody>();
        direction = 2.0f;
        tapDirection = false;

        myIndex = Random.Range(0, 7);
     

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 0)
            Time.timeScale = 1;


        if (bowlingBall.transform.position.x >= pinSpawnerValue)
        {
            pinSpawnerValue += 10f;

            #region First Pins
            float a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            float num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));


            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));

            
            a = Random.Range(pinSpawnerValue - 5f, pinSpawnerValue + 5f);
            num = Random.Range(left_limit, right_limit);
            Instantiate(pin1, new Vector3(a, 5, num), Quaternion.Euler(-90, 0, 0));
            #endregion


        }

        myCamera.transform.position = new Vector3(bowlingBall.transform.position.x - 16f, bowlingBall.transform.position.y + 2f, 1.17373f);

        if (bowlingBall.transform.position.z >= 4f || bowlingBall.transform.position.z <= -0.7533333f)
            Death2();

        #region Movement
        if (Input.GetMouseButtonDown(0))
        {
            tapDirection = !tapDirection;
            switch (tapDirection)
            {
                case false:
                    direction = 2.0f;
                    break;
                default:
                    direction = -2.0f;
                    break;
            }
        }
        bowlingBall.velocity = new Vector3(4f, -0.5f, direction);
        #endregion

        #region Tunnel Spawn
        if (myXPosition(bowlingBall) >= 20f * cont)
        {
            Instantiate(myTunnel, new Vector3(myTunnel.transform.position.x + tunnels * 20f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            tunnels++;

            cont++;
        }
        #endregion
    }


    //TODO add sound onHit();
    #region functions
    public void Death2()
    {

        Time.timeScale = 0;

        SceneManager.LoadScene(0);

    }


    private float myXPosition(Rigidbody obj)
    {
        return obj.transform.position.x;
    }
    #endregion
}
