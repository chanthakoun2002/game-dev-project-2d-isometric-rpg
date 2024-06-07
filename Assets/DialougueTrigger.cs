using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    private bool isPlayerInRange;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.I))
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.instance.DisplayNextSentence();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            DialogueManager.instance.ShowInteractIcon();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            DialogueManager.instance.HideInteractIcon();
            DialogueManager.instance.HideDialogue();
        }
    }
}
