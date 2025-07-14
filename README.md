# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/SentosApiLibrary.svg)](https://www.nuget.org/packages/SentosApiLibrary)

.NET ile [Sentos API](https://www.sentos.com.tr/) üzerinden ürünlerinizi listeleyip yönetmenizi saðlayan basit bir istemci kütüphanedir.

## Kurulum

```bash
dotnet add package SentosApiLibrary
```

## Ürün Listeleme Örneði
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
