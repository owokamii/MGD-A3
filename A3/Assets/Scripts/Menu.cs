using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlayerController playerController;
    public SwipeController swipeController;
    public Animator cameraAnimator;
    public GameObject mainmenuUI;
    public GameObject gameplayUI;
    public GameObject gameManager;

    public void StartGame()
    {
        gameManager.SetActive(true);
        mainmenuUI.SetActive(false);
        cameraAnimator.SetBool("StartGame", true);
        Invoke("IntroAnimationEnd", 2);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        swipeController.enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        swipeController.enabled = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IntroAnimationEnd()
    {
        gameplayUI.SetActive(true);
        playerController.enabled = true;
        swipeController.enabled = true;
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Button");
    }
}
