using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPop : MonoBehaviour
{
    private Rigidbody p;
    void Start()
    {
        p = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (p.transform.position.y < 0f)
            Destroy(p);
    }
}
