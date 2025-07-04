# 運動社團WEB應用程式
  
## 應用程式簡要
這是一個可以創立運動社團或參與社團活動的WEB應用程式  
在登入前, 使用者可以查詢社團和社團活動  
也可以查詢社團發布的活動訊息和文章
使用者可做為一般使用者或社團管理員登入  
一般使用者可以在此應用程式中加入社團和參加活動    
社團管理員可以創立社團和發布社團活動  
社團活動型式分為比賽, 課程或聚會  
也可發布最新訊息, 文章  
  
## 使用技術  
**C#  
ASP.NET Core  
SQL Server  
Entity Framework  
Stored Procedures  
Auto Mapper  
Repository Pattern  
Unit of Work  
N-Tier  
JWT**  

## 系統架構  
Web API Controller(.Api)  >>>
BLL(.Business)  >>>
DAL(.Data)  >>>
Database(SQL Server)  
Shared(.Shared)  
Infrastructure(.Infrastructure)  

## 執行方式
1. 使用 Visual Studio 開啟本專案解決方案。  
2. 確認 SQL Server 正常執行，並修改 "appsettings.json" 中的資料庫連線字串。  
3. 開啟套件管理器主控台, 執行："Update-Database" 以建立初始資料庫與資料表。  
4. 設定 Web API 專案為啟動專案，執行程式以啟動後端服務。  
5. 開啟瀏覽器自動導向 Swagger UI，可直接進行註冊與登入測試。  
  
> 系統預設不含測試帳號，請先於 Swagger UI 註冊帳號後進行操作。  
> 註冊時, Role可以輸入"GeneralUser"(一般使用者)/"ClubManager"(社團管理員)  
> 所有使用者權限: 查詢社團, 活動, 文章  
> 一般使用者權限: 加入社團, 參加活動  
> 社團管理員權限: 社團, 社團活動, 社團訊息, 文章的創立, 更新, 刪除  

> EventType(社團活動類型): "Course"(課程), "Game"(比賽), "Meeting"(聚會)
> 
> Sport(運動類型): "Basketball" , "Soccer" , "Running" , "Swimming" , "Baseball" , "Badminton"(羽毛球) , "Taekwondo"(跆拳道) , "Billiards"(桌球) , "Tennis" , "Karate"(空手道) , "Bicycle" , "CircuitTraining"(循環訓練), "HIIT"(高強度間歇訓練)
> 
> MediaType(媒體類型): "Image", "Video", "YouTube"  
  
