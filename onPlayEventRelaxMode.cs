using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class onPlayEventRelaxMode : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayRelaxMode()
    {
        SceneManager.LoadScene(2);
    }
}
