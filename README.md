#  AutoMapper.Demo

A simple .NET Web API project demonstrating how to use **AutoMapper** to map between different views like **domain models** and **DTOs (Data Transfer Objects)**.

---

##  Project Structure

```
AutoMapper.Demo/
├── Models/         # Domain models (User, Address, Order)
├── DTOs/           # DTOs used for input/output
├── Profiles/       # AutoMapper mapping profiles
├── Services/       # Service logic using AutoMapper
├── Controllers/    # API endpoints
└── Program.cs      # Application setup
```

---

##  What is AutoMapper?

**AutoMapper** is a library that automatically maps properties between two objects — for example a domain **Model** and a **DTO** — eliminating the need for manual conversion logic.

---

##  Fast recap: What Are Models and DTOs?

###  Models (`Models/`)
- Represent actual data in the system (e.g., `User`, `Address`, `Order`)
- Used internally and reflect the database structure

###  DTOs (`DTOs/`)
- **Data Transfer Objects** used for API input/output
- Control what data is exposed to the client
- Simplify and protect internal data models

#### Example:

```csharp
// Model
public class User {
    public string FirstName;
    public string LastName;
    public DateTime CreatedAt; // Date time object
}

// DTO
public class UserDto {
    public string FullName;
    public string MemberSince; // string object
}
```

---

##  How Mapping Works

AutoMapper automatically maps matching property names. Otherwise, use `.ForMember()`.

#### Example Mapping (`Profiles/UserProfile.cs`):

```csharp

// From User to UserDto
CreateMap<User, UserDto>()
    .ForMember(dest => dest.FullName, 
        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
    .ForMember(dest => dest.MemberSince, 
        opt => opt.MapFrom(src => src.CreatedAt.ToString("MMMM yyyy")));
// This is to generate the Fullname of UserDto from the first and last name of user,
// Also to generate MemeberSince(string) from the Datetime Object.
```

#### Reverse Mapping:

```csharp

// Automapping in 2 directions
CreateMap<Address, AddressDto>().ReverseMap();
```

---

##  Setup AutoMapper

1. **Install NuGet package**:

```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

2. **Register AutoMapper in `Program.cs`**:

```csharp
builder.Services.AddAutoMapper(cfg =>
{
    // Automatically register all AutoMapper profiles 
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
```

3. **Create a Profile (`Profiles/UserProfile.cs`)**: a Profile is a class used to group and configure mappings between types.

```csharp
public UserProfile()
{
    CreateMap<User, UserDto>()
        .ForMember(dest => dest.FullName,
            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
        .ForMember(dest => dest.AddressLine,
            opt => opt.MapFrom(src => $"{src.Address.Street}, {src.Address.City}"))
        .ForMember(dest => dest.MemberSince,
            opt => opt.MapFrom(src => src.CreatedAt.ToString("MMMM yyyy")));

    CreateMap<CreateUserDto, User>()
        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

    CreateMap<Address, AddressDto>().ReverseMap();
}
}
```

---

##  Example Flow

- **POST** `/api/users`:  
  Receives `CreateUserDto`, maps to `User`, saves it.

- **GET** `/api/users/1`:  
  Retrieves `User`, maps to `UserDto`, returns it to the client.
