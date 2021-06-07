using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject pausePanel;
    public ItemContainer itemContainer;
    public void Sair()
    {
        Application.Quit();
    }
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
        itemContainer.slots.Clear();
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
