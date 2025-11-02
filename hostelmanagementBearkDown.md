Awesome — here’s your **full backend development task breakdown** tailored for a **Hostel Management System** with:

✅ Simple structure (no layered arch)
✅ All entity + DB setup in a single phase
✅ Role management via ASP.NET Core Identity
✅ **Phase 4 broken down** into granular tasks for each functional module

---

# 🧩 Backend Development Task Breakdown (Hostel Management System)

**Tech Stack**

* .NET 8 Web API
* EF Core + ASP.NET Core Identity
* JWT-based Auth
* SQL Server or PostgreSQL

**Project Structure (simple, flat)**

```
/Hms.Api
  /Controllers
  /Models           // EF entities + DTOs (kept simple)
  /Data             // DbContext, Migrations, Seed
  /Services         // Thin service classes (optional)
  /Auth             // Identity/JWT helpers
  /Common           // Helpers (paging, ProblemDetails, etc.)
```

---

## 🚀 Phase 1: Project Initialization

### 🔹 Task 1.1: Project Setup

* Create `.NET 8 Web API` project
* Enable nullable, `ImplicitUsings`, Swagger
* Install packages:

  * `Microsoft.EntityFrameworkCore.SqlServer` or `Npgsql.EntityFrameworkCore.PostgreSQL`
  * `Microsoft.EntityFrameworkCore.Tools`
  * `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  * `Microsoft.AspNetCore.Authentication.JwtBearer`
  * `Swashbuckle.AspNetCore`
  * `FluentValidation.AspNetCore` (optional but useful)

### 🔹 Task 1.2: Configure Startup

* `Program.cs`: add DbContext, Identity, JWT Auth
* `appsettings.json`: DB connection + JWT (Issuer, Audience, Key)
* Swagger w/ JWT security scheme
* CORS policy (`AllowSpecificOrigins`)
* Global `ProblemDetails` mapping for errors

---

## 🗃️ Phase 2: Entity & Database Configuration (All-in-One)

### 🔹 Task 2.1: Identity Extension

* `ApplicationUser : IdentityUser` (Add: FullName, IsActive)
* `ApplicationRole : IdentityRole` (if needed)
* Use `IdentityDbContext<ApplicationUser>` (or separate `HmsDbContext : IdentityDbContext<ApplicationUser>`)


Task 2.2: Core Entities (Hostel + Flat + Rooms + Residents + Billing + Ops)

Hostel: Id, Name, Code, Address, Description, IsActive

Building: Id, HostelId, Name/Code

Room: Id, HostelId, BuildingId?, FloorNo, RoomCategory, Status

Flat: Id, HostelId, Name/Code, FloorNo, LocationText, RoomsCount, Rent, AdvancePolicy, Status

Resident: Id, RegNo, FullName, Phone, Email, GuardianName, GuardianPhone, ArrivalDate, IsActive

Allocation: Id, ResidentId, RoomId?, FlatId?, StartDate, EndDate?, Status

FeePlan: Id, Name, Amount, Periodicity (Monthly/Quarterly)

Invoice: Id, ResidentId, Period (YYYY-MM), Total, Due, Status, IssuedOn, DueOn

Payment: Id, InvoiceId, Amount, Method, PaidOn, TxRef, Status

LeaveRequest: Id, ResidentId, From, To, Reason, Status (Pending/Approved/Rejected)
`

### 🔹 Task 2.3: Relationships & Constraints

* Room 1–N Beds; Hostel 1–N Buildings/Floors/Rooms/Flats
* Allocation mutually exclusive: `(BedId XOR FlatId)` (room-only allocation uses RoomId or BedId)
* Invoice has many InvoiceLines; Payments linked to Invoice
* Enforce no overlapping allocations on same bed/flat + date ranges

### 🔹 Task 2.4: Migrations & Seeding

* Create initial migration & apply
* Seed **Roles**: `Admin`, `Manager`, `Warden`, `Staff`, `Accountant`, `Resident`
* Seed default Admin user (password from env)
* Optionally seed: one Hostel, few Rooms/Flats, Categories

---

## 🔐 Phase 3: Authentication & Role Access

### 🔹 Task 3.1: Auth Endpoints

* `POST /auth/register` (Admin-only for staff; self-register for Residents optional)
* `POST /auth/login` → returns JWT + claims (roles, userId)
* `POST /auth/refresh` (optional)

### 🔹 Task 3.2: Role & User Management

* `GET /users` (Admin)
* `PATCH /users/{id}/activate|deactivate`
* `POST /users/{id}/roles` (assign/remove)
* Apply `[Authorize(Roles="...")]` on sensitive endpoints

---

## ⚙️ Phase 4: Functional API Development (Broken Down)

> Each module below: **DTOs**, **Validation**, **Controller** (CRUD + queries), **Basic service** (if needed), **Policy checks**, **Swagger examples**, **Happy-path + negative tests (basic)**.

### 🏢 4.1 Hostels, Buildings, Floors

