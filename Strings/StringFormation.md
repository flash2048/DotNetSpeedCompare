# **Concatenation** vs **Format** vs **Interpolation**
What function is more effective than combining several strings into one?
* **Concatenation**: `string1 + string2`
* **Format**: `string.Format("{0}{1}", string1, string2)`
* **Interpolation**: `$"{string1}{string2}"`

> The winner: **Interpolation** (compared on the **.NET SDK 8.0.101**)

It will compare strings of lengths 10, 50, and 100 characters using 2, 3, and 4 parameters.

[Look at the code here.](/Strings/StringFormation.cs)

```md
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

```
| Method                        | N   | Mean      | Error     | StdDev    | Median    | Rank | Gen0   | Allocated |
|------------------------------ |---- |----------:|----------:|----------:|----------:|-----:|-------:|----------:|
| **StringConcatenation2Variables** | **10**  |  **23.01 ns** |  **0.866 ns** |  **2.470 ns** |  **22.80 ns** |    **2** | **0.0153** |      **64 B** |
| StringFormat2Variables        | 10  | 114.30 ns |  5.254 ns | 15.409 ns | 112.16 ns |   11 | 0.0153 |      64 B |
| StringInterpolation2Variables | 10  |  20.91 ns |  1.227 ns |  3.617 ns |  20.61 ns |    1 | 0.0153 |      64 B |
| StringConcatenation3Variables | 10  |  28.77 ns |  1.692 ns |  4.990 ns |  28.90 ns |    3 | 0.0210 |      88 B |
| StringFormat3Variables        | 10  | 130.09 ns |  4.847 ns | 14.291 ns | 128.23 ns |   12 | 0.0210 |      88 B |
| StringInterpolation3Variables | 10  |  23.37 ns |  0.932 ns |  2.733 ns |  22.63 ns |    2 | 0.0210 |      88 B |
| StringConcatenation4Variables | 10  |  31.36 ns |  1.254 ns |  3.676 ns |  30.57 ns |    4 | 0.0249 |     104 B |
| StringFormat4Variables        | 10  | 186.45 ns |  3.926 ns | 11.074 ns | 186.99 ns |   14 | 0.0381 |     160 B |
| StringInterpolation4Variables | 10  |  29.86 ns |  1.323 ns |  3.837 ns |  28.86 ns |    3 | 0.0249 |     104 B |
| **StringConcatenation2Variables** | **50**  |  **31.11 ns** |  **1.032 ns** |  **3.011 ns** |  **30.39 ns** |    **4** | **0.0535** |     **224 B** |
| StringFormat2Variables        | 50  | 110.26 ns |  3.905 ns | 11.392 ns | 108.49 ns |   11 | 0.0534 |     224 B |
| StringInterpolation2Variables | 50  |  31.87 ns |  1.661 ns |  4.897 ns |  30.43 ns |    4 | 0.0535 |     224 B |
| StringConcatenation3Variables | 50  |  44.81 ns |  2.027 ns |  5.815 ns |  44.08 ns |    6 | 0.0784 |     328 B |
| StringFormat3Variables        | 50  | 161.62 ns |  6.306 ns | 18.194 ns | 158.91 ns |   13 | 0.0782 |     328 B |
| StringInterpolation3Variables | 50  |  41.05 ns |  1.124 ns |  2.999 ns |  40.32 ns |    5 | 0.0784 |     328 B |
| StringConcatenation4Variables | 50  |  78.14 ns |  4.136 ns | 12.194 ns |  79.20 ns |    8 | 0.1013 |     424 B |
| StringFormat4Variables        | 50  | 244.85 ns | 16.759 ns | 49.152 ns | 227.13 ns |   15 | 0.1144 |     480 B |
| StringInterpolation4Variables | 50  |  58.92 ns |  4.143 ns | 12.149 ns |  54.30 ns |    7 | 0.1013 |     424 B |
| **StringConcatenation2Variables** | **100** |  **41.32 ns** |  **0.885 ns** |  **1.942 ns** |  **40.60 ns** |    **5** | **0.1013** |     **424 B** |
| StringFormat2Variables        | 100 | 162.61 ns |  8.944 ns | 26.089 ns | 161.42 ns |   13 | 0.1013 |     424 B |
| StringInterpolation2Variables | 100 |  55.00 ns |  3.344 ns |  9.861 ns |  58.34 ns |    7 | 0.1013 |     424 B |
| StringConcatenation3Variables | 100 |  84.22 ns |  5.356 ns | 15.794 ns |  87.77 ns |    9 | 0.1491 |     624 B |
| StringFormat3Variables        | 100 | 317.76 ns | 15.301 ns | 44.876 ns | 321.16 ns |   16 | 0.1488 |     624 B |
| StringInterpolation3Variables | 100 |  78.48 ns |  5.385 ns | 15.877 ns |  78.29 ns |    8 | 0.1491 |     624 B |
| StringConcatenation4Variables | 100 | 101.91 ns |  5.415 ns | 15.967 ns | 102.54 ns |   10 | 0.1969 |     824 B |
| StringFormat4Variables        | 100 | 387.59 ns | 24.477 ns | 72.170 ns | 375.04 ns |   17 | 0.2103 |     880 B |
| StringInterpolation4Variables | 100 | 102.01 ns |  7.233 ns | 19.556 ns |  96.01 ns |   10 | 0.1969 |     824 B |

![](/Strings/imgs/StringFormation.png)

String interpolation will work faster approximately in each test case. (small differences with concatenation can be ignored)
And ease of use do it the winner of this small contest.