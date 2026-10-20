using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Atributos
    [SerializeField] private GameObject creditos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Creditos()
    {
        creditos.SetActive(true);

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Volver()
    {
        creditos.SetActive(false);
    }
}
