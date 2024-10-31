using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    public event Action onTakeMana;

    Condition mana { get { return uiCondition.mana; } }

    private void Update()
    {
        mana.Add(mana.passiveValue * Time.deltaTime);
    }

    public void ManaHeal(float amount)
    {
        mana.Add(amount);
    }

    public void UseMana(int manaAmount)
    {
        mana.Subtract(manaAmount);
        onTakeMana?.Invoke();
    }
}