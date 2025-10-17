CREATE DATABASE AirlineReservationSystem;
GO
USE AirlineReservationSystem;
GO

-- =============================================
-- 1. HỆ THỐNG NGƯỜI DÙNG VÀ PHÂN QUYỀN
-- =============================================

CREATE TABLE Users (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20) UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    DateOfBirth DATE,
    Gender CHAR(1) CHECK (Gender IN ('M', 'F', 'O')), -- M: Male, F: Female, O: Other
    CityCode CHAR(3), -- Thành phố của user (SGN, HAN, DAD, etc.)
    Address NVARCHAR(255), -- Địa chỉ chi tiết
    IsVerified BIT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME,
	FOREIGN KEY (CityCode) REFERENCES Cities(CityCode),
    
    CONSTRAINT CK_Email_Valid CHECK (Email LIKE '_%@_%._%'),
    CONSTRAINT CK_Phone_Valid CHECK (Phone IS NULL OR (Phone NOT LIKE '%[^0-9+()-]%' AND LEN(Phone) BETWEEN 9 AND 15)),
    CONSTRAINT CK_UpdatedAt_Valid CHECK (UpdatedAt IS NULL OR CreatedAt <= UpdatedAt),
    CONSTRAINT CK_DateOfBirth_Valid CHECK (DateOfBirth IS NULL OR DateOfBirth <= DATEADD(YEAR, -12, GETDATE()))
);

CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Permissions (
    PermissionID INT PRIMARY KEY IDENTITY(1,1),
    PermissionName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    Module NVARCHAR(50) -- booking, user_management, flight_management, etc.
);

CREATE TABLE UserRoles (
    UserID UNIQUEIDENTIFIER NOT NULL,
    RoleID INT NOT NULL,
    AssignedAt DATETIME DEFAULT GETDATE(),
    AssignedBy UNIQUEIDENTIFIER,
    Note NVARCHAR(255), -- Ghi chú lý do cấp quyền
    PRIMARY KEY (UserID, RoleID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (AssignedBy) REFERENCES Users(UserID)
);

CREATE TABLE RolePermissions (
    RoleID INT NOT NULL,
    PermissionID INT NOT NULL,
    PRIMARY KEY (RoleID, PermissionID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID) ON DELETE CASCADE,
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID)
);

-- =============================================
-- 2. ĐỊA LÝ VÀ HẠNG MỤC
-- =============================================

CREATE TABLE Countries (
    CountryCode CHAR(3) PRIMARY KEY, -- ISO 3166-1 alpha-3
    CountryName NVARCHAR(100) NOT NULL,
    Currency CHAR(3), -- USD, VND, etc.
    IsActive BIT DEFAULT 1
);

CREATE TABLE Cities (
    CityCode CHAR(3) PRIMARY KEY, -- IATA City Code
    CityName NVARCHAR(100) NOT NULL,
    CountryCode CHAR(3) NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
);

CREATE TABLE Airlines (
    AirlineID INT PRIMARY KEY IDENTITY(1,1),
    AirlineName NVARCHAR(100) NOT NULL,
    IATACode CHAR(2) UNIQUE NOT NULL, -- VN, VJ, QH, etc.
    CountryCode CHAR(3) NOT NULL,
    ContactEmail NVARCHAR(100),
    ContactPhone NVARCHAR(20),
    Website NVARCHAR(100),
    LogoURL NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
);

CREATE TABLE Airports (
    AirportID INT PRIMARY KEY IDENTITY(1,1),
    AirportName NVARCHAR(100) NOT NULL,
    IATACode CHAR(3) UNIQUE NOT NULL,
    CityCode CHAR(3) NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (CityCode) REFERENCES Cities(CityCode)
);

-- =============================================
-- 3. AIRCRAFT VÀ CẤU HÌNH GHẾ
-- =============================================

CREATE TABLE AircraftTypes (
    AircraftTypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) NOT NULL, -- Boeing 737, Airbus A320
    DisplayName NVARCHAR(100) -- Tên hiển thị cho khách: "Boeing 737-800"
);

