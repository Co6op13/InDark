using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HP : MonoBehaviour, IHP
{
    [SerializeField] private int currentHP = 1;
    [SerializeField] private int maxHP = 1;

    public int CurrentHP { get => currentHP; }
    public int MaxHP { get => maxHP; }


    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        OnEnable();
    }

    public void TakesDamage(int damage)
    {
        if (currentHP - damage > 0)
        {
            currentHP -= damage;
        }
        else
        {
            currentHP = 0;
            Killed();
        }

    }

    public void TakesHeal(int heal)
    {
        if (currentHP + heal <= maxHP)
        {
            currentHP += heal;
        }
        else
        {
            currentHP = 0;
            currentHP = maxHP;
        }

    }

    virtual protected void Killed()
    {
        gameObject.SetActive(false);
    }
}