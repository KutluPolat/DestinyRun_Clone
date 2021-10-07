using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It increases entrepreneurship.
/// </summary>
public class HamburgerClass : FoodClass
{
    public HamburgerClass() 
    {
        _affectivityToPersonality = +5;
        _isHamburger = true;
    } 
    public void Eat() => GameManager.player.entrepreneurialPersonality += _affectivityToPersonality;
}