* `POST/GET/PUT/DELETE /hostels`
* `GET /hostels/{id}`
* `POST/GET /hostels/{id}/buildings`
* `POST/GET /buildings/{id}/floors`
* **Notes:** prevent delete if child entities exist.

### 🛏️ 4.2 Rooms & Beds

* `POST/GET/PUT/DELETE /rooms` (filters: hostelId, buildingId, floorId, categoryId, status)
* `POST/GET/PUT/DELETE /beds` (filters: roomId, status)
* `GET /availability/rooms` (date-range; summary counts)
* **Rules:** capacity invariants; room status auto-derived from beds if dorm.

### 🏠 4.3 Flat Management

* `POST/GET/PUT/DELETE /flats` (filters: hostelId, floorNo, status, rent range)
* **Fields:** rent, advance policy, roomsCount, locationText, floorNo, status
* `GET /availability/flats` (date-range)
* **Rules:** computed availability from allocations.

### 👤 4.4 Residents

* `POST/GET/PUT /residents` (activate/deactivate)
* `GET /residents/{id}` (with allocations, invoices snapshot)
* Optional: upload KYC via pre-signed URL (if you add storage later)

### 📌 4.5 Allocations (Room/Bed/Flat)

* `POST /allocations` (auto or manual; payload supports bedId OR flatId)
* `PATCH /allocations/{id}/end` (vacate)
* `GET /allocations?residentId=&status=&from=&to=`
* **Rules:** date-range overlap checks; state machine: `Reserved → Occupied → Vacated`
* **Side-effects:** update bed/flat status when occupied/vacated

### 💸 4.6 Fee Plans & Invoices

* `POST/GET/PUT/DELETE /fee-plans`
* `POST /invoices/generate?period=YYYY-MM&scope=hostelId|all` (bulk)
* `GET /invoices?residentId=&status=&period=`
* `GET /invoices/{id}` (with lines)
* `PATCH /invoices/{id}/cancel`
* **Logic:** proration if mid-cycle move-in/out; grace days → penalties

### 💳 4.7 Payments

* `POST /payments` (invoiceId, amount, method, txRef)
* `GET /payments?invoiceId=&from=&to=&method=`
* **Side-effects:** update invoice `Due` and `Status`
* **(Later)** Add provider webhooks (bKash/Nagad/Stripe) if required

### 🗓️ 4.8 Attendance & Leave

* `POST /attendance/mark` (bulk per day)
* `GET /attendance?residentId=&from=&to=`
* `POST /leaves` (resident)
* `PATCH /leaves/{id}/approve|reject` (warden/manager)
* **Rules:** one attendance per day; no overlap with approved leave

### 🛠️ 4.9 Complaints & Maintenance (Tickets)

* `POST /tickets` (resident/staff)
* `PATCH /tickets/{id}/assign|start|resolve|close`
* `POST /tickets/{id}/comments`
* `GET /tickets?status=&priority=&residentId=`
* **Rules:** SLA timers (optional later); allow reopen within window

### 📊 4.10 Reports & Dashboard

* `GET /reports/occupancy?from=&to=&hostelId=`
* `GET /reports/billing-summary?period=YYYY-MM`
* `GET /reports/dues`
* `GET /reports/attendance-summary?from=&to=`
* `GET /reports/tickets-sla`
* **Note:** start with SQL views or simple LINQ aggregations; optimize later

---

## 🧪 Phase 5: Testing & Documentation

### 🔹 Task 5.1: API Documentation

* Swagger groups per module (Hostels, Rooms, Flats, Residents, Allocations, Billing, Payments, Attendance, Tickets, Reports)
* XML comments + request/response examples
* Error model via ProblemDetails

### 🔹 Task 5.2: Tests (pragmatic)

* **Unit tests**: allocation overlap logic, invoice proration, payment → invoice status
* **Integration tests**: basic create→allocate→invoice→pay flow using TestServer + InMemory/Postgres test DB

---

## ✅ Summary View of Phases

| Phase | Description                               |
| ----: | ----------------------------------------- |
|     1 | Project + Config setup                    |
|     2 | All entity creation + DB config + seeding |
|     3 | Identity & JWT Auth + role-based access   |
|   4.1 | Hostels / Buildings / Floors APIs         |
|   4.2 | Rooms & Beds APIs                         |
|   4.3 | Flat Management APIs                      |
|   4.4 | Residents APIs                            |
|   4.5 | Allocations APIs                          |
|   4.6 | Fee Plans & Invoices APIs                 |
|   4.7 | Payments APIs                             |
|   4.8 | Attendance & Leave APIs                   |
|   4.9 | Complaints & Maintenance (Tickets) APIs   |
|  4.10 | Reports & Dashboard APIs                  |
|     5 | Tests & Swagger Docs                      |

---

### Want me to generate:

* a **ready-to-run solution skeleton** (`dotnet new`, DbContext, Identity, JWT, Swagger)
* or a **SQL schema script** for the entities above?
