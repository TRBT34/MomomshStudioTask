using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(0);
    }
}