CREATE TABLE Aircraft (
    AircraftID INT PRIMARY KEY IDENTITY(1,1),
    AirlineID INT NOT NULL,
    AircraftTypeID INT NOT NULL,
    AircraftName NVARCHAR(50), -- Tên hiển thị cho khách (không bắt buộc)
    
    FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
    FOREIGN KEY (AircraftTypeID) REFERENCES AircraftTypes(AircraftTypeID)
);

CREATE TABLE SeatClasses (
    SeatClassID INT PRIMARY KEY IDENTITY(1,1),
    ClassName NVARCHAR(50) NOT NULL UNIQUE, -- Economy, Business, First
    DisplayName NVARCHAR(50) NOT NULL, -- Thương gia, Phổ thông, Hạng nhất
    PriceMultiplier DECIMAL(4,2) NOT NULL DEFAULT 1.0,
    BaggageAllowance_KG INT DEFAULT 20,
    CabinBaggageAllowance_KG INT DEFAULT 7,
    Description NVARCHAR(255),
    Features NVARCHAR(500), -- Mô tả tiện ích: "Ghế da cao cấp, khoảng chân rộng..."
    
    CONSTRAINT CK_PriceMultiplier_Valid CHECK (PriceMultiplier > 0)
);

-- Cấu hình số ghế theo hạng cho từng máy bay 
CREATE TABLE AircraftSeatConfig (
    ConfigID INT PRIMARY KEY IDENTITY(1,1),
    AircraftID INT NOT NULL,
    SeatClassID INT NOT NULL,
    SeatCount INT NOT NULL, -- Số ghế của hạng này
    RowStart INT, -- Hàng ghế bắt đầu (tùy chọn, để hiển thị)
    RowEnd INT,   -- Hàng ghế kết thúc (tùy chọn)
    
    UNIQUE(AircraftID, SeatClassID),
    FOREIGN KEY (AircraftID) REFERENCES Aircraft(AircraftID) ON DELETE CASCADE,
    FOREIGN KEY (SeatClassID) REFERENCES SeatClasses(SeatClassID),
    
    CONSTRAINT CK_SeatCount_Positive CHECK (SeatCount > 0)
);

CREATE TABLE Seats (
    SeatID INT PRIMARY KEY IDENTITY(1,1),
    AircraftID INT NOT NULL,
    SeatClassID INT NOT NULL,
    SeatNumber NVARCHAR(5) NOT NULL,  -- 1A, 12C
    IsAvailable BIT DEFAULT 1,
    
    FOREIGN KEY (AircraftID) REFERENCES Aircraft(AircraftID) ON DELETE CASCADE,
    FOREIGN KEY (SeatClassID) REFERENCES SeatClasses(SeatClassID),
    
    CONSTRAINT UQ_Aircraft_Seat UNIQUE (AircraftID, SeatNumber)
);


-- =============================================
-- 4. CHUYẾN BAY 
-- =============================================

CREATE TABLE Flights (
    FlightID INT PRIMARY KEY IDENTITY(1,1),
    AirlineID INT NOT NULL,
    FlightNumber NVARCHAR(10) NOT NULL,     -- VN210, VJ123
    AircraftID INT NOT NULL,
    
    -- Thông tin tuyến bay
    DepartureAirportID INT NOT NULL,
    ArrivalAirportID INT NOT NULL,
    
    -- Thông tin thời gian
    FlightDate DATE NOT NULL,               -- Ngày bay
    DepartureTime TIME NOT NULL,            -- Giờ khởi hành
    ArrivalTime TIME NOT NULL,              -- Giờ đến dự kiến
    Duration_Minutes INT,                   -- Thời gian bay (phút)
    
    -- Trạng thái và ghế
    Status NVARCHAR(20) DEFAULT 'Available', -- Available, Full, Cancelled
    
    -- Giá cơ bản (giá Economy)
    BasePrice DECIMAL(12,2) NOT NULL,
    
    UNIQUE(FlightNumber, FlightDate),       -- 1 chuyến bay chỉ có 1 lần/ngày
    FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
    FOREIGN KEY (AircraftID) REFERENCES Aircraft(AircraftID),
    FOREIGN KEY (DepartureAirportID) REFERENCES Airports(AirportID),
    FOREIGN KEY (ArrivalAirportID) REFERENCES Airports(AirportID),
    
    CONSTRAINT CK_Different_Airports CHECK (DepartureAirportID != ArrivalAirportID),
    CONSTRAINT CK_Flight_Status CHECK (Status IN ('Available', 'Full', 'Cancelled')),
    CONSTRAINT CK_BasePrice_Positive CHECK (BasePrice > 0)
);

