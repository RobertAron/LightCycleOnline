﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerInputCommunicator : NetworkBehaviour
{
  BikeMovement bikeMovement;
  [SyncVar] string playerName;

  void Update(){
      if(!isLocalPlayer) return;
      if(Input.GetKeyDown(KeyCode.LeftArrow)) CmdTurnPlayer(true);
      if(Input.GetKeyDown(KeyCode.RightArrow)) CmdTurnPlayer(false);
  }

  [ServerCallback]
  public void SetBike(BikeMovement bikeMovement)
  {
    this.bikeMovement = bikeMovement;
  }


  [Command]
  void CmdTurnPlayer(bool left)
  {
    if (bikeMovement != null) bikeMovement.Turn(left);
  }

  [Command]
  void CmdSetPlayerName(string newPlayerName){
    playerName = newPlayerName;
  }

  public string GetPlayerName(){
    return playerName;
  }


}
