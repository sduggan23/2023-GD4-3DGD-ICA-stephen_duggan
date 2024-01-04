using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBehaviour : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private bool shouldUpdateNextLine = false;
    private int index;
    void Start()
    {
        // Clear the text component
        textComponent.text = string.Empty;
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    // Coroutine to gradually type out each character of a dialogue line
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            // Display each character
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        // Signal that line typing has finished
        shouldUpdateNextLine = true;
    }
    private void NextLine()
    {
        // Check if there are more dialogue lines
        if (index < lines.Length - 1)
        {
            index++;
            // Clear the text component
            textComponent.text = string.Empty;
            // Start typing the next line
            StartCoroutine(TypeLine());
        }
        else
        {
            // Disable the dialogue behavior when all lines are displayed
            gameObject.SetActive(false);
        }
    }
    public void TriggerNextLine()
    {
        // Check if the next line can be updated
        if (shouldUpdateNextLine)
        {
            UpdateNextLine();
            // Reset the flag to prevent multiple updates
            shouldUpdateNextLine = false;
        }
    }
    private void UpdateNextLine()
    {
        // Check if the current line has finished displaying
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
}