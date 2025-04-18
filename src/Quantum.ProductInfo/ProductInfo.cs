namespace Quantum.ProductInfo;

public class ProductInfo
{
    public string? ProductVersion { get; set; }
    public string? CompanyName { get; set; }
    public string? FileVersion { get; set; }
    public bool IsPatched { get; set; }
    public bool IsPreRelease { get; set; }
    public string? LegalCopyright { get; set; }
    public string? LegalTrademarks { get; set; }
    public string? ProductName { get; set; }
    public int ProductMajorPart { get; set; }
    public int ProductMinorPart { get; set; }
    public int ProductBuildPart { get; set; }
}