using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Strategy
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _exitButton;
        private void Start()
        {
            _backButton.OnClickAsObservable().Subscribe(_ =>
            gameObject.SetActive(false));
            _exitButton.OnClickAsObservable().Subscribe(_ =>
            Application.Quit());
        }
    }

}