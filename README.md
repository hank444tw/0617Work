# 折線圖產生器網站
> _大四下_友鋒課期末作業_   

* 功能說明(共有三個階段)
  1. 上傳csv檔。
  2. 使用者可客製化圖表XY軸所要放的資料欄位，以及標題、字體大小、要比對哪些資料、線條顏色、圖表長寬等等。
  3. 下載圖表

* 開發工具
  1. Visual Studio 2017
  2. Spyder(Python3.7)

* 使用技術
  1. ASP.NET MVC
  2. C#
  3. javascript
  4. python  
  
* 程式架構
  |        | 說明 |程式 |
  |------- |:-----|:------:|
  | **前端**   |  1. 只有一個頁面，使用`session`判斷目前在哪個階段。</br>2. 第二階段時，使用`Razor`語法將後端傳回來的csv欄位資料動態呈現於網頁表單。</br>3. `js`讓使用者可動態選取所要的顏色。  |  [程式碼](https://github.com/hank444tw/0617Work/blob/master/0617Work/Views/Home/Index.cshtml) |
  | **後端**   |  1. 第一階段submit後，將csv檔下載，並以`cmd`呼叫python檔，再接收pyhton的回傳值。 </br>2. 第二階段submit後，將前端使用者設定之圖表參數，以`cmd`形式輸入python檔。  |  [程式碼](https://github.com/hank444tw/0617Work/blob/master/0617Work/Controllers/HomeController.cs) |
  | **python** |  1. 使用`pandas 0.24.2`獲取csv檔欄位資料，及製作折線圖表。</br>2. 接收`C#`以`cmd`傳來的資料，並製作成折線圖表，儲存於Server端。  |   [程式碼](https://github.com/hank444tw/0617Work/blob/master/0617Work/Python/0617Work.py) |     

* 網站截圖
<img src="https://github.com/hank444tw/0617Work/blob/master/Demo1.JPG" stryle="float:right" />  

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo2.png" stryle="float:right" />    

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo3.png" stryle="float:right" />
