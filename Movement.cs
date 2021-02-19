using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 lastPos;
    public Color currentColor;
    public int myPoints, highscore;
    private static float left_limit = -0.8f;
    private static float right_limit = 3.9f;
    private float pinSpawnerValue = 10f;
    public Text myScoreText;


    public int cont, tunnels, myIndex;
    public GameObject myTunnel;
    private bool tapDirection;
    private float direction;
    public Rigidbody myCamera;
    public Rigidbody bowlingBall;
    public Renderer rend_here;

    public Rigidbody pin1;
    public Color red, blue, green, yellow, magenta, white, black, cyan;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ForAudio", 1);
        highscore = PlayerPrefs.GetInt("player_highscore");
        myPoints = 0;
        Time.timeScale = 0;

        myPoints = 0;

        red = Color.red;
        blue = Color.blue;
        green = Color.green;
        yellow = Color.yellow;
        magenta = Color.magenta;
        white = Color.white;
        black = Color.black;
        cyan = Color.cyan;

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
        rend_here = GetComponent<Renderer>();
        switch (myIndex)
        {
            case 0:
                currentColor = red;
                break;
            case 1:
                currentColor = blue;
                break;
            case 2:
                currentColor = green;
                break;
            case 3:
                currentColor = yellow;
                break;
            case 4:
                currentColor = magenta;
                break;
            case 5:
                currentColor = white;
                break;
            case 6:
                currentColor = black;
                break;
            default:
                currentColor = cyan;
                break;
        }
        rend_here.material.color = currentColor;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Time.timeScale = 1;


        if (bowlingBall.transform.position.x >= pinSpawnerValue)
        {
            pinSpawnerValue += 10f;

            
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

 
        }

        myCamera.transform.position = new Vector3(bowlingBall.transform.position.x - 8f, bowlingBall.transform.position.y + 2f, 1.17373f);

        if (bowlingBall.transform.position.z >= 4f || bowlingBall.transform.position.z <= -0.7533333f)
            Death();

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

    #region functions


    //TODO add sound onHit();
    public void Death()
    {

        Time.timeScale = 0;
        System.Threading.Thread.Sleep(1000);

        if (myPoints > highscore)
            highscore = myPoints;

        PlayerPrefs.SetInt("player_highscore", highscore);
        PlayerPrefs.SetInt("player_score", myPoints);


        SceneManager.LoadScene(0);
    }


    private float myXPosition(Rigidbody obj)
    {
        return obj.transform.position.x;
    }
    #endregion
}
