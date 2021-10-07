using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class of foods that affect job choice.
/// </summary>
public abstract class FoodClass
{
    protected float _affectivityToPersonality; 
    protected bool _isDoughnut, _isHamburger;
}
