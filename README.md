# 折線圖產生器網站
> _大四下_友鋒課作業_   

* 功能說明(共有三個階段)
  1. 上傳csv檔。
  2. 使用者可客製化圖表XY軸所要放的資料欄位，以及標題、字體大小、要比對哪些資料、線條顏色、圖表長寬等等。
  3. 下載圖表
 
* 使用技術
  1. ASP.NET MVC
  2. C#
  3. javascript
  4. python  
  
* 程式架構
  |        | 說明 |程式 |
  |------- |:-----|:------:|
  | **前端**   |  1. 只有一個頁面，使用`session`判斷目前在哪個階段。</br>2. 第二階段時，js將後端傳回來的csv欄位資料動態呈現於網頁表單，並讓使用者可動態選取所要的資料和顏色。  |  [程式碼](https://github.com/hank444tw/0617Work/blob/master/0617Work/Views/Home/Index.cshtml) |
  | **後端**   |  1. 執行`cmd`呼叫python檔案。</br>2. 接收python檔案回傳值，並以串列型態回傳前端。</br>3. 第二階段submit後，將前端資料整理後以cmd形式輸入python檔  |  [程式碼](https://github.com/hank444tw/0617Work/blob/master/0617Work/Controllers/HomeController.cs) |
  | **python** |  1. 使用`Selenium 3.141`搭配`ChromeDriver`實現網頁自動操作。</br>2. 使用`BeautifulSoup4 4.7.1`針對已搜尋完畢的頁面，第一筆(最便宜)進行爬蟲。  |   [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Python/0520Work.py) |     

* 網站截圖
<img src="https://github.com/hank444tw/0617Work/blob/master/Demo1.JPG" stryle="float:right" />  

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo2.png" stryle="float:right" />    

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo3.png" stryle="float:right" />
