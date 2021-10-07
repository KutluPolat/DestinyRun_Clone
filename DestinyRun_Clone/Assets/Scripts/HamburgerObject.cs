using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerObject : MonoBehaviour
{
    public HamburgerClass hamburger;
    void Start() => hamburger = new HamburgerClass();
}
