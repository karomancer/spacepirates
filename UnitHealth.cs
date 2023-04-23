using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// KEEPING FOR POSTERITY, DO NOT USE

public class UnitHealth
{
    int _currentHealth;
    int _currentMaxHealth;


    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

     public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // constructor
    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // methods
    public void damageUnit(int damageAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
        }
    }

    public void healUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
