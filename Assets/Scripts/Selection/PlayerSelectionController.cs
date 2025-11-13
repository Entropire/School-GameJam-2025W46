using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
                PlayerSelectionData.selectedCharacters = players;
                PlayerSelectionData.devices[0] = PlayerInput.GetPlayerByIndex(0)?.devices[0];
                PlayerSelectionData.devices[1] = PlayerInput.GetPlayerByIndex(1)?.devices[0];

                SceneManager.LoadScene("Game");
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
