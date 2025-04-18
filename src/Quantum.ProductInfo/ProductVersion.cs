using System.Diagnostics;
using System.Reflection;

namespace Quantum.ProductInfo;

public class ProductVersion
{
    public static string Version() 
        => Assembly.GetEntryAssembly().GetName().Version.ToString();

    public static ProductInfo GetProductInfo()
    {
        var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

        return new ProductInfo
        {
            ProductVersion = fileVersionInfo.ProductVersion,
            CompanyName = fileVersionInfo.CompanyName,
            FileVersion = fileVersionInfo.FileVersion,
            IsPatched = fileVersionInfo.IsPatched,
            IsPreRelease = fileVersionInfo.IsPreRelease,
            LegalCopyright = fileVersionInfo.LegalCopyright,
            LegalTrademarks = fileVersionInfo.LegalTrademarks,
            ProductName = fileVersionInfo.ProductName,
            ProductMajorPart = fileVersionInfo.ProductMajorPart,
            ProductMinorPart = fileVersionInfo.ProductMinorPart,
            ProductBuildPart = fileVersionInfo.ProductBuildPart,
        };
    }
}