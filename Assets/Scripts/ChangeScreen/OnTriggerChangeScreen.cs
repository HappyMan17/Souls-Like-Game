using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerChangeScreen : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PaladinPlayer")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

    }

}
