# 🛒 Product Management System (Angular + .NET 8)

A fullstack solution including a .NET 8 Web API and an Angular application with TypeScript to manage products and categories through a comprehensive CRUD system. The application implements clean architecture patterns, advanced state management with NgRx, and a modern UI with PrimeNG components.

---

## ⚙️ Main functionality

- View list of products with category information
- Create new products with category assignment
- Edit existing products
- Delete products with confirmation dialogs
- View detailed product information
- Manage product categories
- Advanced filtering and search capabilities

---

## 🚀 Key features

- **Clean Architecture**: Implements Domain-Driven Design with separate layers (Domain, Application, Infrastructure, API).
- **Advanced State Management**: Uses NgRx with effects, reducers, and selectors for predictable state management.
- **Simplified Form Architecture**: Custom ngrx-forms integration with only 4 essential actions for clean form handling.
- **Centralized Notifications**: Effect-based success/error notifications using PrimeNG MessageService.
- **Smart Navigation**: Conditional navigation logic that avoids unnecessary redirects.
- **Professional UI**: Modern interface using PrimeNG components with consistent styling.
- **Optimized UX**: Loading spinners, confirmation dialogs, and proper error handling.
- **Component Architecture**: Reusable components with SharedModule pattern.

---

## 🛠️ Technologies used

### Backend (.NET 8)
- ASP.NET Core 8 Web API
- Clean Architecture (Domain, Application, Infrastructure layers)
- Entity Framework Core (with migrations)
- Repository Pattern + Unit of Work
- AutoMapper (for object mapping)
- Dependency Injection
- SQL Server / SQLite (configurable)
- Docker support

### Frontend (Angular 16)
- Angular 16 + TypeScript
- NgRx 16.2.0 (state management with effects, reducers, selectors)
- ngrx-forms 8.0.0 (reactive form state management)
- PrimeNG (UI component library)
- RxJS (reactive programming)
- SCSS (styling)
- Responsive design
- Docker support with Nginx

---

## 📦 Docker Compose and ports

The project includes a `docker-compose.yml` file that brings up the following services:

| Service           | External Port | Internal Port | Description                    |
|-------------------|---------------|---------------|--------------------------------|
| Angular App       | 4200          | 80            | Frontend application           |
| .NET API          | 8080          | 80            | Web API for product management |

---

## 🏗️ Architecture highlights

### Backend Architecture
- **Domain Layer**: Core business entities (Product, ProductCategory, DomainEntity)
- **Application Layer**: CQRS commands/queries, behaviors, and interfaces
- **Infrastructure Layer**: Repository implementations, Entity Framework context
- **API Layer**: Controllers, middleware, AutoMapper profiles

### Frontend Architecture
- **Feature-based Structure**: Organized by domain (products, product-categories)
- **NgRx State Management**: Centralized state with actions, reducers, effects, and selectors
- **Component Hierarchy**: Smart containers and presentational components
- **Shared Module**: Reusable components (LoadingSpinner, NotFound)
- **Form State Management**: Simplified ngrx-forms with 4-action pattern

---

## 🎯 NgRx Implementation Details

### Simplified Form Actions

### Effect-based Side Effects
- **CRUD Operations**: Centralized API calls with error handling
- **Notifications**: Success/error messages managed in effects
- **Navigation**: Smart routing based on current location
- **Confirmations**: Centralized confirmation dialogs in effects

### State Management
- **Products State**: Loading states, error handling, optimistic updates
- **Form State**: Modal visibility, edit mode, validation states
- **Selectors**: Computed properties for component consumption

---

## 🔄 Data Flow

1. **Component** dispatches action
2. **Effect** handles side effects (API calls, navigation, notifications)
3. **Reducer** updates state based on success/failure actions
4. **Selectors** provide computed data to components
5. **Components** react to state changes via observables

---

## 🎨 UI/UX Features

- **Modern Design**: Professional interface with PrimeNG components
- **Loading States**: Progress spinners during async operations
- **Error Handling**: User-friendly error messages and 404 pages
- **Confirmation Dialogs**: Safe deletion with confirmation prompts
- **Responsive Tables**: Sortable, filterable, paginated data tables
- **Form Validation**: Real-time validation with conditional error display
- **Smart Dropdowns**: Scroll-friendly dropdowns with appendTo="body"

---

## ▶️ How to run the project

### Using Docker (Recommended)
From the root of the project, run:
```bash
docker-compose up
```

---

## 🧪 Testing

The solution includes comprehensive unit tests:
- **Backend**: Unit tests for application layer using MSTest
- **Frontend**: Component and service tests (ready for Jest/Jasmine)

---

## 🆕 Recent Updates

### Form Architecture Simplification (2025-01-31)
- Reduced complex ngrx-forms implementation to 4 essential actions
- Implemented centralized notification system in NgRx effects
- Added conditional navigation logic for better UX
- Replaced custom CSS spinners with PrimeNG components

### UI/UX Improvements
- Professional 404 page with navigation options
- Fixed dropdown scrolling issues with appendTo="body"
- Implemented proper validation timing (show errors only when touched)
- Added button disable logic based on form validity

### Architecture Enhancements
- Centralized confirmation dialogs in effects
- Store-managed modal visibility instead of component-level state
- Proper product not found handling without navigation issues
- Clean component architecture with minimal dependencies

---

## 📁 Project Structure

```
EvoltisChallenge/
├── EvoltisChallenge.Api/           # .NET 8 Web API
│   ├── src/
│   │   ├── EvoltisChallenge.Api/           # API layer
│   │   ├── EvoltisChallenge.Api.Application/     # Application layer
│   │   ├── EvoltisChallenge.Api.Domain/          # Domain layer
│   │   └── EvoltisChallenge.Api.Infrastructure/  # Infrastructure layer
│   └── tests/                      # Unit tests
├── EvoltisChallenge.App/           # Angular 16 Frontend
│   └── src/app/
│       ├── core/                   # Core services and guards
│       ├── shared/                 # Shared components and modules
│       ├── features/               # Feature modules
│       │   ├── products/           # Product management
│       │   └── product-categories/ # Category management
│       └── states/                 # Global state management
└── docker-compose.yml             # Container orchestration
```

---

## 👤 Author

**Adam Ezequiel Tolosa**  
📧 [LinkedIn](https://www.linkedin.com/in/tolosa-adam-ezequiel/)
