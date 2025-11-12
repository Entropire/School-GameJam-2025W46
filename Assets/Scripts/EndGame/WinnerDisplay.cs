using TMPro;
using UnityEngine;

namespace Assets.Scripts.EndGame
{
    internal class WinnerDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Start()
        {
            text = GetComponent<TMP_Text>();
            text.text = $"Player {EndGameResult.winner} has won the game!";
        }
    }
}
