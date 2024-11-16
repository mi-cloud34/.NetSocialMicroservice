#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Services/SocialMicroservice.Services.Post/Posts/Post.WebAPI/Post.WebAPI.csproj", "Src/Services/SocialMicroservice.Services.Post/Posts/Post.WebAPI/"]
COPY ["Src/Services/SocialMicroservice.Services.Post/Posts/Post.Application/Post.Application.csproj", "Src/Services/SocialMicroservice.Services.Post/Posts/Post.Application/"]
COPY ["Src/FileStorage/Social.FileStorage/Social.FileStorage.csproj", "Src/FileStorage/Social.FileStorage/"]
COPY ["Src/AuthServer/Social.AuthApi/Social.AuthApi.csproj", "Src/AuthServer/Social.AuthApi/"]
COPY ["Src/Services/SocialMicroservice.Services.Message/Core/Core.Persistance/Core.Persistance.csproj", "Src/Services/SocialMicroservice.Services.Message/Core/Core.Persistance/"]
COPY ["Src/Services/SocialMicroservice.Services.Message/Message/Message.Domain/Message.Domain.csproj", "Src/Services/SocialMicroservice.Services.Message/Message/Message.Domain/"]
COPY ["Src/Services/SocialMicroservice.Services.Post/Core/Core.Application/Core.Application.csproj", "Src/Services/SocialMicroservice.Services.Post/Core/Core.Application/"]
COPY ["Src/Services/SocialMicroservice.Services.Message/Core/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "Src/Services/SocialMicroservice.Services.Message/Core/Core.CrossCuttingConcerns/"]
COPY ["Src/Services/SocialMicroservice.Services.Post/Posts/Post.Domain/Post.Domain.csproj", "Src/Services/SocialMicroservice.Services.Post/Posts/Post.Domain/"]
COPY ["Src/Services/SocialMicroservice.Services.Post/Posts/Post.Persistance/Post.Persistance.csproj", "Src/Services/SocialMicroservice.Services.Post/Posts/Post.Persistance/"]
RUN dotnet restore "./Src/Services/SocialMicroservice.Services.Post/Posts/Post.WebAPI/Post.WebAPI.csproj"
COPY . .
WORKDIR "/src/Src/Services/SocialMicroservice.Services.Post/Posts/Post.WebAPI"
RUN dotnet build "./Post.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Post.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Post.WebAPI.dll"]