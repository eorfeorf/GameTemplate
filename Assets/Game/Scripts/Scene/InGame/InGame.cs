using Game.Scripts.GameContext;
using Game.Scripts.GameManager;
using Game.Scripts.Player;
using Game.Scripts.Stage;
using UnityEngine;

[RequireComponent(typeof(NoteLoader))]
public sealed class InGame : SceneBase
{
    [SerializeField] private MeshFilter[] meshFilters;

    private GameContext gameContext;
    private Stage stage;
    private NoteLoader noteLoader;
    
    protected override void Awake()
    {
        base.Awake();

        var gameManager = FindObjectOfType<GameManager>();

        noteLoader = GetComponent<NoteLoader>();
        stage = new Stage(gameManager.GameContext, gameManager.InputEventProvider, noteLoader, meshFilters);
    }

    public override void Initialize()
    {
        
    }

    private async void OnEnable()
    {
        await fader.FadeIn(ct);
    }

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            await fader.FadeOut(ct);
            isEnd = true;
        }
    }
}