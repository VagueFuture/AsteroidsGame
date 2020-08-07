using UnityEngine;

public static class DataHolder
{
    private static Lvls_data prefabName;

    public static Lvls_data Prefab
    {
        get
        {
            return prefabName;
        }
        set
        {
            prefabName = value;
        }
    }
}
