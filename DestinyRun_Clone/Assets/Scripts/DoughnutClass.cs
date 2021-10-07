using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It decreases entrepreneurship.
/// </summary>
public class DoughnutClass : FoodClass
{
    public DoughnutClass()
    {
        _affectivityToPersonality = -5;
        _isDoughnut = true;
    }
    public void Eat() => GameManager.player.entrepreneurialPersonality += _affectivityToPersonality;
}
