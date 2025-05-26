using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class backMenu : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
