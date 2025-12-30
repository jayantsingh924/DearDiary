# 📘 DearDiary  

*Angular + .NET + AI Powered Blog & Notes Application*

---

## 📝 Project Overview

**DearDiary** is a personal blog & notes application designed to store thoughts, learning notes, and daily reflections — enhanced with **AI-powered intelligence** for writing, understanding, and knowledge retrieval.

This project is built as a **long-term skill practice + portfolio showcase repository**, not just a demo app.

---

## 🎯 Project Goals

- Build a real-world **full-stack application**
- Practice **Angular (Frontend) + ASP.NET Core (Backend)**
- Gradually integrate **Generative AI & LLM concepts**
- Create a **personal knowledge & diary system**
- Keep the project **domain-ready** for future public launch

---

## 👤 Target Audience

- Developers learning Angular & .NET
- Backend developers exploring Generative AI / LLMs
- Anyone who wants to build a personal diary / blog / notes system
- Portfolio & interview preparation

---

## 🧠 Core Features

### 🟢 Phase 1 – Blog / Notes Foundation

- Create diary entries / notes
- Edit & delete notes
- List all notes
- View single note
- Categories / tags
- Clean and minimal UI

> Focus: Strong fundamentals (No AI yet)

---

### 🟡 Phase 2 – AI Writing Assistant

- Improve writing clarity
- Summarize long notes
- Rewrite content
- Generate titles

> Uses Generative AI (LLM) via backend only

---

### 🔵 Phase 3 – Intelligent Knowledge System

- Semantic search (search by meaning)
- Related notes suggestions
- Ask questions from personal notes (RAG)
- Monthly learning summaries

> Uses Vector Embeddings + LLMs

---

## 🏗️ Tech Stack

### Frontend

- Angular (latest stable)
- TypeScript
- Angular Forms & HTTP Client

### Backend

- ASP.NET Core Web API (.NET 8/9)
- C#
- Entity Framework Core
- Clean Architecture

### AI / Future

- LLM APIs (OpenAI / Azure / Local later)
- Vector Embeddings
- Prompt templates
- Vector storage (future-ready)

---

## 📂 Project Structure

```

deardiary/
│
├── frontend/                 # Angular application
│
├── backend/                  # ASP.NET Core Web API
│   ├── DearDiary.Api
│   ├── DearDiary.Application
│   ├── DearDiary.Domain
│   └── DearDiary.Infrastructure
│
├── docs/                     # Architecture & learning notes
│
├── README.md
└── .gitignore

```

---

## 🔄 Frontend ↔ Backend Flow

```

Angular UI
↓ HTTP Requests
ASP.NET Core API
↓
Services → Repositories → Database
↑
JSON Response

```

> All AI calls are handled **only by backend** for security.

---

## 🤖 AI Usage (Conceptual)

### Example AI Features

- Improve this note
- Summarize this blog
- What did I learn last month?
- Show related notes on a topic

### AI Flow

```

User Content → Backend → LLM
User Query → Embeddings → Relevant Notes → LLM Response

```

---

## 🧩 LLM Concepts Covered

| Concept | Usage |
|-------|------|
| Tokenization | Prompt size control |
| Prompt Engineering | Writing improvements |
| Embeddings | Semantic search |
| Attention | Relevant responses |
| RAG | Query personal notes |

---

## 🔐 Security & Best Practices

- No API keys in frontend
- AI access via backend only
- Config-driven setup
- Vendor-agnostic AI design
- Feature flags for AI modules

---

## 🚀 Future Enhancements

- Authentication & authorization
- Public / private notes
- Markdown editor
- Export notes
- Docker & CI/CD
- Custom domain deployment

---

## 💡 Why DearDiary?

- Not a tutorial project
- Not a throwaway demo
- Real learning with real use-cases
- AI-ready architecture
- Portfolio + product mindset

---

## ✅ Roadmap Checklist

- [ ] Setup Angular application
- [ ] Setup ASP.NET Core Web API
- [ ] Implement Notes CRUD
- [ ] Integrate AI writing assistant
- [ ] Add embeddings & semantic search

---

## 📌 Final Note

**DearDiary** is more than an app —  
it is a **learning journey**, a **personal knowledge system**, and a **future-ready AI-powered product**.
