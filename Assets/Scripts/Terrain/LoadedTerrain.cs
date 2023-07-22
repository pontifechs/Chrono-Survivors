namespace Terrain
{
    public interface LoadedTerrain
    {
        void LoadArea((int x, int y) min, (int x, int y) max);
    }
}