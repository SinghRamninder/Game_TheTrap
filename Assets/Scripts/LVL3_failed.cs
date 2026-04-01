using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3_failed : MonoBehaviour
{

    
    public void tryagain()
    {
        LVL3_Time.instance.tryagain();
        PauseMenu.Instance.lvlfailedfalse();
        HealthManager.Instance.Pushatstart();
    }
}
