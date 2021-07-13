using BayatGames.SaveGameFree;

public class SaveManager
{
    public void Save<T>(string key, T value){
        SaveGame.Save(key, value);
    }

    public T Load<T>(string key){
        return SaveGame.Load<T>(key);
    }
}