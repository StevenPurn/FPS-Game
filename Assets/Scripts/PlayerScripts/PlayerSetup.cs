using UnityEngine.Networking;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    private void Start()
    {
        if(isLocalPlayer == false)
        {
            DisableComponents();
            AssignRemoteLayer();
        }

        RegisterPlayer();
    }

    public void RegisterPlayer()
    {
        string playerId = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = playerId;

    }

    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void DisableComponents()
    {
        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = false;
        }
        Camera.main.enabled = false;
    }
}
