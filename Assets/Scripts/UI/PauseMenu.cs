using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles pause menu and it buttons. When active, time is stopped.
/// It can be toggled by pressing the escape key.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// GameObject with the pause menu to use
    /// </summary>
    [SerializeField] public GameObject pauseMenu;
    
    /// <summary>
    /// Opens the pause menu and stop time
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Go back to the TitleScreen. Resumes time.
    /// </summary>
    public void Home()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
    
    /// <summary>
    /// Close the pause menu and resume time.
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (pauseMenu.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
