using Ability;
using GameplaySettings;
using GameStatement;
using LevelControllers;
using Spawn;
using UnityEngine;
using Utilities;

public class GameInit : MonoBehaviour
{
    [SerializeField] private RoundsData roundsData;
    [SerializeField] private EnemySpawnData enemySpawnData;
    [SerializeField] private BulletSpawnData bulletSpawnData;
    [SerializeField] private AbilitySpawnData abilitySpawnData;
    [SerializeField] private int scoreForKill = 10;
        
    private GameStateController _gameStateController;
    private SimplePool _simplePool;
    private ScreenBound _screenBound;
    private SpawnPlacer _spawnPlacer;
        
    private EnemySpawner _enemySpawner;
    private RoundController _roundController;
    private ScoreController _scoreController;
    private BulletSpawner _bulletSpawner;
    private AbilitySpawner _abilitySpawner;
    private void Awake()
    {
        _gameStateController = new GameStateController();
        _simplePool = new SimplePool();
        _screenBound = new ScreenBound(Camera.main);
        _spawnPlacer = new SpawnPlacer(_screenBound);
            
        _enemySpawner = new EnemySpawner(enemySpawnData, _simplePool);
        _roundController = new RoundController(_enemySpawner, roundsData, _gameStateController);
        _scoreController = new ScoreController(_enemySpawner, scoreForKill);
        _bulletSpawner = new BulletSpawner(bulletSpawnData, _simplePool);
        _abilitySpawner = new AbilitySpawner(abilitySpawnData, _simplePool);
            
           
        SimpleDImple.SimpleDImple.Set<IGameStateController>(_gameStateController);
        SimpleDImple.SimpleDImple.Set<IScreenBound>(_screenBound);
        SimpleDImple.SimpleDImple.Set<ISpawnPlacer>(_spawnPlacer);
        SimpleDImple.SimpleDImple.Set<IEnemySpawner>(_enemySpawner);
        SimpleDImple.SimpleDImple.Set<IRoundController>(_roundController);
        SimpleDImple.SimpleDImple.Set<IScoreController>(_scoreController);
        SimpleDImple.SimpleDImple.Set<IBulletSpawner>(_bulletSpawner);
        SimpleDImple.SimpleDImple.Set<IAbilitySpawner>(_abilitySpawner);
        SimpleDImple.SimpleDImple.Set(abilitySpawnData);
    }
        
    private void Start()
    {
        _gameStateController.SetGameState(GameState.Started);
    }
    private void OnDestroy()
    {
        _roundController.Dispose();
    }
}