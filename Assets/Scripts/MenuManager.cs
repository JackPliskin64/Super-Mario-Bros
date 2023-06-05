using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel01()
    {
        SceneManager.LoadScene("Level01");
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro");
    }
}
