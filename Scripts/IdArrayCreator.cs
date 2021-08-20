public sealed class IdArrayCreator
{
    public int[] Create(int size)
    {
        int[] ids = CreateIdArray(size);
        ids = ShuffleArray(ids);
        return ids;
    }

    private int[] CreateIdArray(int size)
    {
        int[] ids = new int[size];

        int previousId = -1;
        bool needChangeIdInNextIteration = true;

        for (int i = 0; i < size; i++)
        {
            if (needChangeIdInNextIteration)
            {
                previousId++;
                needChangeIdInNextIteration = false;
            }
            else
            {
                needChangeIdInNextIteration = true;
            }

            ids[i] = previousId;
        }

        return ids;
    }

    private int[] ShuffleArray(int[] ids)
    {
        int[] newArray = ids.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = UnityEngine.Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
}