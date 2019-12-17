using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Scene2()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale=1;
    }
    public void Scene1()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale=1;
    }
}