-- Giá vé theo hạng ghế cho từng chuyến bay
CREATE TABLE FlightPricing (
    PricingID INT PRIMARY KEY IDENTITY(1,1),
    FlightID INT NOT NULL,
    SeatClassID INT NOT NULL,
    Price DECIMAL(12,2) NOT NULL,           -- Giá vé cho hạng này
    BookedSeats INT DEFAULT 0,              -- Số ghế đã đặt
    
    UNIQUE(FlightID, SeatClassID),
    FOREIGN KEY (FlightID) REFERENCES Flights(FlightID) ON DELETE CASCADE,
    FOREIGN KEY (SeatClassID) REFERENCES SeatClasses(SeatClassID),
    
    CONSTRAINT CK_Pricing_Price_Positive CHECK (Price > 0),
	CONSTRAINT CK_Pricing_Booked_Valid CHECK (BookedSeats >= 0)
);

-- =============================================
-- 5. ĐẶT VÉ VÀ HÀNH KHÁCH
-- =============================================

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    BookingReference NVARCHAR(10) UNIQUE NOT NULL, -- ABC123 - mã đặt chỗ
    UserID UNIQUEIDENTIFIER NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) DEFAULT 'Pending',
    Currency CHAR(3) DEFAULT 'VND',
    ContactEmail NVARCHAR(100),
    ContactPhone NVARCHAR(20),
    SpecialRequests NVARCHAR(500),
    
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    
    CONSTRAINT CK_Booking_Status CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled', 'Completed', 'Expired'))
);

CREATE TABLE Passengers (
    PassengerID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    PassengerType NVARCHAR(10) DEFAULT 'Adult', -- Adult, Child, Infant
    Title NVARCHAR(10), -- Ông, Bà, Anh, Chị
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Gender CHAR(1),
    IDNumber NVARCHAR(20), -- CMND/CCCD cho bay nội địa
    
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID) ON DELETE CASCADE,
    
    CONSTRAINT CK_Passenger_Type CHECK (PassengerType IN ('Adult', 'Child', 'Infant')),
    CONSTRAINT CK_Passenger_Gender CHECK (Gender IN ('M', 'F', 'O'))
);

-- Liên kết booking với chuyến bay (hỗ trợ khứ hồi)
CREATE TABLE BookingFlights (
    BookingFlightID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    FlightID INT NOT NULL,
    TripType NVARCHAR(10) DEFAULT 'OneWay', -- OneWay, Return
    
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID) ON DELETE CASCADE,
    FOREIGN KEY (FlightID) REFERENCES Flights(FlightID),
    
    CONSTRAINT CK_Trip_Type CHECK (TripType IN ('OneWay', 'Outbound', 'Return'))
);

