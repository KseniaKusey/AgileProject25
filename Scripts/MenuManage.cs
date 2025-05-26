using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuManage : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("SampleScene");
    }
    //public void Exit()
    //{
    //    Application.Quit();
    //}
}
