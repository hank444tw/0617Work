# 折線圖產生器網站
> _大四下_友鋒課作業_   

* 功能說明
  1. 上傳csv檔，可產生折線圖。
  2. 使用者可客製化圖表XY軸所要放的資料欄位，以及標題、字體大小、呈現資料、線條顏色、圖表長寬等等。
  3. 下載折線圖
 
* 使用技術
  1. ASP.NET MVC
  2. C#
  3. javascript
  4. python  
  
* 程式架構
  |        | 說明 |程式 |
  |------- |:-----|:------:|
  | **前端**   |  1. 只有一個頁面，使用`Razor語法`判斷後端是否有傳送賣場書籍資訊。</br>2. JS顯示Loading遮罩效果。  |  [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Views/Home/NFU.cshtml) |
  | **後端**   |  1. 執行`cmd`呼叫對應的python檔案。</br>2. 接收python檔案回傳值，並以串列型態回傳前端。  |  [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Controllers/HomeController.cs) |
  | **python** |  1. 使用`Selenium 3.141`搭配`ChromeDriver`實現網頁自動操作。</br>2. 使用`BeautifulSoup4 4.7.1`針對已搜尋完畢的頁面，第一筆(最便宜)進行爬蟲。  |   [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Python/0520Work.py) |     

* 網站截圖
<img src="https://github.com/hank444tw/0617Work/blob/master/Demo1.JPG" stryle="float:right" />  

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo2.png" stryle="float:right" />    

<img src="https://github.com/hank444tw/0617Work/blob/master/Demo3.png" stryle="float:right" />