-- Vé máy bay
CREATE TABLE Tickets (
    TicketID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BookingFlightID INT NOT NULL,
    PassengerID INT NOT NULL,
    SeatClassID INT NOT NULL,
    TicketNumber NVARCHAR(15) UNIQUE NOT NULL, -- 125-1234567890
    Price DECIMAL(12,2) NOT NULL,
    Taxes DECIMAL(10,2) DEFAULT 0,
    Fees DECIMAL(10,2) DEFAULT 0,
    Status NVARCHAR(20) DEFAULT 'Issued',
    CheckedInAt DATETIME,
    SeatNumber NVARCHAR(5), -- 12A, 5F (nếu có chọn ghế)
    
    FOREIGN KEY (BookingFlightID) REFERENCES BookingFlights(BookingFlightID) ON DELETE CASCADE,
    FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID),
    FOREIGN KEY (SeatClassID) REFERENCES SeatClasses(SeatClassID),
    
    CONSTRAINT CK_Ticket_Status CHECK (Status IN ('Issued', 'CheckedIn', 'Boarded', 'Cancelled', 'Refunded')),
    CONSTRAINT CK_Ticket_Price_Positive CHECK (Price > 0)
);

-- =============================================
-- 6. THANH TOÁN
-- =============================================

CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    PaymentProvider NVARCHAR(50), -- VNPay, Momo, ZaloPay, ATM, etc.
    Amount DECIMAL(15,2) NOT NULL,
    Currency CHAR(3) DEFAULT 'VND',
    Status NVARCHAR(20) DEFAULT 'Pending',
    TransactionID NVARCHAR(100), -- ID từ payment gateway
    ProcessedAt DATETIME,
    CompletedAt DATETIME,
    RefundedAmount DECIMAL(15,2) DEFAULT 0,
    
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID),
    
    CONSTRAINT CK_Payment_Status CHECK (Status IN ('Pending', 'Processing', 'Completed', 'Failed', 'Cancelled', 'Refunded')),
    CONSTRAINT CK_Payment_Amount_Positive CHECK (Amount > 0),
    CONSTRAINT CK_Refund_Valid CHECK (RefundedAmount >= 0 AND RefundedAmount <= Amount)
);

CREATE TABLE PaymentHistory (
    HistoryID INT PRIMARY KEY IDENTITY(1,1),
    PaymentID INT NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    TransactionTime DATETIME DEFAULT GETDATE(),
    Note NVARCHAR(255),
    FOREIGN KEY (PaymentID) REFERENCES Payments(PaymentID)
);

-- =============================================
-- 7. DỊCH VỤ THÊM
-- =============================================

CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL, -- Baggage, Meal, Priority, Insurance
    Description NVARCHAR(255),
    BasePrice DECIMAL(10,2) NOT NULL DEFAULT 0,
    Unit NVARCHAR(20), -- kg, item, person
    IsActive BIT DEFAULT 1,
    
    CONSTRAINT CK_Service_Category CHECK (Category IN ('Baggage', 'Meal', 'Priority', 'Insurance', 'Other'))
);

CREATE TABLE BookingServices (
    BookingServiceID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    ServiceID INT NOT NULL,
    PassengerID INT, -- Nếu dịch vụ cho hành khách cụ thể
    Quantity INT DEFAULT 1,
    UnitPrice DECIMAL(10,2) NOT NULL,
    
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID) ON DELETE CASCADE,
    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID),
    FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID),
    
    CONSTRAINT CK_Quantity_Positive CHECK (Quantity > 0)
);

-- =============================================
-- 8. KHUYẾN MÃI
-- =============================================

CREATE TABLE Promotions (
    PromotionID INT PRIMARY KEY IDENTITY(1,1),
    PromoCode NVARCHAR(20) UNIQUE NOT NULL,
    PromoName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    DiscountType NVARCHAR(10) NOT NULL, -- Percent, Fixed
    DiscountValue DECIMAL(10,2) NOT NULL,
    MinimumAmount DECIMAL(12,2) DEFAULT 0,
    MaximumDiscount DECIMAL(10,2),
    UsageLimit INT, -- Tổng số lần sử dụng
    UsageCount INT DEFAULT 0, -- Đã sử dụng bao nhiêu lần
    UserUsageLimit INT DEFAULT 1, -- Mỗi user sử dụng tối đa
    ValidFrom DATETIME NOT NULL,
    ValidTo DATETIME NOT NULL,
    IsActive BIT DEFAULT 1,
    
    CONSTRAINT CK_Discount_Type CHECK (DiscountType IN ('Percent', 'Fixed')),
    CONSTRAINT CK_Discount_Value_Valid CHECK (
        (DiscountType = 'Percent' AND DiscountValue BETWEEN 0.01 AND 100) OR
        (DiscountType = 'Fixed' AND DiscountValue > 0)
    ),
    CONSTRAINT CK_Promo_Date_Range_Valid CHECK (ValidFrom < ValidTo),
    CONSTRAINT CK_Usage_Valid CHECK (UsageCount <= ISNULL(UsageLimit, UsageCount))
);

