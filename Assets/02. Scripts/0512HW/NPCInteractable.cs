using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    public string GetPromptText()
    {
        return "[E] 대화하기";
    }

    public void Interact()
    {
        Debug.Log("NPC 대화 시작");
    }
}