using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour
{
    public void Transition()
    {
        SceneManager.LoadScene(2);
    }

}
