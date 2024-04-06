using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ErrorPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text errorText;

        private static ErrorPopup instance;

        private void Start()
        {
            instance = this;
            gameObject.SetActive(false);
        }

        public static void ShowError(string error, float duration = 3f)
        {
            instance.errorText.text = error;
            instance.gameObject.SetActive(true);
            instance.StartCoroutine(instance.DisableIn(duration));
        }

        private IEnumerator DisableIn(float duration)
        {
            yield return new WaitForSeconds(duration);
            gameObject.SetActive(false);
        }
    }
}