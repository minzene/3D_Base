using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 1.5f;
    [SerializeField] private int damage = 10;

    [Header("Layer")]
    [SerializeField] private LayerMask enemyLayer;

    private PlayerInput pi;
    private InputAction attackAction;

    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
        attackAction = pi.actions.FindAction("Attack", true);
    }

    private void OnEnable()
    {
        attackAction.performed += HandleAttack;
    }

    private void OnDisable()
    {
        attackAction.performed -= HandleAttack;
    }

    private void HandleAttack(InputAction.CallbackContext _)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(
            attackPoint.position,
            attackRadius,
            enemyLayer
        );

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRadius
        );
    }
}
