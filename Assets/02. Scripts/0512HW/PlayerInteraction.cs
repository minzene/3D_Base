using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Ray Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;

    private PlayerInput _pi;
    private InputAction _fire;

    private IInteractable currentInteractable;
    private void Awake()
    {
        _pi = GetComponent<PlayerInput>();
        _fire = _pi.actions.FindAction("Fire", true);

        if (cam == null) cam = Camera.main;
    }

    private void Update()
    {
        CheckInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    private void CheckInteractable()
    {
        Ray ray = new Ray(
            cam.transform.position,
            cam.transform.forward
        );

        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                return;
            }
        }

        currentInteractable = null;
    }
}