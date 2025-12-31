# 🗄️ Database Access Guide - DearDiary

SQL Server database ko access karne ke multiple ways hain. Sabse easy aur recommended options neeche hain.

---

## 🎯 Option 1: Azure Data Studio (Recommended - Easiest)

### Step 1: Download & Install

1. **Download karo:** [Azure Data Studio](https://aka.ms/azuredatastudio)
2. **Install karo** (Windows/Mac/Linux - sab par chalega)

### Step 2: Connect to Database

1. **Azure Data Studio open karo**
2. **"New Connection" button click karo** (left sidebar me)
3. **Connection details enter karo:**

   ```
   Connection Type: Microsoft SQL Server
   Server: localhost,1433
   Authentication Type: SQL Login
   User name: sa
   Password: YourStrong@123
   Database: <leave empty or DearDiaryDb>
   ```

4. **"Connect" button click karo**

### Step 3: Database Use Karein

- Left sidebar me **"Databases"** expand karo
- `DearDiaryDb` database dikhni chahiye
- Tables, queries, sab kuch GUI se kar sakte ho

---

## 🎯 Option 2: SQL Server Management Studio (SSMS)

### Step 1: Download & Install

1. **Download karo:** [SSMS Download](https://aka.ms/ssmsfullsetup)
2. **Install karo** (Windows only)

### Step 2: Connect to Database

1. **SSMS open karo**
2. **"Connect" dialog me:**

   ```
   Server type: Database Engine
   Server name: localhost,1433
   Authentication: SQL Server Authentication
   Login: sa
   Password: YourStrong@123
   ```

3. **"Connect" click karo**

### Step 3: Database Explore Karein

- Object Explorer me **"Databases"** expand karo
- `DearDiaryDb` database dikhni chahiye
- Tables, views, sab kuch access kar sakte ho

---

## 🎯 Option 3: Command Line (sqlcmd)

### Windows PowerShell me:

```powershell
# SQL Server tools install karo (agar nahi hai)
# Docker container se directly connect karo
docker compose exec db /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourStrong@123" -C

# Phir SQL queries run karo:
USE DearDiaryDb;
GO
SELECT * FROM Categories;
GO
```

### Ya phir Host Machine se (agar SQL Server tools installed hain):

```powershell
sqlcmd -S localhost,1433 -U sa -P "YourStrong@123" -C -d DearDiaryDb
```

---

## 🎯 Option 4: Web-based Tools (Browser me)

### Adminer (Lightweight PHP Tool)

1. **Docker Compose me Adminer add karo:**

```yaml
adminer:
  image: adminer
  container_name: deardiary-adminer
  ports:
    - "8081:8080"
  networks:
    - deardiary-network
```

2. **Browser me open karo:**
   ```
   http://localhost:8081
   ```

3. **Login details:**
   ```
   System: Microsoft SQL Server
   Server: db
   Username: sa
   Password: YourStrong@123
   Database: DearDiaryDb
   ```

---

## 🔍 Quick Database Check

### Docker Container se Direct:

```powershell
# Container me jao
docker compose exec db bash

# SQL Server tools use karo
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourStrong@123" -C -Q "SELECT name FROM sys.databases"
```

### Database Tables Check:

```powershell
docker compose exec db /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourStrong@123" -C -d DearDiaryDb -Q "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
```

---

## 📊 Database Migrations

### Pehli baar database create karna:

**Option A: Host Machine se (agar .NET SDK hai):**

```powershell
cd API/DearDiary.API/DearDiary.API
dotnet ef database update --connection "Server=localhost,1433;Database=DearDiaryDb;User Id=sa;Password=YourStrong@123;TrustServerCertificate=True"
```

**Option B: Docker Container se:**

```powershell
# API container me jao
docker compose exec api bash

# Migrations run karo
dotnet ef database update

# Exit
exit
```

---

## 🔧 Connection Details Summary

```
Server: localhost,1433 (host machine se)
        db (Docker network se - containers ke beech me)

Username: sa
Password: YourStrong@123
Database: DearDiaryDb
```

---

## ✅ Recommended Setup

**Development ke liye:**
1. **Azure Data Studio** install karo (sabse easy)
2. **Connection save karo** (baar baar type karne ki zarurat nahi)
3. **Queries, tables, sab kuch GUI se manage karo**

**Production/Advanced ke liye:**
- **SSMS** use karo (Windows par)
- Ya phir **command line tools**

---

## 🐛 Troubleshooting

### Problem: "Cannot connect to server"

**Check:**
1. Docker container running hai?
   ```powershell
   docker compose ps
   ```

2. Port 1433 accessible hai?
   ```powershell
   netstat -an | findstr 1433
   ```

3. Firewall issue ho sakta hai

### Problem: "Login failed"

**Check:**
- Password correct hai? (`YourStrong@123`)
- Username correct hai? (`sa`)
- Connection string me TrustServerCertificate=True hai?

---

**Happy Database Access! 🗄️**

