using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int Level;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level"+Level.ToString());
    }
}
