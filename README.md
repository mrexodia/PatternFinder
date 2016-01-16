# PatternFinder

Parallel signature matcher/wildcard pattern finder in C#. Algorithm ported from [x64dbg](http://x64dbg.com).

## Examples

Find a single pattern in a buffer like this:

```
long foundOffset;
var pattern = Transform("11 ?6 89 9? 00 ?? 54");
if(Pattern.Find(buffer, pattern, out foundOffset))
    Console.WriteLine("Found pattern at {0}!", foundOffset);
else
    Console.WriteLine("Failed to find pattern...");
```

Find a list of signatures in a buffer like this:

```
var signatures = new[]
{
    new Signature("pattern1", "456?89?B"),
    new Signature("pattern2", "1111111111"),
    new Signature("pattern3", "AB??EF"),
};

var result = Pattern.Scan(data, signatures);
foreach (var signature in result)
    Console.WriteLine("Found signature {0} at {1}", signature.Name, signature.FoundOffset);
```

`Pattern.Scan` uses `Parallel.ForEach` for multi-thread support.
