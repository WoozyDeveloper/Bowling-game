using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControll : MonoBehaviour
{
    public float changingSeconds;
    Light myLight;
    public Color color0;
    public Color color1;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, changingSeconds) / changingSeconds;
        myLight.color = Color.Lerp(color0, color1, t);
    }
}
