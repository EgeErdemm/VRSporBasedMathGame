using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class TileEater 
{

    private ILevelDataProvider _levelDataProvider;
    private ITileGameObjectProvider _tileGameObjectProvider;
    private IEventBus _eventBus;
    

    public TileEater(ILevelDataProvider levelData, ITileGameObjectProvider tileArray)
    {
        _levelDataProvider = levelData;
        _tileGameObjectProvider = tileArray;
        _eventBus = EventBus.Instance;
        Subscribe(); // levelloader create this class "ITileGridProvider"

    }

    public void Subscribe()
    {

    }

    public void EatTileAndChangeText(int x, int z)
    {
        GameObject tile = null; //_tileGridProvider.GetTile(x, -z);
        ITextProvider textProvider = new TextProvider(tile);
        textProvider.SetText("0");
      }

    private void EatData(float x, float z)
    {
        int i =(int)( x + -z * _levelDataProvider.levelData.gridWidth);
        _levelDataProvider.levelData.grid[i] = 0;
    }

    public async void DelayedEatData(float x, float z)
    {
        await Task.Delay(200); // 0.2 saniye gecikme
        EatData(x, z);
    }

}
