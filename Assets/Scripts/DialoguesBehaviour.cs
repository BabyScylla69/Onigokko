using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguesBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDisplayed;
    [SerializeField]
    private string actualString;
    [SerializeField]
    private float typingSpeed;
    [SerializeField]
    private float nextTextWait;

    [SerializeField]
    private int i;

    [SerializeField] bool ChangeText = false;

    Coroutine Display;
    public void GetText(TextMeshProUGUI _text)
    {
        if(finished)
        {
            textDisplayed = _text;
            textDisplayed.text = "";
            textDisplayed.text = actualString;
            textDisplayed.maxVisibleCharacters = 0;
            finished = false;
        }
    }
    // Start is called before the first frame update

    [Header("Debug")]
    public int totalCharacters;
    public int capacity;
    public int counter;
    private int visiblecount;
    [SerializeField]
    private float delaySpeed;
    private bool finished = true;

    [SerializeField]
    private float delayNextText;
    private void Update()
    {
       
       if(textDisplayed != null)
        {
            if (delaySpeed < typingSpeed)
            {
                delaySpeed += Time.deltaTime;
            }
            else
            {
                if (textDisplayed.maxVisibleCharacters < textDisplayed.textInfo.characterCount)
                {
                    textDisplayed.maxVisibleCharacters++;
                }
                else
                {
                    if (delayNextText < nextTextWait)
                    {
                        delayNextText += Time.deltaTime;
                    }
                    else
                    {
                        delayNextText = 0; 
                        ChangeText = true;
                    }
                }
                delaySpeed = 0;
            }
        }
    }

    public void RestartText()
    {
         finished = true;
        ChangeText = false;
    }

    public bool TextFinished()
    {
        return ChangeText;
    }


    private IEnumerator DisplayLetters(string textdis) //Corutina para ir poniendo las letras 1 a 1.
    {
        textDisplayed.text = actualString;

        textDisplayed.maxVisibleCharacters = 0;

        totalCharacters = textDisplayed.textInfo.characterCount;
        counter = 0;
        while (counter < totalCharacters)
        {
            visiblecount = counter % (totalCharacters + 1);
            textDisplayed.maxVisibleCharacters = visiblecount;

            if (visiblecount >= totalCharacters)
                yield return finished = true;
                //yield return new WaitForSeconds(typingSpeed);

            counter += 1;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (i + 1 < capacity)
            i = i + 1;
        yield return new WaitForSeconds(0.05f);
    }
}
