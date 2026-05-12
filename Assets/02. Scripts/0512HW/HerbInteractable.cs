using UnityEngine;

public class HerbInteractable : MonoBehaviour, IInteractable
{
    public string GetPromptText()
    {
        return "[E] Gather";
    }

    public void Interact()
    {
        Debug.Log("약초 채집");
    }
}
