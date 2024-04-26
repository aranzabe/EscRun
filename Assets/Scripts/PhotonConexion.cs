using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConexion : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint;
    private GameObject spawnedPlayerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Usará las settings de nuestro servidor.
    }

    public override void OnConnectedToMaster()
    {
        //Debug.Log("Conectados!!");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("EscRun1",roomOptions,TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //"Network Player" se debe llamar igual que el Empty Object que hay en la jerarquía
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnPoint.position, spawnPoint.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
