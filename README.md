# 運動社團WEB應用程式 – Code First & DB First 版本

這個 repository 展示了相同專案在 **Code First** 與 **DB First** 兩種開發方式下的實作，方便比較兩種常見 EF Core 模式在專案架構上的應用。  

---

## 專案結構

- **CodeFirstVersion/**   
  - 使用 Entity Framework **Code First** 模式  
  - 功能完整：Migrations、JWT + Refresh Token + Roles  
  - 採用N層架構（Web API + BLL + DAL + Shared）

- **DatabaseFirstVersion/** （開發中）  
  - 使用 Entity Framework **DB First** 模式  
  - 已 scaffold 出 Context，並新增部分 Stored Procedure（含 Transaction）  
  - 待補：DAL 呼叫 SP、BLL/Controller  

---

## 技術亮點

- **熟悉兩種 EF Core 模式**：能依專案需求切換 Code First / DB First 開發流程  
- **清晰的分層架構**：Web API Server / BLL / DAL / Shared，符合企業常見設計  
- **資料表關聯設計**：處理 Club ↔ User (一對多)、User ↔ ClubEvent (多對多)，具備規劃與優化能力  
- **身份驗證與授權**：整合 JWT、Refresh Token 與角色（Roles），符合常見登入安全需求  
- **考量維護性與擴展性**：架構設計具備長期維護與擴充彈性  

---

## 如何使用

請依需求選擇版本進入：

- [Code First 使用說明](./CodeFirstVersion)  
- [DB First 使用說明](./DatabaseFirstVersion) （開發中，持續補強中）
