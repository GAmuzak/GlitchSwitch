using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;
    [SerializeField] private List<MeshRenderer> wires;
    [SerializeField] private Material Activated;
    [SerializeField] private Material DeActivated;
    

    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();        
    }

    private void OnMouseDown()
    {
        OnInteract();
        buttonAnimator.Play("ButtonPress", -1, 0f);
        AudioManager.PlaySound(Sound.ButtonPress);
    }

    public void OnInteract()
    {
        foreach(GateController gate in gates)
            gate.FlipState();
        if (wires != null)
        {
            StartCoroutine(ChangeWireColor());
        }
    }

    public IEnumerator ChangeWireColor()
    {
        foreach (MeshRenderer wire in wires)
        {
            wire.material = Activated;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (MeshRenderer wire in wires)
        {
            wire.material.color = DeActivated.color;
        }
        
    }
}
