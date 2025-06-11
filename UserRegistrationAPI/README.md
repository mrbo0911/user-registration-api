# .NET Core Registration & Migration API

This project provides backend APIs for a mobile app's registration and user migration flow.

## 🔧 Tech Stack
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- Swagger for API testing

## 📁 Project Structure
- `UserController` – User registration, migration, existence check
- `OtpController` – Simulated OTP send/verify
- `PinController` – PIN setup (hashed with SHA-256)
- `ConsentController` – Privacy policy acceptance

## ▶️ Running the App
1. Open in Visual Studio or VS Code.
2. Run the project (`F5` or `dotnet run`).
3. Navigate to `https://localhost:{port}/swagger` to access Swagger UI.

## 🧪 Example Flow
1. **Register new user**  
   `POST /api/user/register`

2. **Send OTP**  
   `POST /api/otp/send`

3. **Verify OTP**  
   `POST /api/otp/verify`

4. **Accept consent**  
   `POST /api/consent/accept`

5. **Set PIN**  
   `POST /api/pin/set`

6. **Login/Migrate**  
   `POST /api/user/migrate`

7. **Check user existence**  
   `GET /api/user/exists?phone=...`

---

## 📦 Deliverable

- Source Code (as `.zip`)
- README included
