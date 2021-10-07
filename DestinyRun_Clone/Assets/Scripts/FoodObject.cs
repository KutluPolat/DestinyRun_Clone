using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public GameObject[] foods; // 0 = Hamburger, 1 = Doughnut

    public void ReArrangeFoodsAccordingToTargetJob(bool _isPlayerWantsToBeAnOfficer)
    {
        if (_isPlayerWantsToBeAnOfficer)
        {
            if (gameObject.name.Contains("Trap"))
                SetHamburgerActive();

            else
                SetDoughnutActive();
        }
        else // if player wants to be a business woman
        {
            if (gameObject.name.Contains("Trap"))
                SetDoughnutActive();

            else
                SetHamburgerActive();
        }
    }
    private void SetHamburgerActive()
    {
        foods[0].SetActive(true);
        foods[1].SetActive(false);
    }
    private void SetDoughnutActive()
    {
        foods[0].SetActive(false);
        foods[1].SetActive(true);
    }
}
