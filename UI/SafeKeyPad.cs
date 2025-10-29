using UnityEngine;
using TMPro;

public class SafeKeyPad : MonoBehaviour
{
    public TMP_Text[] codeDigits;
    private int currentDigit = 0;
    private int[] password = new int[4];

    void Start()
    {
        for (int i = 0; i < password.Length; i++)
        {
            password[i] = Random.Range(0, 10);
        }
        Debug.Log(string.Join("", password));
    }

    public void AddDigit(string digit)
    {

        if (currentDigit < 4)
        {
            codeDigits[currentDigit].text = digit;
            currentDigit++;
        }
    }

    public void DeleteLastDigit()
    {
        if (currentDigit > 0)
        {
            currentDigit--;
            codeDigits[currentDigit].text = "";
        }
    }

    public void ClearDigits()
    {
        Debug.Log("Password: " + string.Join("", password));
        for (int i = 0; i < codeDigits.Length; i++)
        {
            codeDigits[i].text = "";
        }
        currentDigit = 0;
    }

    public void EnterDigits()
    {
        string enteredCode = "";
        for (int i = 0; i < codeDigits.Length; i++)
        {
            enteredCode += codeDigits[i].text;
        }

        string passwordStr = string.Join("", password);

        if (enteredCode == passwordStr)
        {
            Debug.Log("Safe Unlocked!");
        }
        else
        {
            Debug.Log("Incorrect Code. Try Again.");
            ClearDigits();
        }
    }
}
