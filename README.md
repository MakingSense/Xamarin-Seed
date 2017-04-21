# Xamarin-Seed

## MVVM seed for Xamarin.Android (and Xamarin.iOS in progress)

This project contains the codebase for an MVVM application targeting Android and iOS. It relies on MvvmCross framework to support databinding, viewmodel-first navigation and IoC among other important features.

The structure of the project is as follow:

- Presentation Layer
  - Android UI (platform specific assembly targeting Xamarin.Android)
  - iOS UI (platform specific assembly targeting Xamarin.iOS - WIP)

- Application Layer
  - .NET Standard assembly containing viewmodels, handling navigation and non platform-specific components
  
- Domain Layer
  - Services and models
  
- Unit Tests project
  - Unit tests for application and domain layers, relying on xUnit
  
## Important PRs/Highlights for this project

- [1. Initial Setup] (https://github.com/makingsensetraining/mobile-pocs/pull/2)
- [2. MvvmCross integration] (https://github.com/makingsensetraining/mobile-pocs/pull/3)
- [3. Autofac as IoC container] (https://github.com/makingsensetraining/mobile-pocs/pull/4)
- [4. Local Storage]
  - [4.1 RealmDb - Disregarded] (https://github.com/makingsensetraining/mobile-pocs/pull/5)
  - [4.2 Entity Framework 7] (https://github.com/makingsensetraining/mobile-pocs/pull/6)
- [5. App intialization improvements] (https://github.com/makingsensetraining/mobile-pocs/pull/7)
