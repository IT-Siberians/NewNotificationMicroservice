# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NewNotificationMicroservice.Web/NewNotificationMicroservice.Web.csproj", "NewNotificationMicroservice.Web/"]
COPY ["NewNotificationMicroservice.Application.Abstractions/NewNotificationMicroservice.Application.Services.Abstractions.csproj", "NewNotificationMicroservice.Application.Abstractions/"]
COPY ["NewNotificationMicroservice.Application.Models/NewNotificationMicroservice.Application.Models.csproj", "NewNotificationMicroservice.Application.Models/"]
COPY ["NewNotificationMicroservice.Domain.Entities/NewNotificationMicroservice.Domain.Entities.csproj", "NewNotificationMicroservice.Domain.Entities/"]
COPY ["NewNotificationMicroservice.Domain.ValueObjects/NewNotificationMicroservice.Domain.ValueObjects.csproj", "NewNotificationMicroservice.Domain.ValueObjects/"]
COPY ["NewNotificationMicroservice.Domain.ValueObjects.Abstractions/NewNotificationMicroservice.Domain.ValueObjects.Abstractions.csproj", "NewNotificationMicroservice.Domain.ValueObjects.Abstractions/"]
COPY ["NewNotificationMicroservice.Application.Services/NewNotificationMicroservice.Application.Services.csproj", "NewNotificationMicroservice.Application.Services/"]
COPY ["NewNotificationMicroservice.Infrastructure.RabbitMQ/NewNotificationMicroservice.Infrastructure.RabbitMQ.csproj", "NewNotificationMicroservice.Infrastructure.RabbitMQ/"]
COPY ["NewNotificationMicroservice.Common.Infrastructure.Queue.Abstraction/NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction.csproj", "NewNotificationMicroservice.Common.Infrastructure.Queue.Abstraction/"]
COPY ["NewNotificationMicroservice.Common.Infrastructure.Queues/NewNotificationMicroservice.Common.Infrastructure.Queues.csproj", "NewNotificationMicroservice.Common.Infrastructure.Queues/"]
COPY ["NewNotificationMicroservice.Domain.Repositories.Abstractions/NewNotificationMicroservice.Domain.Repositories.Abstractions.csproj", "NewNotificationMicroservice.Domain.Repositories.Abstractions/"]
COPY ["NewNotificationMicroservice.Infrastructure.MediatR/NewNotificationMicroservice.Infrastructure.MediatR.csproj", "NewNotificationMicroservice.Infrastructure.MediatR/"]
COPY ["NewNotificationMicroservice.Infrastructure.Queues.Implementations/NewNotificationMicroservice.Infrastructure.Queues.Implementations.csproj", "NewNotificationMicroservice.Infrastructure.Queues.Implementations/"]
COPY ["NewNotificationMicroservice.Infrastructure.Repositories.Implementations/NewNotificationMicroservice.Infrastructure.Repositories.Implementations.csproj", "NewNotificationMicroservice.Infrastructure.Repositories.Implementations/"]
COPY ["NewNotificationMicroservice.Infrastructure.EntityFramework/NewNotificationMicroservice.Infrastructure.EntityFramework.csproj", "NewNotificationMicroservice.Infrastructure.EntityFramework/"]
RUN dotnet restore "./NewNotificationMicroservice.Web/NewNotificationMicroservice.Web.csproj"
COPY . .
WORKDIR "/src/NewNotificationMicroservice.Web"
RUN dotnet build "./NewNotificationMicroservice.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewNotificationMicroservice.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewNotificationMicroservice.Web.dll"]