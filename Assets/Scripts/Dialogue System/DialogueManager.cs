using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerNameText;
    public Image speakerPortrait;
    public GameObject choicesContainer;
    public Button choicePrefab;
    
    [Header("Typing Effect")]
    public float typingSpeed = 0.02f;
    private Queue<DialogueLine> dialogueQueue;
    private UnityEvent onDialogueEnd;
    private bool isTyping = false;

    [Header("References")]
    public PlayerController playerController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        dialogueQueue = new Queue<DialogueLine>();
    }
    
    private void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }
    
    public void StartDialogue(DialogueData dialogueData, UnityEvent onEnd = null)
    {
        // Stopping Interaction
        if (playerController != null)
        {
            playerController.enabled = false; 
            playerController.DisableMovement();
        } 

        dialogueQueue.Clear();
        foreach (var line in dialogueData.dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }
        
        // Dialogue 
        onDialogueEnd = onEnd;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }
    
    public void DisplayNextLine()
    {
        if (isTyping) return;
        
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        DialogueLine line = dialogueQueue.Dequeue();
        speakerNameText.text = line.speakerName;
        speakerPortrait.sprite = line.characterPortrait;
        
        StopAllCoroutines();
        StartCoroutine(TypeText(line.dialogueText));
        
        if (line.hasChoices && line.choices.Count > 0)
        {
            ShowChoices(line.choices);
        }
        else
        {
            choicesContainer.SetActive(false);
        }
    }
    
    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
    
    private void ShowChoices(List<DialogueChoice> choices)
    {
        choicesContainer.SetActive(true);
        foreach (Transform child in choicesContainer.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (DialogueChoice choice in choices)
        {
            Button choiceButton = Instantiate(choicePrefab, choicesContainer.transform);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choice.nextDialogueIndex));
        }
    }
    
    private void OnChoiceSelected(int nextIndex)
    {
        if (nextIndex == -1)
        {
            EndDialogue();
        }
        else
        {
            DisplayNextLine();
        }
    }
    
    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (playerController != null)
        {
            playerController.enabled = true;
        } 
        onDialogueEnd?.Invoke();
    }
}
