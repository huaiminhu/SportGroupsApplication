# 運動社團 Web 應用程式

## 專案簡介
此應用程式為一個多使用者的運動社群平台，具備基本會員系統、社團與活動功能，支援圖片與影片上傳，並具備角色權限控管機制。使用者可透過系統建立社團、舉辦活動、張貼文章與公告，也可加入其他社團並參與活動。

> 此專案目的是模擬現實生活中「社團管理 + 活動報名」流程，並練習實作多對多資料關聯、JWT 授權、檔案上傳處理等後端核心技術。

- 使用者身份分為「一般使用者」與「社團管理員」
- 社團活動類型支援：課程、比賽、聚會
- 活動與文章支援媒體（圖片 / 影片 / YouTube）
- 權限角色透過 JWT 與 ASP.NET Core 的 `[Authorize]` 控管

---

## 使用技術

- C#, ASP.NET Core 8 Web API
- Entity Framework Core (Code First)
- SQL Server + Stored Procedures
- AutoMapper(DTO映射), JWT 驗證授權(支援角色控制)
- Repository Pattern + Unit of Work + N-Tier 架構
- Swagger (API 測試)

## 系統架構

此專案採 N-Tier 架構設計，將系統邏輯清楚分層，利於維護與測試。

```plaintext
Web API 專案 (.Api)
│   └── Controller：接收請求並回傳結果
│
業務邏輯層 (.Business)
│   └── Service：處理商業邏輯，調用資料存取層
│
資料存取層 (.Data)
│   ├── Repository：實作 EF Core 或 SP 查詢
│   └── Unit of Work：統一管理資料庫操作
│
資料庫（SQL Server）
│   └── 使用 EF Core Code First 建表，結合部分 Stored Procedures
│
共用層 (.Shared)
│   └── 定義 DTO、Enum等跨層結構
│
基礎建設層 (.Infrastructure)
    └── 實作媒體檔案儲存共通服務
```  
  
---

## 資料表設計與關聯

此系統採用正規化關聯設計，核心資料表如下：

- **User** : 系統使用者，分為一般使用者與社團管理員
- **Club** : 社團管理員創立，可被多人加入
- **ClubMember** : 多對多中介表，同時記錄使用者加入社團的時間
- **ClubEvent** : 屬於某個社團的活動，一般使用者可參加
- **Enrollment** : 多對多中介表，記錄使用者活動的報名資訊(如報名時間等)
- **Article** : 社團發佈的文章，支援圖文/影音
- **Media** :　綁定於文章的媒體（圖片/影片/YouTube）
- **Message** : 社團發布的訊息

關聯簡圖如下：
```plaintext
User 1───* ClubMember *───1 Club
Club 1───* ClubEvent
Club 1───* Message
Club 1───* Article 1───* Media
ClubEvent 1───* Enrollment *───1 User 
```

> 此專案中 ClubMember 與 Enrollment 為具紀錄功能的中介表，並非單純關聯  
> Media 採單獨表設計以支援多格式媒體。
  
## 執行方式(本地開發)

1. 使用 Visual Studio 開啟專案。
2. 修改 `appsettings.json` 中的連線字串。
3. 開啟套件管理器主控台執行 `Update-Database` 建立資料表。
4. 設定 Web API 為啟動專案並執行，開啟 Swagger UI 進行測試。

> 登入後會獲得 JWT Token，請於 Swagger UI 點擊「Authorize」輸入 Token，即可測試需要驗證的 API。

### 使用者角色與對應功能權限：

| 使用者角色     | 功能權限                                      |
|----------------|-----------------------------------------------|
| 未登入         | 查詢社團、活動、文章                          |
| GeneralUser    | 加入社團、參加活動                            |
| ClubManager    | 建立社團、發佈活動 / 公告 / 文章，社團管理功能 |

### 登入角色建議測試帳號：

> 系統預設無帳號，請先自行註冊：
- Role = `"GeneralUser"`（一般使用者）
- Role = `"ClubManager"`（社團管理員）

### 列舉支援（Enums）：

- `EventType`(活動類型): `"Course"`(課程), `"Game"`(比賽), `"Meeting"`(聚會)
- `Sport`(運動項目): `"Basketball"`, `"Soccer"`, `"Running"`, `"Swimming"`, `"Baseball"`, `"Badminton"`(羽毛球), `"Taekwondo"`(跆拳道), `"Billiards"`(桌球), `"Tennis"`, `"Karate"`(空手道), `"Bicycle"`, `"CircuitTraining"`(循環訓練), `"HIIT"`(高強度間歇訓練)
- `MediaType`(媒體類型): `"Image"`, `"Video"`, `"YouTube"`
