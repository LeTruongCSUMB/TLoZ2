using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoiceScript : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;


    // Start is called before the first frame update
    void Start()
    {
        disableButtons();
    }

    public void enableButtons()
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void disableButtons()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
}
