# 🐳 Docker Setup Guide - DearDiary

> **Zero se Production-ready Docker setup**  
> Pehle backend, phir baad me frontend

---

## 📋 Prerequisites

- Docker Desktop installed ([Download](https://www.docker.com/products/docker-desktop))
- Git (agar doosre PC se clone karna ho)

---

## 🎯 Phase 1: Backend API Docker Setup

### Step 1: Dockerfile Create ✅

Dockerfile already create ho chuka hai:
```
API/DearDiary.API/DearDiary.API/Dockerfile
```

### Step 2: Docker Image Build

**Terminal me project root se:**

```bash
cd API/DearDiary.API/DearDiary.API
docker build -t deardiary-api .
```

**Verify:**
```bash
docker images
```
`deardiary-api` image dikhni chahiye.

### Step 3: Test API Container (Without Database)

```bash
docker run -p 7078:8080 deardiary-api
```

**Browser me check:**
```
http://localhost:7078/swagger
```

⚠️ **Note:** Database connection error aayega (expected), kyunki abhi database container nahi hai.

**Stop karna:**
```bash
Ctrl+C
```

---

## 🎯 Phase 2: Full Stack with Docker Compose

### Step 4: Docker Compose Setup ✅

`docker-compose.yml` already create ho chuka hai project root me.

### Step 5: Run Everything

**Project root se:**

```bash
docker compose up --build
```

Ye command:
- ✅ SQL Server container start karega
- ✅ API container build aur start karega
- ✅ Dono ko network me connect karega
- ✅ Database health check karega

### Step 6: Access Application

- **API Swagger:** http://localhost:7078/swagger
- **API Base:** http://localhost:7078
- **SQL Server:** localhost:1433

### Step 7: Database Migrations

**Pehli baar migrations run karni pad sakti hai:**

```bash
# Container me jao
docker compose exec api bash

# Migrations run karo
dotnet ef database update

# Exit
exit
```

Ya phir **host machine se** (agar .NET SDK installed hai):

```bash
cd API/DearDiary.API/DearDiary.API
dotnet ef database update --connection "Server=localhost,1433;Database=DearDiaryDb;User Id=sa;Password=YourStrong@123;TrustServerCertificate=True"
```

---

## 🛠️ Common Commands

### Start Services
```bash
docker compose up
```

### Start in Background
```bash
docker compose up -d
```

### Stop Services
```bash
docker compose down
```

### Stop + Remove Volumes (Database data delete)
```bash
docker compose down -v
```

### Rebuild Everything
```bash
docker compose up --build
```

### View Logs
```bash
docker compose logs -f
```

### View API Logs Only
```bash
docker compose logs -f api
```

### Check Running Containers
```bash
docker ps
```

---

## 🚀 Doosre PC Par Kaise Chalayein

### Option 1: Git Clone (Recommended)

1. **Docker Desktop install karo** (agar nahi hai)

2. **Repo clone karo:**
   ```bash
   git clone https://github.com/your-username/DearDiary.git
   cd DearDiary
   ```

3. **One command se run:**
   ```bash
   docker compose up --build
   ```

   Bas! 🎉  
   No .NET install  
   No SQL Server install  
   No setup needed

4. **Access:**
   ```
   http://localhost:7078/swagger
   ```

### Option 2: Docker Images Export/Import

**Source PC se:**
```bash
# Images build karo
docker compose build

# Images save karo
docker save -o deardiary-images.tar deardiary-api mcr.microsoft.com/mssql/server:2022-latest

# File copy karo doosre PC me
```

**Destination PC me:**
```bash
# Images load karo
docker load -i deardiary-images.tar

# Run karo
docker compose up
```

---

## 🔧 Configuration

### SQL Server Password Change

`docker-compose.yml` me password change karo:

```yaml
db:
  environment:
    SA_PASSWORD: "YourNewPassword123"
```

Aur `api` service me bhi:

```yaml
api:
  environment:
    - ConnectionStrings__DefaultConnection=Server=db;Database=DearDiaryDb;User Id=sa;Password=YourNewPassword123;TrustServerCertificate=True;
```

### Port Change

Agar port change karna ho:

```yaml
api:
  ports:
    - "YOUR_PORT:8080"  # Example: "5000:8080"
```

---

## 🐛 Troubleshooting

### Problem: "Cannot connect to database"

**Solution:**
- Database container healthy hai ya nahi check karo:
  ```bash
  docker compose ps
  ```
- Health check wait karo (30 seconds)
- Connection string verify karo

### Problem: "Port already in use"

**Solution:**
- `docker-compose.yml` me port change karo
- Ya phir existing service stop karo:
  ```bash
  docker compose down
  ```

### Problem: "Migrations not applied"

**Solution:**
- Manually migrations run karo (Step 7 dekh lo)

### Problem: "Image build fails"

**Solution:**
- `.dockerignore` check karo
- Dockerfile path verify karo
- Build context correct hai ya nahi check karo

---

## 📁 Project Structure (Docker Files)

```
DearDiary/
│
├── docker-compose.yml          # Main orchestration file
│
├── API/
│   └── DearDiary.API/
│       └── DearDiary.API/
│           ├── Dockerfile      # API Dockerfile
│           └── .dockerignore   # Ignore files
│
└── DOCKER.md                   # This file
```

---

## ✅ What You Achieved

- ✅ Khud Dockerfile likha
- ✅ Image banayi
- ✅ Multi-container app run ki
- ✅ Portable app banayi
- ✅ Real-world DevOps skill unlock 🔓

---

## 🔜 Next Steps (Future)

- [ ] Angular frontend Docker setup
- [ ] Nginx reverse proxy
- [ ] Docker volumes for data persistence
- [ ] Production Dockerfile (optimized)
- [ ] CI/CD pipeline integration
- [ ] Docker secrets for passwords

---

## 📚 Learning Resources

- [Docker Official Docs](https://docs.docker.com/)
- [Docker Compose Docs](https://docs.docker.com/compose/)
- [.NET Docker Images](https://hub.docker.com/_/microsoft-dotnet)

---

**Happy Dockerizing! 🐳**

