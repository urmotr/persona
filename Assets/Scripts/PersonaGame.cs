using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonaGame : MonoBehaviour
{

    public void ChangeScene(string target)
    {
        SceneManager.LoadScene(target);
    }
}
