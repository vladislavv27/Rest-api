# Rest-api
2. uzdevums
Nepieciešams izveidot REST API, izmantojot ASP.NET Core. Šajā etapā ir pieļaujams izmantot in-memory database.
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
3. uzdevums
Izmantojot 2.uzdevumā radītās CRUD operācijas, pielāgot risinājumu reālās dzīves scenārijiem.
1. Nepieciešams izņemt datu apstrādes loģiku no kontrolieriem un pārvietot to uz servisiem.
2. Nepieciešams pieslēgt SQL datubāzi
3. Nepieciešams izveidot noklusējuma objektu datubāzē (database seed).
a. Izveidot divas mājas
b. Izveidot 5 dzīvokļus (kopā)
c. Izveidot 4 iedzīvotājus (kopā)
4. Katram modelim uzrakstīt datubāzes konfigurāciju.
5. Paplašināt attiecības starp modeļiem, ievērojot zemāk aprakstītos nosacījumus:
a. Vienam iedzīvotājam var būt vairāki dzīvokļi.
b. Vienam dzīvoklim var būt vairāki iedzīvotāji.
c. Vienai mājai ir vairāki dzīvokļi, bet katram dzīvoklim ir tikai viena māja.
6. Pievienot “Iedzīvotāja” modelim jaunu bool lauku “IsOwner”
7. Migrēt datubāzi.
8. Radīt DTO modeļus
9. Pieslēgt AutoMapper.
