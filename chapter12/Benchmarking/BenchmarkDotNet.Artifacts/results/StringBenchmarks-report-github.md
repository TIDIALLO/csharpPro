``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1288 (21H2)
Intel Celeron CPU N3060 1.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                  Method |     Mean |     Error |    StdDev | Ratio |
|------------------------ |---------:|----------:|----------:|------:|
| StringConcatenationTest | 2.909 μs | 0.0411 μs | 0.0384 μs |  1.00 |
