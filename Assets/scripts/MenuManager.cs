using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void VolverAJugar()
    {
        SceneManager.LoadScene("SampleScene 1"); 
    }

    public void SalirDelJuego()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
