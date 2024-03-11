using Scenes.Scenes;
using UnityEngine;
using UnityEngine.UI;

public class InputManager
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button undoButton;
    [SerializeField] private Button redoButton;
    [SerializeField] private PlayerMovement player;


    #endregion

    #region Private Variables

    private CommandInvoker commandInvoker;

    #endregion

    #endregion
        
    private void Awake()
    {
        commandInvoker = new CommandInvoker();

        upButton.onClick.AddListener(OnUpButtonClick);
        downButton.onClick.AddListener(OnDownButtonClick);
        leftButton.onClick.AddListener(OnLeftButtonClick);
        rightButton.onClick.AddListener(OnRightButtonClick);
        undoButton.onClick.AddListener(OnUndoButtonClick);
        redoButton.onClick.AddListener(OnRedoButtonClick);
    }
    private void RunPlayerCommand(PlayerMovement player, Vector3 movement)
    {
        if (player == null) { return; }

        ICommand command = new MoveCommand(player, movement);
        commandInvoker.ExecuteCommand(command);

        ButtonManager.Instance.OnAnyButtonClicked();
    }
    private void OnLeftButtonClick()
    {
        RunPlayerCommand(player, Vector3.right);
    }
    
    private void OnRightButtonClick()
    {
        RunPlayerCommand(player, Vector3.left);
    }
    private void OnUpButtonClick()
    {
        RunPlayerCommand(player, Vector3.back);
    }
    private void OnDownButtonClick()
    {
        RunPlayerCommand(player, Vector3.forward);
    }
    private void OnUndoButtonClick()
    {
        commandInvoker.UndoCommand();
        ButtonManager.Instance.OnAnyButtonClicked();
    }
    private void OnRedoButtonClick()
    {
        commandInvoker.RedoCommand();
        ButtonManager.Instance.OnAnyButtonClicked();
    }

}