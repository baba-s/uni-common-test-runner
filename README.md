# UniCommonTestRunner

Unity Test Runner で実行できる汎用的なテストを 20 個以上まとめた Unity プロジェクト  

[![](https://img.shields.io/github/release/baba-s/uni-common-test-runner.svg?label=latest%20version)](https://github.com/baba-s/uni-common-test-runner/releases)
[![](https://img.shields.io/github/release-date/baba-s/uni-common-test-runner.svg)](https://github.com/baba-s/uni-common-test-runner/releases)
![](https://img.shields.io/badge/Unity-2018.3%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x-orange.svg)
[![](https://img.shields.io/github/license/baba-s/uni-common-test-runner.svg)](https://github.com/baba-s/uni-common-test-runner/blob/master/LICENSE)

# バージョン

- Unity 2018.3.7f1

# 使い方

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324140848.png)

Unity メニューの「Window > General > Test Runner」を選択して表示される  

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324140859.png)

「Test Runner」ウィンドウからテストを実行することができます  

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324150831.png)

テストに失敗した場合は、該当するシーンやゲームオブジェクトの名前が出力されます  

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324141014.png)

Unity メニューの「Tools > UniCommonTestRunner」から  
現在のシーンを対象にテストを実行することもできます  

# 実行できるテストの種類

## 加速度センサーが無効になっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142201.png)

加速度センサーを使用しないプロジェクトにおいて  
加速度センサーが無効になっているかテストできます  

- 関連記事
    - http://baba-s.hatenablog.com/entry/2019/03/07/145949

## Android 用のプラグインのプラットフォームが適切か

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142206.png)

「Plugins」フォルダ内の「Android」フォルダに含まれているプラグインの  
対象プラットフォームに iOS が設定されていないかどうかテストできます  

- 参考サイト様
    - https://pimdewitte.me/2016/11/03/optimizing-ios-builds-in-unity-a-tutorial-for-getting-under-the-100mb-over-the-air-download-limit-on-the-app-store/
    - https://answers.unity.com/questions/1187539/why-does-unity-54-include-the-contents-of-pluginsa.html

## Animator Controller の Motion が null になっていないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142213.png)

Animator Controller の中のいずれかのステートの Motion が  
null になっていないかどうかテストできます  

## Audio Listener が存在しないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142219.png)

CRI のようなサウンドミドルウェアを使用しているプロジェクトで  
Audio Listener が使用されていないかどうかテストできます  

## Audio Listener が複数存在しないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142225.png)

Unity 標準のオーディオ機能を使用しているプロジェクトで  
Audio Listener が1つのシーンに複数存在しないかどうかテストできます  

## 2D のカメラのパラメータが統一されているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142543.png)

2D のプロジェクトにおいてすべてのシーンの  
カメラのパラメータが統一されているかどうかテストできます  

## Canvas にカメラが設定されているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142548.png)

Render Mode が「Screen Space - Camera」や「World Space」になっている Canvas に  
カメラが設定されているかどうかテストできます  

## 透明な UI オブジェクトの<br />Cull Transparent Mesh がオンになっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142552.png)

表示する必要のない透明な UI オブジェクトの Canvas Renderer の  
Cull Transparent Mesh がオンになっているかどうかテストできます  

- 関連記事
    - http://baba-s.hatenablog.com/entry/2019/03/18/152500

## Canvas Scaler のパラメータが統一されているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324142601.png)

すべてのシーンの Canvas Scaler の解像度の設定が  
統一されているかどうかテストできます  

## DisallowMultipleComponent 属性が適用されている<br />コンポーネントが複数アタッチされていないか

```cs
using UnityEngine;

[DisallowMultipleComponent]
public class Example : MonoBehaviour
{
}
```

DisallowMultipleComponent 属性が適用されているコンポーネントが  
1つのゲームオブジェクトに複数アタッチされていないかどうかテストできます  

## EventSystem の Drag Threshold が統一されているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143231.png)

すべてのシーンの EventSystem の Drag Threshold の値が  
統一されているかどうかテストできます  
（シーンによって ScrollRect の操作性が相違していないか確認できます）  

## 2D のシーンで GI が無効になっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143239.png)

2D のシーンでグローバルイルミネーションの機能が  
無効になっているかどうかテストできます  

- 関連記事
    - http://baba-s.hatenablog.com/entry/2019/03/06/141858
    - http://baba-s.hatenablog.com/entry/2019/03/06/143028
    - http://baba-s.hatenablog.com/entry/2019/03/06/143224

## iOS 用のプラグインのプラットフォームが適切か

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143245.png)

「Plugins」フォルダ内の「iOS」フォルダに含まれているプラグインの  
対象プラットフォームに Android が設定されていないかどうかテストできます  

## モバイル用のシェーダがマテリアルに設定されているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143250.png)

Unity 標準の軽量なモバイルシェーダに置き換えられるシェーダが  
使用されているマテリアルが存在しないかどうかテストできます  

- 参考サイト様
    - https://docs.unity3d.com/jp/current/Manual/shader-Performance.html

## Missing Prefab になっているオブジェクトが存在しないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143258.png)

生成元のプレハブが削除されたゲームオブジェクトが  
存在しないかどうかテストできます  

## Missing になっている参照が存在しないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143308.png)

存在しないアセットやオブジェクトの参照が設定されている  
パラメータが存在しないかどうかテストできます  

## Missing Script が存在しないか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143315.png)

存在しないスクリプトや名前が正しくないスクリプトがアタッチされている  
ゲームオブジェクトが存在しないかどうかテストできます  

## Odin の Required 属性が適用されている変数に<br />参照が設定されているか

```cs
using Sirenix.OdinInspector;
using UnityEngine;

public class Example : MonoBehaviour
{
    [Required] public GameObject go;
}
```

Odin の Required 属性が適用されている変数に  
参照が設定されているかどうかテストできます  

## OnlyOneInScene 属性が適用されている<br />コンポーネントがシーンに 1つだけかどうか

```cs
using UnityEngine;

[OnlyOneInScene]
public class Example : MonoBehaviour
{
}
```

OnlyOneInScene 属性が適用されているコンポーネントが  
シーンに1つしか存在しないかどうかテストできます  

## RectTransform の Position が整数になっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143711.png)

RectTransform の Position に浮動小数点以下が設定されており  
画像がボヤケて表示されていないかどうかテストできます  

## RectTransform の Scale が整数になっているか

RectTransform の Scale に浮動小数点以下が設定されており  
画像がボヤケて表示されていないかどうかテストできます  

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143716.png)

## TextMeshProUGUI の Raycast Target がオフになっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143721.png)

クリックできる必要のない TextMeshProUGUI オブジェクトの  
Raycast Target がオフになっているかどうかテストできます  

- 関連記事
    - http://baba-s.hatenablog.com/entry/2019/03/06/120002

## UI.Text の Raycast Target がオフになっているか

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190324/20190324143728.png)

クリックできる必要のない UI.Text オブジェクトの  
Raycast Target がオフになっているかどうかテストできます  

- 関連記事
    - http://baba-s.hatenablog.com/entry/2017/12/19/090000
    - http://baba-s.hatenablog.com/entry/2017/12/26/130900

# 補足

「UniCommonTestRunner」は、あくまでも  
汎用的に使えそうなテストをまとめただけのプロジェクトであり、  
一部のテストはそのままだと使えない、意図した結果にならないことが想定されます  

（例えば CRI を使用していることを前提としているテストが含まれています）  

「UniCommonTestRunner」を使用する場合は  
意図した結果にならないテストは修正や削除していただければと思います  