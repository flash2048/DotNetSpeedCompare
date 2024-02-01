[MemoryDiagnoser]
[RPlotExporter, RankColumn]
public class StringFormationBenchmark
{
    private string _s1;
    private string _s2;
    private string _s3;
    private string _s4;

    [Params(10, 50, 100)]
    public int N;


    [GlobalSetup]
    public void Setup()
    {
        _s1 = RandomString(N);
        _s2 = RandomString(N);
        _s3 = RandomString(N);
        _s4 = RandomString(N);
    }
    #region 2 variables
    [Benchmark]
    public string StringConcatenation2Variables() => _s1 + _s2;

    [Benchmark]
    public string StringFormat2Variables() => string.Format("{0}{1}", _s1, _s2);

    [Benchmark]
    public string StringInterpolation2Variables() => $"{_s1}{_s2}";
    #endregion

    #region 3 variables
    [Benchmark]
    public string StringConcatenation3Variables() => _s1 + _s2 + _s3;

    [Benchmark]
    public string StringFormat3Variables() => string.Format("{0}{1}{2}", _s1, _s2, _s3);

    [Benchmark]
    public string StringInterpolation3Variables() => $"{_s1}{_s2}{_s3}";
    #endregion

    #region 4 variables
    [Benchmark]
    public string StringConcatenation4Variables() => _s1 + _s2 + _s3 + _s4;

    [Benchmark]
    public string StringFormat4Variables() => string.Format("{0}{1}{2}{3}", _s1, _s2, _s3, _s4);

    [Benchmark]
    public string StringInterpolation4Variables() => $"{_s1}{_s2}{_s3}{_s4}";
    #endregion

    public static string RandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}