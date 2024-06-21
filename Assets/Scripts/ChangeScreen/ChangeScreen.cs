using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnChangeScreen : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ChangeScreen()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
