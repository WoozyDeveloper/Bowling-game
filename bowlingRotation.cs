using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingRotation : MonoBehaviour
{
    private const float XAxeRotation = 167f;
    private float YAxeRotation, ZAxeRotation;
    public Rigidbody myBall;

    void Start()
    {
        #region Init
        YAxeRotation = 0f;
        ZAxeRotation = 0f;
        #endregion

        myBall = GetComponent<Rigidbody>();
    }

    void Update()
    {
        YAxeRotation++;
        if (YAxeRotation == 360f)
           YAxeRotation = 0f;
        myBall.transform.rotation = Quaternion.Euler(XAxeRotation, YAxeRotation, ZAxeRotation);
    }
}
