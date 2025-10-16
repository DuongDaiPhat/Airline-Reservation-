# Airline-Reservation Structure

# Airline-Reservation Structure

## Project Structure
**Airline Reservation WinForms Application – Multi-Layered Project Structure (Domain, Application, Infrastructure, Presentation, Shared)**

Dự án được tổ chức theo **kiến trúc nhiều tầng (Clean/Layered Architecture)** để tách biệt rõ ràng phần nghiệp vụ, logic ứng dụng, hạ tầng, giao diện và tiện ích dùng chung. 

### Các tầng chính

- **Domain (AirlineReservation.Domain)**  
  Chứa **Entities, ValueObjects, Enums, Interfaces** – đại diện cho lõi nghiệp vụ (Bookings, Flights, Payments, Users, Promotions...).  
  → Đây là **business core**, độc lập với UI và database.  

- **Application (AirlineReservation.Application)**  
  Chứa **DTOs, Features, Services, Validators, Helpers, Mappings** – nơi triển khai logic điều phối và xử lý nghiệp vụ.  
  → Đây là tầng **workflow/logic** của ứng dụng.  

- **Infrastructure (AirlineReservation.Infrastructure)**  
  Chứa **Persistence (DbContext, Migrations, Repositories), Logging, Email, PaymentGateway, FileStorage, Security**.  
  → Đây là tầng **hạ tầng & tích hợp dịch vụ ngoài**.  

- **Presentation (AirlineReservation.Presentation – WinForms)**  
  Chứa **Forms (Admin, Staff, User), Controllers, ViewModels, Assets (Icons, Images, Styles)**.  
  → Đây là **UI WinForms** của hệ thống.  

- **Shared (AirlineReservation.Shared)**  
  Chứa **Constants, Enums, Exceptions, Utils** – các thành phần dùng chung giữa các tầng. 

```
├── 📁 .git/ 🚫 (auto-hidden)
├── 📁 Airline-Reservation/
│   ├── 📁 .vs/ 🚫 (auto-hidden)
│   ├── 📁 Properties/
│   │   ├── 🟣 AssemblyInfo.cs
│   │   ├── 🟣 Resources.Designer.cs
│   │   ├── 📄 Resources.resx
│   │   ├── 🟣 Settings.Designer.cs
│   │   └── 📄 Settings.settings
│   ├── 📁 obj/ 🚫 (auto-hidden)
│   ├── 📁 src/
│   │   ├── 📁 AirlineReservation.Application/
│   │   │   ├── 📁 DTOs/
│   │   │   │   ├── 📁 Bookings/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Flights/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Payments/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Promotions/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   └── 📁 Users/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 📁 Features/
│   │   │   │   ├── 📁 Bookings/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Flights/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Notifications/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Payments/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Promotions/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Services/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   └── 📁 Users/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 📁 Helpers/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Interfaces/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Mappings/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Services/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Validators/
│   │   │   │   └── 📄 .gitkeep
│   │   │   └── 📖 README.md
│   │   ├── 📁 AirlineReservation.Domain/
│   │   │   ├── 📁 Entities/
│   │   │   │   ├── 📁 Bookings/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Flights/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Logs/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Notifications/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Payments/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Promotions/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Services/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   └── 📁 Users/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 📁 Enums/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Interfaces/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 ValueObjects/
│   │   │   │   └── 📄 .gitkeep
│   │   │   └── 📖 README.md
│   │   ├── 📁 AirlineReservation.Infrastructure/
│   │   │   ├── 📁 DataSeed/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Email/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Extensions/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 FileStorage/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Logging/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 PaymentGateway/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Persistence/
│   │   │   │   ├── 📁 Configurations/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Contexts/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Migrations/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   └── 📁 Repositories/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 📁 Security/
│   │   │   │   └── 📄 .gitkeep
│   │   │   └── 📖 README.md
│   │   ├── 📁 AirlineReservation.Presentation (WinForms)/
│   │   │   ├── 📁 Assets/
│   │   │   │   ├── 📁 Icons/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   ├── 📁 Images/
│   │   │   │   │   └── 📄 .gitkeep
│   │   │   │   └── 📁 Styles/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 📁 Controllers/
│   │   │   │   ├── 📄 .gitkeep
│   │   │   │   ├── 🟣 BookingController.cs
│   │   │   │   ├── 🟣 FlightController.cs
│   │   │   │   ├── 🟣 NotificationController.cs
│   │   │   │   ├── 🟣 PaymentController.cs
│   │   │   │   ├── 🟣 PromotionController.cs
│   │   │   │   └── 🟣 UserController.cs
│   │   │   ├── 📁 Helpers/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 ViewModels/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Views/
│   │   │   │   ├── 📁 Forms/
│   │   │   │   │   ├── 📁 Admin/
│   │   │   │   │   │   ├── 📄 .gitkeep
│   │   │   │   │   │   ├── 🟣 AdminDashboard.cs
│   │   │   │   │   │   ├── 🟣 ManageFlightsForm.cs
│   │   │   │   │   │   ├── 🟣 ManageNotificationsForm.cs
│   │   │   │   │   │   ├── 🟣 ManagePromotionsForm.cs
│   │   │   │   │   │   └── 🟣 ManageUsersForm.cs
│   │   │   │   │   ├── 📁 Common/
│   │   │   │   │   │   ├── 📄 .gitkeep
│   │   │   │   │   │   ├── 🟣 BaseForm.cs
│   │   │   │   │   │   └── 🟣 DialogForm.cs
│   │   │   │   │   ├── 📁 Staff/
│   │   │   │   │   │   ├── 📄 .gitkeep
│   │   │   │   │   │   ├── 🟣 ApproveRequestsForm.cs
│   │   │   │   │   │   ├── 🟣 BoardingForm.cs
│   │   │   │   │   │   ├── 🟣 CheckinForm.cs
│   │   │   │   │   │   └── 🟣 StaffDashboard.cs
│   │   │   │   │   └── 📁 User/
│   │   │   │   │       ├── 📄 .gitkeep
│   │   │   │   │       ├── 🟣 BookingForm.cs
│   │   │   │   │       ├── 🟣 LoginForm.cs
│   │   │   │   │       ├── 🟣 MyTicketsForm.cs
│   │   │   │   │       ├── 🟣 PaymentForm.cs
│   │   │   │   │       ├── 🟣 RegisterForm.cs
│   │   │   │   │       ├── 🟣 RequestForm.cs
│   │   │   │   │       └── 🟣 SearchFlightForm.cs
│   │   │   │   └── 📁 UserControls/
│   │   │   │       └── 📄 .gitkeep
│   │   │   ├── 🟣 MainForm.cs
│   │   │   ├── 🟣 Program.cs
│   │   │   └── 📖 README.md
│   │   ├── 📁 AirlineReservation.Shared/
│   │   │   ├── 📁 Constants/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Enums/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Exceptions/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Extensions/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Results/
│   │   │   │   └── 📄 .gitkeep
│   │   │   ├── 📁 Utils/
│   │   │   │   └── 📄 .gitkeep
│   │   │   └── 📖 README.md
│   │   ├── 🟣 Form1.Designer.cs
│   │   └── 🟣 Form1.cs
│   ├── 🟣 Airline-Reservation.csproj
│   ├── 🟣 Airline-Reservation.sln
│   ├── 📄 App.config
│   ├── 🟣 Form1.Designer.cs
│   ├── 🟣 Form1.cs
│   └── 🟣 Program.cs
├── 📜 LICENSE
└── 📖 README.md
```
