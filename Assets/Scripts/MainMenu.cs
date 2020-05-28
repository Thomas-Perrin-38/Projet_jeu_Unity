using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Permet de changer de Scene du menu au jeu
    public void PlayGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Permet de quitter le jeu
    public void QuitGame() {

        Debug.Log("Quit");
        Application.Quit();
    }

}
