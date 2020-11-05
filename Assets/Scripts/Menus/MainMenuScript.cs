using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainObject, controlsObject, creditsObject, exitObject, backButton, loadingObject;
    public Slider loadingBar;
    public Text playText, contText, credText, exitText, backText, quitText, loadText;

    // PLAY
    public void HoverPlay()
    {
        Color c = playText.color;
        c.r = 1;
        c.b = 1;
        c.g = 0;
        playText.color = c;
    }
    public void NotHoverPlay()
    {
        Color c = playText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        playText.color = c;
    }
    public void PlayButton()
    {
        StartCoroutine(LoadAsync());
        mainObject.SetActive(false);
        loadingObject.SetActive(true);
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("PlayScene");
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            loadText.text = progress * 100f + "%";
            yield return null;
        }
    }

    // CONTROLS
    public void HoverControls()
    {
        Color c = contText.color;
        c.r = 0;
        c.b = 1;
        c.g = 0;
        contText.color = c;
    }
    public void NotHoverControls()
    {
        Color c = contText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        contText.color = c;
    }
    public void ControlsButton()
    {
        mainObject.SetActive(false);
        controlsObject.SetActive(true);
        backButton.SetActive(true);
    }

    // CREDITS
    public void HoverCredits()
    {
        Color c = credText.color;
        c.r = 0;
        c.b = 0;
        c.g = 1;
        credText.color = c;
    }
    public void NotHoverCredits()
    {
        Color c = credText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        credText.color = c;
    }
    public void CreditsButton()
    {
        mainObject.SetActive(false);
        creditsObject.SetActive(true);
        backButton.SetActive(true);
    }

    // BACK
    public void HoverBack()
    {
        Color c = backText.color;
        c.r = 1;
        c.b = 1;
        c.g = 0;
        backText.color = c;
    }
    public void NotHoverBack()
    {
        Color c = backText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        backText.color = c;
    }
    public void BackButton()
    {
        mainObject.SetActive(true);
        controlsObject.SetActive(false);
        creditsObject.SetActive(false);
        exitObject.SetActive(false);
        backButton.SetActive(false);
    }

    // EXIT
    public void HoverExit()
    {
        Color c = exitText.color;
        c.r = 1;
        c.b = 0;
        c.g = 0;
        exitText.color = c;
    }
    public void NotHoverExit()
    {
        Color c = exitText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        exitText.color = c;
    }

    public void AskExit()
    {
        mainObject.SetActive(false);
        exitObject.SetActive(true);
        backButton.SetActive(true);
    }

    // QUIT
    public void HoverQuit()
    {
        Color c = quitText.color;
        c.r = 1;
        c.b = 0;
        c.g = 0;
        quitText.color = c;
    }
    public void NotHoverQuit()
    {
        Color c = quitText.color;
        c.r = 1;
        c.b = 0;
        c.g = 1;
        quitText.color = c;
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
