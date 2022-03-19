using ICSharpCode.Decompiler.Util;

var actualDir = Path.GetDirectoryName(Environment.ProcessPath);
var r = Directory.GetFiles(actualDir == null ? String.Empty : actualDir, "*.csv");

foreach (var resxFile in r)
{
    var content = File.ReadAllText(resxFile).Split(Environment.NewLine);
    var cultureFileName = resxFile.Substring(resxFile.LastIndexOf('\\') + 1).Replace("Resource", "").Replace(".csv", "");
    if (!Directory.Exists(@$"{actualDir}\Resources"))
    {
        Directory.CreateDirectory(@$"{actualDir}\Resources");
    }
    using (ResXResourceWriter resx = new ResXResourceWriter(@$"{actualDir}\Resources\Language{cultureFileName}.resx"))
    {
        foreach (var line in content)
        {
            if (line.Length > 0)
                resx.AddResource(line.Split(",")[0], line.Split(",")[1]);
        }
    }
}

