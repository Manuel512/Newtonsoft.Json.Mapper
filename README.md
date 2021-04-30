# JsonMapper

JsonMapper is a lightweight library for mapping a json schema to a custom schema using Json.NET. It uses JSONPATH sintax for the search on the source schema.

## Usage

**Retrieving simple values**

```C#
var json = @"{
    'name': 'Samsung TV',
    'price': 550
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("name", "productName", "Value"),
    new MappingRule("price", "productPrice", "Value"),
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'productName': 'Samsung TV',
//     'productPrice' 550
// }
```

**Retrieving objects**

```C#
var json = @"{
    'product': {
        'name': 'Samsung TV',
        'price': 550
    }
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("product", "myProduct", "Object")
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'myProduct':{
//         'name': 'Samsung TV',
//         'price': 550
//     }
// }
```

**Retrieving deep values within objects**

```C#
var json = @"{
    'product': {
        'name': 'Samsung TV',
        'price': 550
    }
}";

MappingRules rules = new List<MappingRules> 
{
//                       from            to       mappingType
    new MappingRule("product.name", "productName", "Value"),
    new MappingRule("product.price", "productPrice", "Value")
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'productName':'Samsung TV',
//     'producPrice': 550
// }
```

**Retrieving objects with custom properties**

```C#
var json = @"{
    'product': {
        'name': 'Samsung TV',
        'price': 550
    }
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("product", "myProduct", "Object")
        .AddMapProperty("name", "productName")
        .AddMapProperty("price", "productPrice")
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'myProduct':{
//         'productName': 'Samsung TV',
//         'productPrice': 550
//     }
// }
```

**Retrieving an Array**

```C#
var json = @"{
    'products': [
        {
            'name': 'Samsung TV 43',
            'price': 550
        },
        {
            'name': 'LG TV 43',
            'price': 450
        }
    ]
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("products", "myProducts", "Array")        
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'myProducts': [
//          {
//             'name': 'Samsung TV 43',
//             'price': 550
//          },
//          {
//             'name': 'LG TV 43',
//             'price': 450
//          }
//      ]
// }
```

**Retrieving an Array with custom properties**

```C#
var json = @"{
    'products': [
        {
            'name': 'Samsung TV 43',
            'price': 550
        },
        {
            'name': 'LG TV 43',
            'price': 450
        }
    ]
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("products", "myProducts", "Array")
        .AddMapProperty("name", "productName")
        .AddMapProperty("price", "productPrice")     
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'myProducts': [
//          {
//             'productName': 'Samsung TV 43',
//             'productPrice': 550
//          },
//          {
//             'productName': 'LG TV 43',
//             'productPrice': 450
//          }
//      ]
// }
```

**Retrieving a complex json schema object**

```C#
var json = @"{
    'products': [
        {
            'name': 'Samsung TV 43',
            'price': 550,
            'features': {
                'resolution': '4K',
                'isSmart': true,
                'screenType': 'LED'
           }
        },
        {
            'name': 'LG TV 43',
            'price': 450,
            'features': {
                'resolution': '1080',
                'isSmart': false,
                'screenType': 'LCD'
           }
        }
    ]
}";

MappingRules rules = new List<MappingRules> 
{
//                   from        to       mappingType
    new MappingRule("products[0].features.resolution", "samsungResolution", "Value")
}

string newJson = JsonMapper.MapToJsonString(json, rules);

// {
//     'samsungResolution': '4K'
// }
```