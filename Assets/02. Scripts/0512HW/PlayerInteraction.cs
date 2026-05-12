using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Ray Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private LayerMask interactableLayer;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI promptText;


    private PlayerInput pi;
    private InputAction interact;

    private IInteractable currentInteractable;
    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
        interact = pi.actions.FindAction("Interact", true);

        if (cam == null) cam = Camera.main;
    }

    private void OnEnable()
    {
        interact.performed += HandleInteract;
    }

    private void OnDisable()
    {

        interact.performed -= HandleInteract;
    }

    private void Update()
    {
        CheckInteractable();
    }


    private void CheckInteractable()
    {
        Vector2 _screenCenter = new(Screen.width * 0.5f, Screen.height * 0.5f);

        Ray _ray = cam.ScreenPointToRay(_screenCenter);

        Debug.DrawRay(_ray.origin, _ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(_ray, out RaycastHit hit, interactDistance, interactableLayer, QueryTriggerInteraction.Ignore))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                promptText.text = interactable.GetPromptText();
                promptText.gameObject.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        promptText.gameObject.SetActive(false);

    }

    private void HandleInteract(InputAction.CallbackContext _)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}