CREATE TABLE BookingPromotions (
    BookingPromotionID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    PromotionID INT NOT NULL,
    DiscountAmount DECIMAL(10,2) NOT NULL,
    AppliedAt DATETIME DEFAULT GETDATE(),
    
    UNIQUE(BookingID, PromotionID),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID) ON DELETE CASCADE,
    FOREIGN KEY (PromotionID) REFERENCES Promotions(PromotionID)
);

-- =============================================
-- 9. THÔNG BÁO VÀ LOGS
-- =============================================

CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    UserID UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    Type NVARCHAR(20) NOT NULL,
    Channel NVARCHAR(20) NOT NULL, -- Email, SMS, Push, In-App
    RelatedBookingID INT,
    IsRead BIT DEFAULT 0,
    SentAt DATETIME,
    CreatedAt DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RelatedBookingID) REFERENCES Bookings(BookingID),
    
    CONSTRAINT CK_Notification_Type CHECK (Type IN ('Booking', 'Payment', 'Flight', 'Promotion', 'System')),
    CONSTRAINT CK_Notification_Channel CHECK (Channel IN ('Email', 'SMS', 'Push', 'In-App'))
);

CREATE TABLE AuditLogs (
    LogID BIGINT PRIMARY KEY IDENTITY(1,1),
    UserID UNIQUEIDENTIFIER,
    TableName NVARCHAR(50) NOT NULL,
    Operation NVARCHAR(10) NOT NULL, -- INSERT, UPDATE, DELETE
    RecordID NVARCHAR(50), -- ID của record bị thay đổi
    OldValues NVARCHAR(MAX), -- JSON của giá trị cũ
    NewValues NVARCHAR(MAX), -- JSON của giá trị mới
    Timestamp DATETIME DEFAULT GETDATE(),
    IPAddress NVARCHAR(45),
    UserAgent NVARCHAR(255),
    
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    
    CONSTRAINT CK_Operation_Valid CHECK (Operation IN ('INSERT', 'UPDATE', 'DELETE', 'SELECT'))
);

-- =============================================
-- 10. INDEXES ĐỂ TỐI ƯU HIỆU SUẤT
-- =============================================

-- User indexes
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_Phone ON Users(Phone);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);
CREATE INDEX IX_Users_CityCode ON Users(CityCode);

-- Flight indexes
CREATE INDEX IX_Flights_Date_Status ON Flights(FlightDate, Status);
CREATE INDEX IX_Flights_Number_Date ON Flights(FlightNumber, FlightDate);
CREATE INDEX IX_Flights_Airports ON Flights(DepartureAirportID, ArrivalAirportID);
CREATE INDEX IX_Flights_Airline ON Flights(AirlineID);
CREATE INDEX IX_Flights_Aircraft ON Flights(AircraftID);

-- Booking indexes
CREATE INDEX IX_Bookings_User ON Bookings(UserID);
CREATE INDEX IX_Bookings_Date_Status ON Bookings(BookingDate, Status);
CREATE INDEX IX_Bookings_Reference ON Bookings(BookingReference);
CREATE INDEX IX_Tickets_Number ON Tickets(TicketNumber);
CREATE INDEX IX_Tickets_BookingFlight ON Tickets(BookingFlightID);

-- Payment indexes
CREATE INDEX IX_Payments_Booking ON Payments(BookingID);
CREATE INDEX IX_Payments_Status ON Payments(Status);

