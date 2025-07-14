# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/SentosApiLibrary.svg)](https://www.nuget.org/packages/SentosApiLibrary)

.NET ile [Sentos API](https://www.sentos.com.tr/) �zerinden �r�nlerinizi listeleyip y�netmenizi sa�layan basit bir istemci k�t�phanedir.

## Kurulum

```bash
dotnet add package SentosApiLibrary
```

## �r�n Listeleme �rne�i
```csharp
var config = new Config("[apiUrl]","[apiKey]","[ApiSecret]");
var sentosClient = new SentosClient(config);

var result = await sentosClient.Product.GetAllAsync(new ProductFilterInput
{
    Page = 1,
    Size = 10
});
if (result.IsFail)
{
    Console.WriteLine($"Error: {result.Message}({result.Code})");    
}
else
{
    foreach (var product in result.Data)
    {
        Console.WriteLine($"Product Name: {product.Name}, SKU: {product.Sku}");
    }
}
```
