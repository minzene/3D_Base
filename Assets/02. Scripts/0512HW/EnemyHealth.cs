using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 20;

    private int currentHp;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        Debug.Log($"{gameObject.name} 피격 / 현재 HP : {currentHp}");

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}