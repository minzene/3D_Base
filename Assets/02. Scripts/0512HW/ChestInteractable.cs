using UnityEngine;

public class ChestInteractable : MonoBehaviour, IInteractable
{
    public string GetPromptText()
    {
        return "[E] Open";
    }

    public void Interact()
    {
        Debug.Log("상자 열기");
    }
}
