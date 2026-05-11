using StarterAssets;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private StarterAssetsInputs input;

    private void Awake()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (input.attack)
        {
            animator.SetTrigger("Attack");
            input.attack = false;
        }

        if (input.interact)
        {
            animator.SetTrigger("Interact");
            input.interact = false;
        }
    }
}
