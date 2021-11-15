# Aspnet Intranet Web Application Template
An opinionated template for intranet Line-of-business web applications

# Considerations
- Great for **small to medium**-scale web applications, with flexibility to grow
  
  *(large web applications with dozens of webservices services and hundreds of pages are out of scope of this approach)*

- [Service-Oriented Architecture](https://en.wikipedia.org/wiki/Service-oriented_architecture)
  - **Business value** is given more importance than technical strategy.
  - **Strategic goals** are given more importance than project-specific benefits.
  - **Intrinsic interoperability** is given more importance than custom integration.
  - **Shared services** are given more importance than specific-purpose implementations.
  - **Flexibility** is given more importance than optimization.
  - **Evolutionary refinement** is given more importance than pursuit of initial perfection.

# Features
- Blazor Webassembly
- SwaggerUI
- Strongly-typed OpenApi client
- Automatic OpenApi client updates using NSwag MSBuild and Connected Services
- Windows Authentication

# Planned Features
- AzureAd Authentication

# Feature Wishlist
- Proxy WebApis (for Onion Architecture networks)
