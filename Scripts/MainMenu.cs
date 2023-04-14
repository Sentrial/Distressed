using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject fadeIn;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FadeIn());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(FadeOut());
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void SettingsBack()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1.7f);
        fadeIn.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
}
