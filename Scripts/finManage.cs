using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour 
{
    public void Transition()
    {   
        SceneManager.LoadScene(2);
    }
}