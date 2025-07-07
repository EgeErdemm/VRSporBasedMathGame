using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BaseLevelLoader : MonoBehaviour, ILevelDataProvider , ITileGameObjectProvider
{
    public GameObject[,] tileGrid;
    public LevelData levelData;
    [HideInInspector] public GameObject player;
    protected int gridWidth;
    protected int gridHeight;

    protected abstract GameObject BombTile { get; }
    protected abstract GameObject TilePrefab { get; }
    public abstract Transform GridParent { get; }
    protected abstract float CellSize { get; }
    public abstract RectTransform gridParentRectTransform { get; }//

    protected abstract GameObject buildingBlock { get; }
    MyTouchableBlocks myTouchableBlocks;
    protected Vector3 paddingBlock= new Vector3(0f,0.5f,0.4f);
    LevelData ILevelDataProvider.levelData => levelData;

    public GameObject[,] TileArray => tileGrid;

    protected IEventBus _eventbus;
    private TileEater _tileEater;


    protected abstract void SetTilePosition(GameObject tile, int x, int y);

    public GameObject GetTile(int x, int y)
    {
        return tileGrid[y, x]; // dikkat: [y, x]
    }

    protected virtual void OnEnable()
    {
        _eventbus = EventBus.Instance;
        _tileEater = new TileEater(this,this); // tile and leveldata provider send
    }


    protected virtual void LoadLevel()
    {

        gridWidth = levelData.gridWidth;
        gridHeight = levelData.gridHeight;

        tileGrid = new GameObject[levelData.gridHeight, levelData.gridWidth];

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                int index = y * gridWidth + x;
                int value = levelData.grid[index];

                GameObject tile = Instantiate(TilePrefab); 
                tile.transform.SetParent(GridParent, false);
                SetTilePosition(tile, x, y);
                ITextProvider textProvider = new TextProvider(tile);
                textProvider.SetText(value.ToString());

                GameObject block = Instantiate(buildingBlock);
                Vector3 padding = tile.transform.position + paddingBlock;
                block.transform.position = padding;
                myTouchableBlocks = block.GetComponent<MyTouchableBlocks>();
                if (myTouchableBlocks != null)
                {
                    myTouchableBlocks.InitalizeSC(index, value);
                }
                else
                {
                    Debug.LogWarning($"MyTouchableBlocks component not found on block prefab at index {index}");
                }
                tileGrid[y, x] = tile;
 
            }
        }

    }


    protected void Start()
    {
        LevelStarter();
    }

    public void LevelStarter()
    {
        MakeLevelData();
        LoadLevel();
        _eventbus.Publish(new TargetScoreEvent(levelData.targetScore));

    }



    protected virtual void MakeLevelData()
    {
        levelData = new LevelData();
        levelData.targetScore = Random.Range(45, 100);
        levelData.gridWidth = 6;//Random.Range(4, 10);
        levelData.gridHeight = 6;//Random.Range(4, 10);
        levelData.startX = -1;
        levelData.startY = 0;
        levelData.totalTime = 60;
        int tileCount = levelData.gridHeight * levelData.gridWidth;
        levelData.grid = new int[tileCount];
        for (int i = 0; i < tileCount; i++)
        {
            levelData.grid[i] = Random.Range(1, 15);
        }

    }


}
