using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // näkyy vain editorissa
        Application.Quit();      // sulkee pelin, kun build on käynnissä
    }

    public void PlayGame()
    {
        // Vaihda tämän nimen tilalle oman peliscenesi nimi
        SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
