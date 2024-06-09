using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject interactCanvas;
    public Button closeButton;
    public float typingSpeed = 0.05f;
    public float sentenceDelay = 1f;

    private Coroutine typingCoroutine;
    private Queue<string> sentences;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        closeButton.onClick.AddListener(EndDialogue);
        sentences = new Queue<string>();
    }

    public void StartDialogue(string[] dialogueLines)
    {
        dialoguePanel.SetActive(true);

        sentences.Clear();
        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(sentence));
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }

    public void ShowInteractIcon()
    {
        interactCanvas.SetActive(true);
    }

    public void HideInteractIcon()
    {
        interactCanvas.SetActive(false);
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(sentenceDelay);
        DisplayNextSentence();
    }
}
