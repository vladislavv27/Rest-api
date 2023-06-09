# Rest-api
2 bbit task
Nepieciešams izveidot REST API, izmantojot ASP.NET Core (https://docs.microsoft.com/enus/aspnet/core/tutorials/first-web-api). Šajā etapā ir pieļaujams izmantot in-memory database.
Ir trīs datu tipi: Māja, Dzīvoklis un Iedzīvotājs.

Tipam “Māja” ir sekojošas īpašības:
- Numurs
- Iela
- Pilsēta
- Valsts
- Pasta indekss
- 
Tipam “Dzīvoklis” ir sekojošas īpašības:
- Numurs
- Stāvs
- Istabu skaits
- Iedzīvotāju skaits
- Pilna platība
- Dzīvojama platība
- Saikne ar māju, kur atrodas konkrēts dzīvoklis
- 
Tipam “Iedzīvotājs” ir sekojošas īpašības:
- Vārds
- Uzvārds
- Personas kods
- Dzimšanas datums
- Telefons
- E-mail
- Saikne ar dzīvokli, kur dzīvo iedzīvotājs
- 
API jāatbalsta sekojošas operācijas:
- Izveidoto objektu iegūšana
- Objektu izveidošana
- Objektu rediģēšana
- Objektu dzešana