-- Notification indexes
CREATE INDEX IX_Notifications_User_Read ON Notifications(UserID, IsRead);
CREATE INDEX IX_FlightPricing_Flight ON FlightPricing(FlightID);

-- =============================================
-- 11. STORED PROCEDURES
-- =============================================

-- Tìm chuyến bay
GO
CREATE PROCEDURE sp_SearchFlights
    @DepartureAirportID INT,
    @ArrivalAirportID INT,
    @DepartureDate DATE,
    @PassengerCount INT = 1,
    @SeatClassID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        f.FlightID,
        f.FlightNumber,
        a.AirlineName,
        a.LogoURL,
        dep.AirportName as DepartureAirport,
        dep.IATACode as DepartureCode,
        arr.AirportName as ArrivalAirport,
        arr.IATACode as ArrivalCode,
        f.FlightDate,
        f.DepartureTime,
        f.ArrivalTime,
        f.Duration_Minutes,
        f.Status,
        fp.Price,
        sc.DisplayName as SeatClassName,
        fsa.AvailableSeats as RemainingSeats,
        sc.BaggageAllowance_KG,
        sc.CabinBaggageAllowance_KG
    FROM Flights f
    INNER JOIN Airlines a ON f.AirlineID = a.AirlineID
    INNER JOIN Airports dep ON f.DepartureAirportID = dep.AirportID
    INNER JOIN Airports arr ON f.ArrivalAirportID = arr.AirportID
    INNER JOIN FlightPricing fp ON f.FlightID = fp.FlightID
    INNER JOIN SeatClasses sc ON fp.SeatClassID = sc.SeatClassID
    INNER JOIN vw_FlightSeatAvailability fsa ON f.FlightID = fsa.FlightID 
        AND sc.SeatClassID = fsa.SeatClassID
    WHERE f.DepartureAirportID = @DepartureAirportID
        AND f.ArrivalAirportID = @ArrivalAirportID
        AND f.FlightDate = @DepartureDate
        AND f.Status = 'Available'
        AND fsa.AvailableSeats >= @PassengerCount
        AND (@SeatClassID IS NULL OR fp.SeatClassID = @SeatClassID)
    ORDER BY f.DepartureTime, fp.Price;
END
GO

--tạo booking mới

CREATE PROCEDURE sp_CreateBooking
    @UserID UNIQUEIDENTIFIER,
    @ContactEmail NVARCHAR(100),
    @ContactPhone NVARCHAR(20),
    @BookingReference NVARCHAR(10) OUTPUT,
    @BookingID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        SET @BookingReference = UPPER(LEFT(CAST(NEWID() AS NVARCHAR(36)), 6));
        
        INSERT INTO Bookings (BookingReference, UserID, ContactEmail, ContactPhone, Status)
        VALUES (@BookingReference, @UserID, @ContactEmail, @ContactPhone, 'Pending');
        
        SET @BookingID = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- =============================================
-- 12. VIEW
-- =============================================

GO
CREATE VIEW vw_FlightAvailability AS
SELECT 
    f.FlightID,
    f.FlightNumber,
    f.FlightDate,
    SUM(asc.SeatCount) as TotalSeats,
    SUM(fp.BookedSeats) as BookedSeats,
    SUM(asc.SeatCount) - SUM(fp.BookedSeats) as RemainingSeats
FROM Flights f
INNER JOIN Aircraft a ON f.AircraftID = a.AircraftID
INNER JOIN AircraftSeatConfig asc ON a.AircraftID = asc.AircraftID
LEFT JOIN FlightPricing fp ON f.FlightID = fp.FlightID AND asc.SeatClassID = fp.SeatClassID
GROUP BY f.FlightID, f.FlightNumber, f.FlightDate;
GO

