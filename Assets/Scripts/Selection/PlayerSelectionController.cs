using UnityEngine;

namespace Assets.Scripts.Selection
{
    internal class PlayerSelectionController : MonoBehaviour
    {
        private Character[] players = new Character[2];
        bool gameCanstart;

        public void HandleSelectedCharacterChange(int playerIndex, Character selectedCharacter)
        {
            players[playerIndex] = selectedCharacter;
            CheckPlayersReady();
        }

        public void HandleGamestart()
        {
            if (gameCanstart)
            {
                Debug.Log($"game can start: player1: {players[0].ToString()}, player2: {players[1].ToString()}");
            }
        }

        private void CheckPlayersReady()
        {
            gameCanstart = players[0] != players[1] &&
                           players[0] != Character.None &&
                           players[1] != Character.None;
        }
    }
}
