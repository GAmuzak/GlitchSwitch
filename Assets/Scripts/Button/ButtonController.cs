using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;

    private void OnMouseDown()
    {
        OnInteract();
    }

    public void OnInteract()
    {
        foreach(GateController gate in gates)
            gate.FlipState();
    }
}
