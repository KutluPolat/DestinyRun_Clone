using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    /// <summary>
    /// The profession of the player is determined according to the value of this variable. <br/>
    /// If the value is more than 25, the player will be an entrepreneur. 
    /// If it's less than -25, the player will be an officer.
    /// </summary>
    public float entrepreneurialPersonality { get; set; }

    /// <summary>
    /// 0 = Detective,<br/> 1 = Officer, <br/>2 = New graduate, <br/>3 = Entrepreneur, <br/>4 = BusinessWoman
    /// </summary>
    private readonly List<string> jobs = new List<string>()
    {
        "Detective",      // entrepreneurialPersonality <= -75
        "Officer",        // entrepreneurialPersonality <= -25
        "NewGraduate",    // entrepreneurialPersonality == 0
        "Entrepreneur",   // entrepreneurialPersonality >= 25
        "BusinessWoman"   // entrepreneurialPersonality >= 75
    };
    private string currentJob;

    private void ChooseJob()
    {
        if(entrepreneurialPersonality <= -75)
        {
            currentJob = jobs[0];
        }
        else if(entrepreneurialPersonality <= -25 && entrepreneurialPersonality > -75)
        {
            currentJob = jobs[1];
        }
        else if(entrepreneurialPersonality > -25 && entrepreneurialPersonality < 25)
        {
            currentJob = jobs[2];
        }
        else if(entrepreneurialPersonality >= 25 && entrepreneurialPersonality < 75)
        {
            currentJob = jobs[3];
        }
        else if(entrepreneurialPersonality >= 75)
        {
            currentJob = jobs[4];
        }
    }

    public string GetCurrentJob()
    {
        ChooseJob();
        return currentJob;
    }
}