CREATE VIEW vw_BookingTotalAmount AS
SELECT 
    b.BookingID,
    b.BookingReference,
    ISNULL(SUM(t.Price + t.Taxes + t.Fees), 0) as TicketsTotal,
    ISNULL(SUM(bs.Quantity * bs.UnitPrice), 0) as ServicesTotal,
    ISNULL(SUM(bp.DiscountAmount), 0) as DiscountTotal,
    ISNULL(SUM(t.Price + t.Taxes + t.Fees), 0) + 
    ISNULL(SUM(bs.Quantity * bs.UnitPrice), 0) - 
    ISNULL(SUM(bp.DiscountAmount), 0) as TotalAmount
FROM Bookings b
LEFT JOIN BookingFlights bf ON b.BookingID = bf.BookingID
LEFT JOIN Tickets t ON bf.BookingFlightID = t.BookingFlightID
LEFT JOIN BookingServices bs ON b.BookingID = bs.BookingID
LEFT JOIN BookingPromotions bp ON b.BookingID = bp.BookingID
GROUP BY b.BookingID, b.BookingReference;
GO

CREATE VIEW vw_FlightSeatAvailability AS
SELECT 
    f.FlightID,
    f.FlightNumber,
    f.FlightDate,
    sc.SeatClassID,
    sc.DisplayName as SeatClassName,
    asc.SeatCount as TotalSeats,
    fp.BookedSeats,
    asc.SeatCount - ISNULL(fp.BookedSeats, 0) as AvailableSeats
FROM Flights f
INNER JOIN Aircraft a ON f.AircraftID = a.AircraftID
INNER JOIN AircraftSeatConfig asc ON a.AircraftID = asc.AircraftID
INNER JOIN SeatClasses sc ON asc.SeatClassID = sc.SeatClassID
LEFT JOIN FlightPricing fp ON f.FlightID = fp.FlightID AND sc.SeatClassID = fp.SeatClassID;
GO

-- =============================================
-- 13. trigger
-- =============================================

CREATE TRIGGER trg_UpdatePaymentStatus
ON Payments
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO PaymentHistory (PaymentID, Status, TransactionTime, Note)
    SELECT 
        i.PaymentID,
        i.Status,
        GETDATE(),
        'Status changed from ' + d.Status + ' to ' + i.Status
    FROM inserted i
    INNER JOIN deleted d ON i.PaymentID = d.PaymentID
    WHERE i.Status <> d.Status;
END;
GO

CREATE TRIGGER trg_InitFlightPricing
ON Flights
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO FlightPricing (FlightID, SeatClassID, Price, BookedSeats)
    SELECT 
        i.FlightID,
        asc.SeatClassID,
        i.BasePrice * sc.PriceMultiplier,
        0
    FROM inserted i
    INNER JOIN AircraftSeatConfig asc ON i.AircraftID = asc.AircraftID
    INNER JOIN SeatClasses sc ON asc.SeatClassID = sc.SeatClassID;
END;
GO

CREATE TRIGGER trg_UpdateBookedSeats
ON Tickets
AFTER INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Update khi INSERT
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE fp
        SET BookedSeats = BookedSeats + 1
        FROM FlightPricing fp
        INNER JOIN BookingFlights bf ON fp.FlightID = bf.FlightID
        INNER JOIN inserted i ON bf.BookingFlightID = i.BookingFlightID
        WHERE fp.SeatClassID = i.SeatClassID;
    END
    
    -- Update khi DELETE
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE fp
        SET BookedSeats = BookedSeats - 1
        FROM FlightPricing fp
        INNER JOIN BookingFlights bf ON fp.FlightID = bf.FlightID
        INNER JOIN deleted d ON bf.BookingFlightID = d.BookingFlightID
        WHERE fp.SeatClassID = d.SeatClassID;
    END
END;
GO

CREATE TRIGGER trg_UpdateFlightStatus
ON FlightPricing
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE f
    SET Status = CASE 
        WHEN fa.RemainingSeats = 0 THEN 'Full'
        WHEN fa.RemainingSeats > 0 THEN 'Available'
        ELSE f.Status
    END
    FROM Flights f
    INNER JOIN vw_FlightAvailability fa ON f.FlightID = fa.FlightID
    WHERE f.FlightID IN (SELECT DISTINCT FlightID FROM inserted);
END;
GO