using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button exterminateText;
    public Button escapeText;
    public Button exitText;

    // Use this for initialization
    void Start () {
        quitMenu.enabled = false;
	}

    public void ExterminatePress()
    {
        SceneManager.LoadScene("exterminate");
    }

    public void EscapePress()
    {
        SceneManager.LoadScene("escape");
    }

    public void ExitPress ()
    {
        quitMenu.enabled = true;
        exterminateText.enabled = false;
        escapeText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress ()
    {
        quitMenu.enabled = false;
        exterminateText.enabled = true;
        escapeText.enabled = true;
        exitText.enabled = true;
    }

    public void YesPress()
    {
        Application.Quit();
    }

}
