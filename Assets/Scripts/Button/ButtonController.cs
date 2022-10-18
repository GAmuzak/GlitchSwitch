using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private List<GateController> gates;
    [SerializeField] private List<MeshRenderer> wires;
    [SerializeField] private Material activatedMaterial;
    [SerializeField] private Material deActivatedMaterial;

    private bool isEnabled = false;
    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        foreach (MeshRenderer wire in wires)
        {
            wire.material = deActivatedMaterial;
        }
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
        Material matToApply = enabled ? activatedMaterial : deActivatedMaterial;
        enabled = !enabled;
        foreach (MeshRenderer wire in wires)
        {
            wire.material = matToApply;
        }
        yield return new WaitForSeconds(1f);

    }
}
