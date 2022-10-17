// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShoppingState : IState<Character>
// {
//     public void OnEnter(Character character)
//     {
//         Debug.Log("SHOP");
//     }
//     public void OnExecute(Character character)
//     {
//         character.GetAnimationController().PlayDance();

//         if(GameManager.Ins.currentgameState != GameState.ShopSkin)
//         {
//             character.ChangeState(character.idleState);
//         }
//     }

//     public void OnExit(Character character)
//     {

//     }
// }
