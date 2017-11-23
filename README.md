# Middle Winform Example
## 中間複雜度
　一支作業，多個步驟，多個元件。

## 平台與環境
* Windowns 10
* Visual Studio 2015
* .NetFx 4.5
* EntityFramework 6.x --- 取用 Database
* NLog 4.4.12  --- logging
* EPPlus 4.1.1 --- 讀取excel.xlsx
  
## 一些機制
* 長時間運算時防止沒有回應：Application.DoEvents
* 判斷開發模式：Component.DesignMode 
* 使用 Properties.Settings 組織參數
* 導入 template method pattern。
* 使用自訂 UserControl 把同一群組(同一步驟)的細小元件包裝起來，降低聚合提高偶合，以避免撞名也切斷無謂的UI關聯。
