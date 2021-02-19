using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelDestroy : MonoBehaviour
{ 
    public GameObject myTunnel;

    // Update is called once per frame
    void Update()
    {
        Destroy(myTunnel, 25);
    }
}
