# UniversityDbApp

3-апта тапсырмасы: ORM, Entity Framework Core, MS SQL Server және Code-First.

## Дайын жоба

- Department және Teacher модельдері; бір кафедраға бірнеше оқытушы (1:N).
- Teacher.DepartmentId сыртқы кілті және индексі.
- AppDbContext және Program.cs ішінде SQL Server тіркеуі.
- InitialDb миграциясы, Designer және ModelSnapshot.
- 2 кафедра мен 3 оқытушыдан тұратын демонстрациялық деректер.
- Дерекқордан мәлімет оқитын веб-бет және екі GET API.

## 1. Қажетті бағдарламалар

Windows жүйесінде .NET 8 SDK және SQL Server Express LocalDB орнатылған болуы керек.
Visual Studio қолдансаңыз, ASP.NET and web development жүктемесін және SQL Server Express LocalDB компонентін Visual Studio Installer арқылы орнатыңыз.

Бұл оқу жобасында .NET 8 және EF Core 8.0.11 нұсқалары бекітілген; олар соңғы нұсқа деп ұсынылмайды.
NuGet пакеттерін алғаш жүктегенде интернет керек.

## 2. Ең тез іске қосу

1. ZIP архивін толық шығарыңыз (Extract All).
2. Шыққан UniversityDbApp бумасындағы RUN.cmd файлын екі рет басыңыз.
3. Пакеттер жүктеліп, InitialDb миграциясы UniversityDb дерекқорына қолданылады.
4. Терминалда сервер іске қосылған соң http://localhost:5080 ашыңыз. Бет ерте ашылса, жаңартыңыз.
5. Терминалды ашық қалдырыңыз. Тоқтату: Ctrl+C.

RUN.cmd қайта іске қосылса, қолданылған миграция қайталанбайды.

## 3. Visual Studio арқылы

1. UniversityDbApp.csproj ашыңыз.
2. Tools → NuGet Package Manager → Package Manager Console ашыңыз.
3. Default project ретінде UniversityDbApp таңдаңыз.
4. Орындаңыз:

```powershell
Update-Database
```

5. Ctrl+F5 басыңыз.

**InitialDb архивте бар, сондықтан Add-Migration InitialDb командасын қайта орындаудың қажеті жоқ.**
Егер мұғалім миграцияны өзіңіз жасауды көрсетуіңізді сұраса, жобаның жеке көшірмесінде,
дерекқорға әлі миграция қолданбай тұрып, Migrations бумасын жойыңыз. Сол көшірмеде
appsettings.json ішіндегі Database атауын UniversityDbPractice деп өзгертіңіз, кейін:

```powershell
Add-Migration InitialDb
Update-Database
```

Осылайша дайын UniversityDb дерекқорын өзгертпей, талаптағы екі команданы көрсетесіз.

## 4. Терминал арқылы балама

Жобаның csproj файлы бар бумасында:

```powershell
dotnet restore
dotnet tool restore
dotnet ef database update
dotnet run --no-launch-profile --urls http://localhost:5080
```

## 5. SQL Server баптауы

Әдепкі сервер: `(localdb)\MSSQLLocalDB`. LocalDB — SQL Server Express нұсқасының жергілікті әзірлеу режимі.
SSMS бағдарламасының өзі дерекқор серверін орнатпайды.

Егер компьютеріңізде SQLEXPRESS болса, appsettings.json ішіндегі DefaultConnection мәнін өзгертіңіз:

```json
"Server=localhost\\SQLEXPRESS;Database=UniversityDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

Әдепкі SQL Server instance үшін: `Server=localhost;Database=UniversityDb;Trusted_Connection=True;TrustServerCertificate=True`.
Өзгерткен соң Update-Database қайта орындаңыз. Жоба Windows аутентификациясын пайдаланады.

## 6. Тапсыруға арналған скриншот

1. SQL Server Management Studio (SSMS) ашыңыз.
2. Server name: `(localdb)\MSSQLLocalDB`; Authentication: Windows Authentication.
3. Connect → Databases → UniversityDb → Tables ашыңыз, қажет болса Refresh басыңыз.
4. dbo.Departments, dbo.Teachers және dbo.__EFMigrationsHistory көрінетін скриншот түсіріңіз.
5. sql/verify.sql файлын SSMS-та ашып, Execute басыңыз.
6. Кестелер, JOIN нәтижесі және FK атауы көрінетін екінші скриншот түсіріңіз.
7. Суреттерді screenshots бумасына tables.png және query-results.png ретінде салыңыз.

Веб-беттің скриншоты қосымша дәлел бола алады, бірақ SQL Server кестелерінің скриншотын алмастырмайды.
Дайын архивке жалған скриншот қосылмаған.

## 7. GitHub-қа жүктеу

1. GitHub → New repository → атауы UniversityDbApp → Create repository.
2. Uploading an existing file (немесе Add file → Upload files) таңдаңыз.
3. ZIP-ті емес, шығарылған UniversityDbApp бумасының ішіндегі файлдар мен бумаларды жүктеңіз.
4. README.md және UniversityDbApp.csproj репозиторийдің түбірінде болуы керек.
5. `.config/dotnet-tools.json` және `.gitignore` да жүктелгенін тексеріңіз. Жасырын файлдар қажет болса Explorer-де View → Show → Hidden items қосыңыз.
6. bin, obj, .vs бумаларын жүктемеңіз.
7. Commit changes басыңыз. Скриншоттарды да қосыңыз.
8. Classroom-ға репозиторий сілтемесі мен SQL Server скриншоттарын тапсырыңыз.

## Жиі кездесетін қателер

- `dotnet is not recognized`: .NET 8 SDK орнатыңыз, терминалды қайта ашыңыз.
- LocalDB табылмайды: SQL Server Express LocalDB орнатыңыз немесе бар сервердің атауын қосылу жолына жазыңыз.
- `Add-Migration is not recognized`: команданы жай PowerShell емес, Visual Studio Package Manager Console ішінде орындаңыз. Немесе dotnet tool restore, содан соң dotnet ef қолданыңыз.
- Пакеттер жүктелмейді: интернет пен NuGet.org қолжетімділігін тексеріңіз.
- `InitialDb already exists`: дайын миграция бар; тек Update-Database орындаңыз.
- Порт бос емес: 5080 орнына 5081 қолданып, браузерде де сол портты ашыңыз.

## Бақылау сұрақтарының жауаптары

1. **Б** — ORM кестелерді бағдарламалау тілінің объектілеріне сәйкестендіреді.
2. **А** — DbContext.
3. **А** — Add-Migration <Name>.
4. **Б** — Update-Database.
5. **Б** — қосылу жолы және жүйелік баптаулар.

## Тексеру мәртебесі

Архивтің бүтіндігі, конфигурациялық JSON/XML файлдары және жоба құрамының сәйкестігі тексерілді.
Жасалған ортада .NET SDK мен SQL Server болмағандықтан, C# компиляциясы және нақты SQL Server-де іске қосылуы тексерілмеді.
Алғашқы іске қосқанда күтілетін нәтиже: миграция сәтті орындалып, 2 кафедра және 3 оқытушы веб-бетте көрсетіледі.

## Ресми анықтама

- https://learn.microsoft.com/ef/core/get-started/overview/install
- https://learn.microsoft.com/ef/core/managing-schemas/migrations/
