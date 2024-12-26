using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerable 
{
    public void ProcessTriggerEntered(Player player);

    public void ProcessTriggerExited(Player player);
}
