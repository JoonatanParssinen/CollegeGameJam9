using UnityEngine;
using TMPro;

public class TypingTest : MonoBehaviour
{
    public TMP_Text displayText;    // näyttää kirjoitettavan lauseen
    public TMP_Text inputText;      // näyttää kirjoitetun tekstin
    public TMP_Text timerText;      // näyttää ajan
    public GameObject startButton;

    [TextArea]                      // tekee mukavamman tekstikentän Inspectorissa
    public string[] sentences = {
        "Glitch leviää nopeasti, sinun täytyy pysäyttää se ennen yötä.",
        "Kaikki näyttää vääristyneeltä, kuin todellisuus olisi repeämässä rikki.",
        "Älä pysähdy nyt, paikka alkaa sortua ympäriltäsi pian",
        "Jokainen objekti on vaarassa kadota, pysy jatkuvasti liikkeessä.",
        "Kone hurisee oudosti, ehkä se yrittää varoittaa sinua jostain.",
      "Varjot liikkuvat vaikka valoa ei ole, tämä ei ole normaalia"
    };

    public float testTime = 30f;    // sekunteja aikaa

    private string targetWord;
    private int currentIndex = 0;
    private bool isTesting = false;
    private float timeRemaining;

    void Start()
    {
        displayText.text = "";
        inputText.text = "";
        timerText.text = "";
    }

    public void StartTest()
    {
        // Arvotaan satunnainen lause listasta
        targetWord = sentences[Random.Range(0, sentences.Length)];

        startButton.SetActive(false);
        displayText.text = targetWord;
        inputText.text = "";
        currentIndex = 0;
        timeRemaining = testTime;
        isTesting = true;
    }

    void Update()
    {
        if (!isTesting) return;

        // ⏱ Päivitetään jäljellä oleva aika
        timeRemaining -= Time.deltaTime;
        timerText.text = $"Aikaa jäljellä: {timeRemaining:F1}s";

        if (timeRemaining <= 0f)
        {
            isTesting = false;
            Debug.Log("⏰ Aika loppui! Testi epäonnistui.");
            timerText.text = "Aika loppui!";
            startButton.SetActive(true);
            return;
        }

        // 🔤 Tarkistetaan kirjoitus
        foreach (char c in Input.inputString)
        {
            if (currentIndex >= targetWord.Length)
                return;

            if (c == targetWord[currentIndex])
            {
                inputText.text += c;
                currentIndex++;

                if (currentIndex == targetWord.Length)
                {
                    isTesting = false;
                    Debug.Log("✅ Testi läpäisty!");
                    timerText.text = "Onnistuit!";
                    startButton.SetActive(true);
                }
            }
            else
            {
                isTesting = false;
                Debug.Log("❌ Väärin kirjoitettu! Testi epäonnistui.");
                timerText.text = "Väärin kirjoitettu!";
                startButton.SetActive(true);
            }
        }
    }
}
