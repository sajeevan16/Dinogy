using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitch : MonoBehaviour
{
    public void sceneswitch() {
        SceneManager.LoadScene(1);
    }
    void Update() {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.Application.Quit();
        }
        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }
}
