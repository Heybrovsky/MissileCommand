using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyBase : MonoBehaviour
{
    private float _basesAlive = 4f;
    public float BaseDestroyed;
    public GameObject EndMenu;
    public GameObject AllyCannon;

    void Update()
    {
        GameStateCheck();
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    private void GameStateCheck()
    {
        if (_basesAlive == BaseDestroyed || !AllyCannon.activeSelf )
        {
            Time.timeScale = 0;
            EndMenu.SetActive(true);
            enabled = false;
        }   
    }
}
