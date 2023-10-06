using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu, QuitScreen;
    [SerializeField] AudioSource MainMusic;

    public void Pause()
    {
        PauseMenu.SetActive(true);
        MainMusic.Pause();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        MainMusic.Play();
        Time.timeScale = 1;
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name.Equals("Main Menu"))
            {
                QuitScreen.SetActive(true);
            }
            if (SceneManager.GetActiveScene().name.Equals("Game Scene"))
            {
                Pause();
            }
        }
    }
}
