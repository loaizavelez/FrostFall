using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSystem : MonoBehaviour
{
   public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void salir()
    {
        Console.WriteLine("Saliendo del bodrio...");
        Application.Quit();
    }
}
