# ✈️ Travel Book Manager

**Travel Book Manager** è un'applicazione moderna multipiattaforma sviluppata con **.NET MAUI** e progettata seguendo i rigorosi principi della **Clean Architecture** e del **Domain-Driven Design (DDD)**. 
L'app permette agli utenti di pianificare i propri viaggi in modo intelligente, calcolare i percorsi migliori (con logiche TSP) e gestire voli, budget e destinazioni da un'unica piattaforma centralizzata e intuitiva.

## 🏗️ Architettura

Il progetto utilizza una struttura Multi-Progetto per garantire la massima scalabilità, manutenibilità e separazione delle responsabilità:

- **Domain**: Il cuore del sistema. Contiene Entità, Value Objects, e interfacce legate unicamente alle logiche di business pure.
- **Application**: Il livello d'orchestrazione. Implementa i casi d'uso (Use Cases) e gestisce l'interazione tra il dominio e le infrastrutture esterne tramite le interfacce dei Repository.
- **Infrastructure**: Gestisce l'accesso ai dati e l'interazione con servizi esterni. (Attualmente configurato per utilizzare **Supabase** come Backend-as-a-Service e Database PostgreSQL).
- **SharedKernel**: Una libreria condivisa che contiene i blocchi base dell'architettura (come le classi astratte per le Entità, il pattern `Result` per la gestione errori, e le classi base per gli Eventi di Dominio).
- **Presentation**: L'applicazione MAUI vera e propria, responsabile solo dell'Interfaccia Grafica e dell'interazione con l'utente (UI/UX).

## 🚀 Tecnologie Utilizzate

- **Frontend/Framework**: .NET MAUI (C#, XAML)
- **Backend/Database**: Supabase (PostgreSQL, Auth)
- **Architettura**: Clean Architecture, Domain-Driven Design (DDD), Pattern Result

## 🛠️ Requisiti di Sistema

- [.NET 9 / .NET 10 SDK](https://dotnet.microsoft.com/)
- Visual Studio 2022 o Visual Studio Code (con estensione C# Dev Kit)
- Carichi di lavoro (Workloads) MAUI installati: `dotnet workload install maui`
- Xcode (per la build macOS/iOS)
- Android SDK (per la build Android)

## 📦 Come Iniziare

1. Clona il repository:
   ```bash
   git clone https://github.com/TuoNomeUtente/TravelBookManager.git
   ```
2. Spostati nella directory principale:
   ```bash
   cd "Travel Book Manager"
   ```
3. Ripristina le dipendenze:
   ```bash
   dotnet restore
   ```
4. Avvia l'applicazione (per MacCatalyst, ad esempio):
   ```bash
   dotnet build -f net10.0-maccatalyst -t:Run
   ```
