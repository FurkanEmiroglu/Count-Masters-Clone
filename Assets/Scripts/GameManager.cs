using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
}
