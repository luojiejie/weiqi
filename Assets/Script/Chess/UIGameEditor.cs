using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChessGame
{
    public class UIGameEditor : UIBehaviour
    {
        [SerializeField] private ChessBoard ChessBoard;
        [SerializeField] private Toggle WhiteToggle;
        [SerializeField] private Toggle BlackToggle;
        [SerializeField] private Button EatButton;
        [SerializeField] private Button RestartButton;
        

        protected override void Start()
        {
            base.Start();
            WhiteToggle.onValueChanged.AddListener(OnWhiteToggleChanged);
            BlackToggle.onValueChanged.AddListener(OnBlackToggleChanged);
            EatButton.onClick.AddListener(OnEatButtonClicked);
            RestartButton.onClick.AddListener(OnRestartButtonClicned);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void OnWhiteToggleChanged(bool value)
        {
            ChessMgr.Instance.Turn = ETurn.White;
        }

        private void OnBlackToggleChanged(bool value)
        {
            ChessMgr.Instance.Turn = ETurn.Black;
        }

        private void OnEatButtonClicked()
        {
            ChessBoard.TryEat();
        }

        private void OnRestartButtonClicned()
        {
            ChessBoard.OnRestart();
        }
    }
}