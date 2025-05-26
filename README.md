# Jr. NBA League Romania 

## Descriere

Acest proiect simulează competiția **Jr. NBA League Romania**, organizată de **Federația Română de Baschet** și **Asociația Județeană de Baschet Cluj**. Scopul este gestionarea și afișarea datelor despre echipele participante, elevii din aceste echipe, meciurile disputate și participarea elevilor la meciuri (activi sau rezerve).

---

## Entități

- **Echipa**
  - `id`: int
  - `nume`: string

- **Elev**
  - `id`: int
  - `nume`: string
  - `scoala`: string

- **Jucator** (extinde `Elev`)
  - `echipa`: referință la `Echipa`

- **Meci**
  - `echipa1`: referință la `Echipa`
  - `echipa2`: referință la `Echipa`
  - `data`: DateTime

- **JucatorActiv**
  - `idJucator`: referință la `Jucator`
  - `idMeci`: referință la `Meci`
  - `nrPuncteInscrise`: int
  - `tip`: enum (`Rezerva` / `Participant`)

---

## Funcționalități

- Afișarea tuturor jucătorilor unei echipe date
- Afișarea jucătorilor activi ai unei echipe într-un anumit meci
- Afișarea tuturor meciurilor dintr-o anumită perioadă
- Determinarea și afișarea scorului unui anumit meci

---

## Cerințe non-funcționale

- Arhitectură stratificată (Domain, Repository, Service, UI)
- Persistența datelor: fișiere text sau baze de date
- Interfață generică `IRepository<ID, E>` (similar cu temele din Java)
- Folosirea de:
  - **Generics**
  - **Delegates**
  - **LINQ**

---

## Structura proiectului

