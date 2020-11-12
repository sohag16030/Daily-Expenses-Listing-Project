FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DailyExpense.Web/*.csproj", "DailyExpense.Web/"]
COPY ["DailyExpense.Framework/*.csproj", "DailyExpense.Framework/"]
COPY ["DailyExpense.Data/*.csproj", "DailyExpense.Data/"]
RUN dotnet restore "DailyExpense.Web/DailyExpense.Web.csproj"
COPY . .
WORKDIR "/src/DailyExpense.Web"
RUN dotnet build "DailyExpense.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DailyExpense.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DailyExpense.Web.dll"]