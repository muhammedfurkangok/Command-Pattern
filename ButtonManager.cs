using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scenes
{
    public class ButtonManager
    {
        public Button[] buttons;
        public static ButtonManager Instance; 
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        
        public async void OnAnyButtonClicked()
        {
            
            Deactivate();
            UniTask.WaitForSeconds(2); 
            Activate();;
        }
        
        
        private void Activate()
        {
            foreach(Button button in buttons)
            {
                button.interactable = true;
            }
        }
        
        private void Deactivate()
        {
            foreach(Button button in buttons)
            {
                button.interactable = false;
            }
        }
    }
}