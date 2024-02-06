# **ToArray** vs **ToList**
What function is more effective to make an array or a list?

> The winner: **ToArray** (compared on the **.NET SDK 8.0.101**)

It will compare the IEnumerable of lengths 100 and 1000 integers.

[Look at the code here.](/Arrays/code/ArrayListBenchmark.cs)

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method  | N    | Mean      | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------- |----- |----------:|----------:|----------:|-----:|-------:|----------:|
| **ToArray** | **100**  |  **57.77 ns** |  **2.058 ns** |  **6.069 ns** |    **1** | **0.1013** |     **424 B** |
| ToList  | 100  |  63.44 ns |  2.864 ns |  8.444 ns |    2 | 0.1090 |     456 B |
| **ToArray** | **1000** | **340.55 ns** | **11.996 ns** | **35.183 ns** |    **3** | **0.9613** |    **4024 B** |
| ToList  | 1000 | 356.48 ns | 14.057 ns | 41.226 ns |    4 | 0.9689 |    4056 B |

![](/Arrays/imgs/ToListToArray.png)

The ToArray function will work faster and allocate less memory. (on tested **.NET 8**)