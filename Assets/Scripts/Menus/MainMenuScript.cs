using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject controlsObject;
    public GameObject creditsObject;
    public GameObject exitObject;

    // PLAY
    public void HoverPlay()
    {

    }
    public void NotHoverPlay()
    {

    }
    public void PlayButton()
    {
        //SceneManager();
    }

    // CONTROLS
    public void HoverControls()
    {

    }
    public void NotHoverControls()
    {

    }
    public void ControlsButton()
    {
        mainObject.SetActive(false);
        controlsObject.SetActive(true);
    }

    // CREDITS
    public void HoverCredits()
    {

    }
    public void NotHoverCredits()
    {

    }
    public void CreditsButton()
    {
        mainObject.SetActive(false);
        creditsObject.SetActive(true);
    }

    // BACK
    public void HoverBack()
    {

    }
    public void NotHoverBack()
    {

    }
    public void BackButton()
    {
        mainObject.SetActive(true);
        controlsObject.SetActive(false);
        creditsObject.SetActive(false);
        exitObject.SetActive(false);
    }

    // EXIT
    public void HoverExit()
    {

    }
    public void NotHoverExit()
    {

    }
    public void AskExit()
    {
        mainObject.SetActive(false);
        exitObject.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
