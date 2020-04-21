using System;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{


    #region Photon Callbacks
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();

        SceneManager.LoadScene(0);
    }
    #endregion


    #region Public Methods

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion

    #region Private Methods

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }

        Debug.LogFormat($"PhotonNetwork : Loading Level : {PhotonNetwork.CurrentRoom.PlayerCount}" );
        PhotonNetwork.LoadLevel($"Room for {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    #endregion


    #region Photon Callbacks
    public override void OnPlayerEnteredRoom(Player other)
    {
        base.OnPlayerEnteredRoom(other);
        Debug.LogFormat($"OnPlayerEnteredRoom() {other.NickName}"); //not seen if you are the player connecting

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat($"OnPlayerEnteredRoom IsMasterClient {PhotonNetwork.IsMasterClient}");

            LoadArena();
        }
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        base.OnPlayerLeftRoom(other);
        Debug.LogFormat($"OnPlayerLeftRoom() {other.NickName}"); //see when other disconnects

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat($"OnPlayerLeftRoom IsMasterClient {PhotonNetwork.IsMasterClient}");

            LoadArena();
        }
        
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
