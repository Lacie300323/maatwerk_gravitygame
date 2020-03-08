using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityIntEvent OnHealthChanged = new UnityIntEvent();
    public UnityEvent OnDeath = new UnityEvent();

    [SerializeField] private int currentHearts;
    [SerializeField] private int maxHearts;

    private void Start()
    {
        currentHearts = maxHearts;
        OnHealthChanged.Invoke(currentHearts);
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;

        if (currentHearts <= 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnHealthChanged.Invoke(currentHearts);
        }
    }

    public void RecoverHealth(int amount)
    {
        TakeDamage(-amount);
    }
}
