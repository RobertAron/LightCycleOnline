﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerInputCommunicator : NetworkBehaviour
{
  BikeMovement bikeMovement;
  [SerializeField] string playerName;

  void Update(){
      if(!isLocalPlayer) return;
      if(Input.GetKeyDown(KeyCode.LeftArrow)) CmdTurnPlayer(true);
      if(Input.GetKeyDown(KeyCode.RightArrow)) CmdTurnPlayer(false);
      if(Input.GetKeyDown(KeyCode.Z)) CmdSetPlayerBoost(true);
      if(Input.GetKeyUp(KeyCode.Z)) CmdSetPlayerBoost(false);

  }

  [ServerCallback]
  public void SetBike(BikeMovement bikeMovement)
  {
    this.bikeMovement = bikeMovement;
  }

  void SetPlayerName(string newName){
    playerName = newName;
    CmdSetPlayerName(playerName);
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

  [Command]
  void CmdSetPlayerBoost(bool boost){
    if (bikeMovement != null)  bikeMovement.SetBoost(boost);
  }

  public string GetPlayerName(){
    return playerName;
  }
}
