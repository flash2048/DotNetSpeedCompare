[MemoryDiagnoser]
[RPlotExporter, RankColumn]
public class ArrayListBenchmark
{
    private IEnumerable<int> _list = null!;

    [Params(100, 1000)]
    public int N;


    [GlobalSetup]
    public void Setup()
    {
        _list = CreateEnumerable(N);
    }
    #region Array
    [Benchmark]
    public int[] ToArray() => _list.ToArray();
    #endregion

    #region List
    [Benchmark]
    public List<int> ToList() => _list.ToList();
    #endregion

    public static IEnumerable<int> CreateEnumerable(int length)
    {
        return Enumerable.Range(0, length);
    }
}