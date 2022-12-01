# Kogane Levenshtein Distance

文字列の配列やリストから最も類似している文字列を検索できる拡張子メソッド

## 使用例

```csharp
using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private void Start()
    {
        var texts = new[]
        {
            "Awake",
            "Start",
            "Update",
            "FixedUpdate",
            "LateUpdate",
        };

        // Update
        Debug.Log( texts.GetMostSimilarString( "Updata" ) );
    }
}
```

たとえばアセットのパスを間違えて指定してしまい、アセットの読み込みが失敗した時に  
「もしかして：`XXXX`」のように正しいアセットのパスをログ出力できる