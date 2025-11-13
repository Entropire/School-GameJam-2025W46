using TMPro;
using UnityEngine;

namespace Assets.Scripts.EndGame
{
    internal class WinnerDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Start()
        {
            text.text = $"Player {EndGameResult.winner + 1} has won the game!";
        }
    }
}
