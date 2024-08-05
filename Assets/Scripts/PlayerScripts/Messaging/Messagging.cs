using System.Collections;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Messagging : NetworkBehaviour
{
    [SerializeField] private TMP_Text _text;

    private MainInputActions _actions;
    
    public void Construct(MainInputActions actions)
    {
        print("Messaging Construct");
        _actions = actions;
        _actions.Movement.Help.performed += NeedHelp;
    }
    
    private void NeedHelp(InputAction.CallbackContext context)
    {
        StartCoroutine(MessageTimer("Need help!"));
    }
    
    
    private IEnumerator MessageTimer(string message)
    {
        print("TEXTING");
        Rpc_SetText(message);
        yield return new WaitForSeconds(1);
        Rpc_SetText("");
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void Rpc_SetText(string text)
    {
        _text.text = text;
    }
}
