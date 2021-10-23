using UnityEngine;
using System.Collections.Generic;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private List<TriggerObjects> triggerObjects;

    private void OnMouseDown()
    {
        TriggerAction();
    }

    public void TriggerAction()
    {
        foreach (TriggerObjects triggerObject in triggerObjects)
            triggerObject.PerformAction();
    }
}
