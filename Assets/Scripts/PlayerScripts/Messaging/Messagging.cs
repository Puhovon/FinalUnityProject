using System.Collections;
using Fusion;
using TMPro;
using UnityEngine;

public class Messagging
{
    private TMP_Text _text;
    private NetworkBehaviour _behaviour;
    private Coroutine _coroutine;
    private MainInputActions _actions;
    
    public Messagging(NetworkBehaviour behaviour, TMP_Text text)
    {
        _text = text;
        _behaviour = behaviour;
    }

    public void NeedHelp()
    {
        if(_coroutine != null)
        {
            _behaviour.StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = _behaviour.StartCoroutine(MessageTimer("Need help"));
    }
    
    
    private IEnumerator MessageTimer(string message)
    {
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
